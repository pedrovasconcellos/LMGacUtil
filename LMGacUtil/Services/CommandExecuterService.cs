using LMGacUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Services
{
    public class CommandExecuterService : ICommandExecuter
    {
        private List<ICommandExecuterObserver> _observers;

        public CommandExecuterService()
        {

            _observers = new List<ICommandExecuterObserver>();

        }

        private void Update(string output)
        {
            foreach (var observer in _observers)
            {
                observer.Update(output);


            }
        }

        private void Done()
        {
            foreach (var observer in _observers)
            {
                observer.Done();

            }
        }

        public void AddUpdateObserver(ICommandExecuterObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveUpdateObserver(ICommandExecuterObserver observer)
        {
            _observers.Remove(observer);
        }



        public void ExecuteCommand(string FileName, string srguments, Action<string> callback)
        {

            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                b.ReportProgress(0, "Executing " + srguments);

                var output = Execute(FileName, srguments);

                b.ReportProgress(100, output);

            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {
                Update(args.UserState.ToString());
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                Done();
                callback(string.Empty);

            });

            bw.RunWorkerAsync();
        }

        public string ExecuteCommand(string FileName, string srguments)
        {

            return Execute(FileName, srguments);

        }

        private string Execute(string FileName, string srguments)
        {

            Update(srguments);

            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = FileName;
            p.StartInfo.Arguments = srguments;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Update(output);

            return output;

        }


    }
}
