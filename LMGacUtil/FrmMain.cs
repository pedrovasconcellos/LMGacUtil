using LMGacUtil.Entities;
using LMGacUtil.Interfaces;
using LMGacUtil.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMGacUtil
{
    public partial class FrmMain : Form, ICommandExecuterObserver
    {
        private ICommandExecuter _commandExecuter;
        private List<MyDll> myDlls = new List<MyDll>();
        private IDirectoryHelper _directoryHelperService;
        private IGacHelper _cacHelper;


        private List<String> ItensChekeds = new List<string>();


        public FrmMain()
        {

            InitializeComponent();
            _commandExecuter = new CommandExecuterService();
            _commandExecuter.AddUpdateObserver(this);
            _cacHelper = new GacHelperService(GetTargetDirectory,_commandExecuter);
            _directoryHelperService = new DirectoryHelperService(GetTargetDirectory, _cacHelper);
            mylist.ItemChecked += Mylist_ItemChecked;
            RefreshButtonByCheck();

        }

        private string GetTargetDirectory
        {
            get
            {
                return @"C:\RepomComponentsNET";

            }
        }


        private void Mylist_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            if (e.Item.Checked)
            {
                if (!ItensChekeds.Contains(e.Item.Name))
                    ItensChekeds.Add(e.Item.Name);

            }
            else
            {
                if (ItensChekeds.Contains(e.Item.Name))
                    ItensChekeds.Remove(e.Item.Name);
            }


            btnCheck.Text = mylist.CheckedItems.Count == mylist.Items.Count ? "Uncheck All" : "Check All";
            RefreshButtonByCheck();
        }

        public void RefreshButtonByCheck()
        {
            btnInstall.Enabled = mylist.CheckedItems.Count > 0;
            btnUnstall.Enabled = btnInstall.Enabled;
            btnCheck.Enabled = mylist.Items.Count > 0;

            if (mylist.Items.Count == 0)
            {
                LblListMessage.Text = $"There are no dlls in the \"{GetTargetDirectory}\" path";

            }
            else
            {
                LblListMessage.Text = $"There are \"{mylist.Items.Count.ToString()}\" dlls in the \"{GetTargetDirectory}\" path";
            }


        }

        public void Done()
        {
        }

        public void Update(string text)
        {

            if (txtLog.Text.Length == 0)
                txtLog.Text = text;
            else
                txtLog.AppendText("\r\n" + text);

            txtLog.Refresh();
        }

        private void btnIIsRestart_Click(object sender, EventArgs e)
        {
            btnIIsRestart.Enabled = false;
            _commandExecuter.ExecuteCommand(@"C:\Windows\System32\iisreset.exe", " /restart", (string output) =>
            {
                btnIIsRestart.Enabled = true;

                if (output.IndexOf("erro") > -1)
                {
                    MessageBox.Show("Error", "IIsRestar error");
                }
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            txtFilter.Enabled = false;


            LblListMessage.Text = "Loading...";

            _directoryHelperService.GetDlls(txtFilter.Text, (dlls) =>
            {

                mylist.Clear();
                mylist.View = View.Details;
                mylist.CheckBoxes = true;
                mylist.Columns.Add("Name");
                mylist.Columns.Add("Installed");
                mylist.Columns.Add("PublicKeyToken");

                // Populate the data source.
                foreach (var dll in dlls)
                {
                    var item = new ListViewItem(new string[] {
                            dll.Name,
                            dll.Installed.ToString(),
                            dll.PublicKeyToken
                        })
                    {
                        Name = dll.Name,
                        Checked = ItensChekeds.Contains(dll.Name)
                    };

                    mylist.Items.Add(item);
                }
                mylist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                mylist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                btnRefresh.Enabled = true;
                txtFilter.Enabled = true;
                txtFilter.SelectAll();
                txtFilter.Focus();


                RefreshButtonByCheck();


            });





        }


        private void btnInstall_Click(object sender, EventArgs e)
        {
            var insta = new List<string>();


            foreach (ListViewItem sel in mylist.CheckedItems)
            {

                insta.Add(sel.Name);

            }


            _cacHelper.Install(insta, (sucesso, dll) =>
            {

                // var item = mylist.Items.Find(dll, false);


            }, () =>
            {

                btnRefresh.PerformClick();
            });



        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnRefresh.PerformClick();
            }


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            var todosSelecionados = true;
            foreach (ListViewItem sel in mylist.Items)
            {
                if (!sel.Checked)
                {
                    todosSelecionados = false;
                    break;
                }
            }

            foreach (ListViewItem sel in mylist.Items)
            {
                sel.Checked = !todosSelecionados;

            }

        }

        private void LblListMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnUnstall_Click(object sender, EventArgs e)
        {
            var insta = new List<string>();


            foreach (ListViewItem sel in mylist.CheckedItems)
            {

                insta.Add(sel.Name);

            }


            _cacHelper.Unstall(insta, (sucesso, dll) =>
            {

                // var item = mylist.Items.Find(dll, false);


            }, () =>
            {

                btnRefresh.PerformClick();
            });

   
        }
    }
}
