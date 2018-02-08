using LMGacUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMGacUtil.Entities;
using System.ComponentModel;
using System.IO;

namespace LMGacUtil.Services
{
    public class GacHelperService : IGacHelper
    {
        private ICommandExecuter _commandExecuter;
        public string GetTargetDirectory { get; set; }

        public GacHelperService(string getTargetDirectory, ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
            GetTargetDirectory = getTargetDirectory;

        }


        public void GacLisat(MyDll mydll)
        {
            var args = string.Format(" /l {0}", mydll.Name);

            var output = _commandExecuter.ExecuteCommand(@"C:\RepomComponentsNET\GACUTIL 4.0\gacutil.exe", args);

            string[] lines = output.Split(
               new[] { "\r\n", "\r", "\n" },
               StringSplitOptions.None
           );

            foreach (var line in lines)
            {
                if (line.IndexOf("Number of items = 1") > -1)
                    mydll.Installed = true;

                if (line.IndexOf("PublicKeyToken=") > -1)
                {
                    var list = line.Split(',');
                    if (list.Length >= 3)
                    {
                        mydll.PublicKeyToken = list[3].Substring("PublicKeyToken=".Length + 1);
                    }


                };
            }


        }

        public void Install(List<MyDll> mydll, Action<bool> callback)
        {

            foreach (var dll in mydll)
            {

                var args = @" /if {0} 	   /nologo";
                var outPut = _commandExecuter.ExecuteCommand(@"C:\RepomComponentsNET\GACUTIL 4.0\gacutil.exe", args);

            }

            callback(true);


        }

        public void Install(MyDll mydll, Action<bool> callback)
        {
            throw new NotImplementedException();
        }

        public void Install(List<string> dlls, Action<bool, string> callback, Action done)
        {


            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;


                foreach (var dll in dlls)
                {

                    var dllPatch = Path.Combine(GetTargetDirectory, dll + ".dll");

                    var commandArgs = $" /if {dllPatch}	   /nologo";
                    var outPut = _commandExecuter.ExecuteCommand(@"C:\RepomComponentsNET\GACUTIL 4.0\gacutil.exe", commandArgs);

                    var population = new Tuple<string, bool>(dll, outPut.IndexOf("Failure") == -1);

                    b.ReportProgress(0, population);

                }

                done();




            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {

                var rest = (Tuple<string, bool>)args.UserState;
                callback(rest.Item2, rest.Item1);

            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {

            });

            bw.RunWorkerAsync();

        }

        public void Unstall(MyDll mydll, Action<bool> callback)
        {
            throw new NotImplementedException();
        }

        public void Unstall(List<string> dlls, Action<bool, string> callback, Action done)
        {


            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;


                foreach (var dll in dlls)
                {

                    var commandArgs = $" /uf {dll}	   /nologo";
                    var outPut = _commandExecuter.ExecuteCommand(@"C:\RepomComponentsNET\GACUTIL 4.0\gacutil.exe", commandArgs);

                    var population = new Tuple<string, bool>(dll, outPut.IndexOf("Failure") == -1);

                    b.ReportProgress(0, population);

                }

                done();




            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {

                var rest = (Tuple<string, bool>)args.UserState;
                callback(rest.Item2, rest.Item1);

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
