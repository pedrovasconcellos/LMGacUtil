using LMGacUtil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMGacUtil.CustomControl;

namespace LMGacUtil.Interfaces
{
    public interface IDirectoryHelper
    {

        List<MyDll> GetDlls(string filter);
        void FillDll(IGacDllEntity mylist, string filter, Action calback);
        void GetDlls(string filter, Action<List<MyDll>> calback);
    }
}
