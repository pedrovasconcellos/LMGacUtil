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

        public FrmMain()
        {
            InitializeComponent();

            _commandExecuter = new CommandExecuterService();
            _commandExecuter.AddUpdateObserver(this);

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



    }
}
