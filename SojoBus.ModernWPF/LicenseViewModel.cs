using SojoBus.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.ModernWPF {
    public class LicenseViewModel :Core.ViewModel.LicenseViewModel{

        public LicenseViewModel() : base() { }

        public override List<LicenseModel> InitLicense() {
            var list = base.InitLicense();
            list.Add(new LicenseModel("ModernUI.WPF","https://github.com/firstfloorsoftware/mui/blob/master/LICENSE.md"));
            return list;
        }
    }
}
