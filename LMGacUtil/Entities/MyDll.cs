using LMGacUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGacUtil.Entities
{
    public class MyDll : ICloneable
    {
        private List<IMyDllObserver> _observer = new List<IMyDllObserver>();


        public void AddObserver(IMyDllObserver observer)
        {
            _observer.Add(observer);

        }


        private void Update()
        {
            foreach (var x in _observer)
            {
                x.UpdateDll();
            }


        }


        private string _Extension;
        public string Extension
        {
            get
            {
                return _Extension;

            }
            set
            {
                _Extension = value;
                Update();
            }
        }

        private bool _Installed;
        public bool Installed
        {
            get
            {
                return _Installed;

            }
            set
            {
                _Installed = value;
                Update();
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;

            }
            set
            {
                _Name = value;
                Update();
            }
        }

        private string _Patch;
        public string Path
        {
            get
            {
                return _Patch;

            }
            set
            {
                _Patch = value;
                Update();
            }
        }

        private string _PublicKeyToken;
        public string PublicKeyToken
        {
            get
            {
                return _PublicKeyToken;

            }
            set
            {
                _PublicKeyToken = value;
                Update();
            }
        }

        private bool _Checked;
        public bool Checked
        {
            get
            {
                return _Checked;

            }
            set
            {
                _Checked = value;
      
            }
        }

        public object Clone()
        {
            var clone = (MyDll)this.MemberwiseClone();
            return clone;
        }

    }
}
