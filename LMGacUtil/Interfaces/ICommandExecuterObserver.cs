using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Interfaces
{
    public interface ICommandExecuterObserver
    {

        void Update(string text);
        void Done();
    }

}
