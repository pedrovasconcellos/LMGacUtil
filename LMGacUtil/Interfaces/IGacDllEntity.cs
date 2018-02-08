using LMGacUtil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Interfaces
{

    public interface IGacDllEntity
    {
        IEnumerable<MyDll> GetDll { get; }
        void ClearDll();
        void AddDll(MyDll myDll);



    }



}
