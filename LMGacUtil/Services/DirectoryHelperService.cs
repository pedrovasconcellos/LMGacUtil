using LMGacUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMGacUtil.Entities;
using System.IO;
using System.Windows.Forms;
using LMGacUtil.CustomControl;
using System.ComponentModel;

namespace LMGacUtil.Services
{

    public class DirectoryHelperService : IDirectoryHelper
    {
        private IGacDllEntity _gacDllEntity;
        private IGacHelper _cacHelper;

        public string TargetDirectory { get; set; }

        public DirectoryHelperService(string targetDirectory, IGacHelper cacHelper)
        {
            _cacHelper = cacHelper;
            TargetDirectory = targetDirectory;
        }

        public void FillDll(IGacDllEntity gacDllEntity, string filter, Action calback)
        {

            _gacDllEntity = gacDllEntity;

            var targetDirectory = @"C:\RepomComponentsNET";


            // guarda os checados
            var checados = new Dictionary<string, bool>();

            foreach (var sel in _gacDllEntity.GetDll)
            {
                checados.Add(sel.Name, sel.Checked);
            }


            _gacDllEntity.ClearDll();

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {

                var extension = Path.GetExtension(fileName);
                if (extension.ToLower() != ".dll") continue;
                var name = Path.GetFileName(fileName).Replace(extension, string.Empty);
                // Filtra 
                if (!string.IsNullOrEmpty(filter) && !name.ToLower().Contains(filter.ToLower())) continue;

                var dll = new MyDll()
                {
                    Name = name,
                    Path = fileName,
                    Extension = extension,
                    Checked = !checados.ContainsKey(name) ? false : checados[name]
                };
                _cacHelper.GacLisat(dll);
                _gacDllEntity.AddDll(dll);

            }

            calback();

        }

        public List<MyDll> GetDlls(string filter)
        {

            var retorno = new List<MyDll>();

            string[] fileEntries = Directory.GetFiles(TargetDirectory);
            foreach (string fileName in fileEntries)
            {

                var extension = Path.GetExtension(fileName);
                if (extension.ToLower() != ".dll") continue;
                var name = Path.GetFileName(fileName).Replace(extension, string.Empty);
                // Filtra 
                if (!string.IsNullOrEmpty(filter) && !name.ToLower().Contains(filter.ToLower())) continue;

                var dll = new MyDll()
                {
                    Name = name,
                    Path = fileName,
                    Extension = extension
                };
                _cacHelper.GacLisat(dll);
                retorno.Add(dll);

            }

            return retorno;


        }

        public void GetDlls(string filter, Action<List<MyDll>> calback)
        {


            BackgroundWorker bw = new BackgroundWorker
            {
                // this allows our worker to report progress during work
                WorkerReportsProgress = true
            };

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;


                var dlls = GetDlls(filter);
                b.ReportProgress(100, dlls);


            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {
                calback((List<MyDll>)args.UserState);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {


            });

            bw.RunWorkerAsync();


        }



    }

}
