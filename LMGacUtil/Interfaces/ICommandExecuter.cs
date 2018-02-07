using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Interfaces
{

    public interface ICommandExecuter
    {

        void AddUpdateObserver(ICommandExecuterObserver observer);
        void RemoveUpdateObserver(ICommandExecuterObserver observer);
        void ExecuteCommand(string FileName, string srguments, Action<string> callback);

    }

}
