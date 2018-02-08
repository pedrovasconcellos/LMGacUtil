using LMGacUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMGacUtil.Entities;
using System.Windows.Forms;

namespace LMGacUtil.CustomControl
{
    public class GacDllListView : System.Windows.Forms.ListView, IGacDllEntity, IMyDllObserver
    {
        private List<MyDll> Dlls;

        public GacDllListView()
        {
            Dlls = new List<MyDll>();

            this.CheckBoxes = true;
            this.Columns.Add("Name");
            this.Columns.Add("Installed");
            this.Columns.Add("PublicKeyToken");

            this.ItemCheck += GacDllListView_ItemCheck;

        }

        private void GacDllListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Dlls[e.Index].Checked = e.NewValue == CheckState.Checked;
        }

        public IEnumerable<MyDll> GetDll
        {
            get
            {

                return Dlls.Select(item => (MyDll)item.Clone()).ToList();

            }
        }

        public void AddDll(MyDll myDll)
        {

            myDll.AddObserver(this);
            Dlls.Add(myDll);
            UpdateDll();
        }

        public void ClearDll()
        {
            Dlls.Clear();
            UpdateDll();
        }

        public void UpdateDll()
        {

            this.Clear();
            this.CheckBoxes = true;
            this.Columns.Add("Name", 350);
            this.Columns.Add("Installed", 150);
            this.Columns.Add("PublicKeyToken", 150);

            foreach (var dll in Dlls)
            {

                this.Items.Add(new System.Windows.Forms.ListViewItem(new string[] {
                    dll.Name,
                    dll.Installed.ToString(),
                    dll.PublicKeyToken

                    }
                )).Checked = dll.Checked;


            }





        }

    }


}
