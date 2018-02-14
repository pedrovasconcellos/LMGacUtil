using COMAdmin;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.COM
{
    class MyCOMAdmin
    {



        private List<string> _componentes = new List<string>();


        public MyCOMAdmin()
        {






        }

        public void Refresh()
        {

            _componentes.Clear();

            COMAdminCatalogCollection applications;
            COMAdminCatalog catalog;
            catalog = new COMAdminCatalog();
            applications = (COMAdminCatalogCollection)catalog.GetCollection("Applications");
            applications.Populate();

            foreach (COMAdminCatalogObject application in applications)
            {
                //do something with the application
                if (application.Name.Equals("RepomComponentsNET"))
                {
                    COMAdminCatalogCollection components;


                    components = applications.GetCollection("Components", application.Key);

                    components.Populate();
                    foreach (COMAdminCatalogObject component in components)
                    {
                        _componentes.Add(component.Name);
                    }
                }

            }

        }


        public bool IsInstalled(string name)
        {
            return _componentes.Any(x => x.IndexOf(name) > -1);
        }

        public void Install(string name)
        {

            try
            {

                Type ExcelType = Type.GetTypeFromProgID("COMAdmin.COMAdminCatalog");
                dynamic ExcelInst = Activator.CreateInstance(ExcelType);
                ExcelInst.InstallComponent("RepomComponentsNET", $"C:\\RepomComponentsNET\\{name}.dll", "", "");
                ExcelInst = null;

            }
            catch (Exception ex)
            {

            }



        }

        public void Unstall(string name)
        {





        }





    }
}
