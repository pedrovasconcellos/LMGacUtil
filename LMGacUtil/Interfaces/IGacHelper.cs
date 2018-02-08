using LMGacUtil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Interfaces
{
    public interface IGacHelper
    {
        void GacLisat(MyDll mydll);
        void Install(MyDll mydll, Action<bool> callback);
        void Unstall(MyDll mydll, Action<bool> callback);
        void Install(List<String> dlls, Action<bool, string> callback, Action done);
        void Unstall(List<String> dlls, Action<bool, string> callback, Action done);

    }

}
