using SojoBus.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings.Extensions;
using Reactive.Bindings;

namespace SojoBus.Core.ViewModel {
    public class LicenseViewModel {

        private List<LicenseModel> license { get; }
        public ReadOnlyReactiveProperty<string> License { get; }

        public LicenseViewModel() {
            license = InitLicense();
            var text = "Use Libraries\n\n\n";
            text += string.Join("\n\n\n",license.Select(x => x.Text));
            this.License = new ReactiveProperty<string>(text).ToReadOnlyReactiveProperty();
        }

        public virtual List<LicenseModel> InitLicense() {
            var list = new List<LicenseModel>();
            list.Add(new LicenseModel("Reactive Extensions","https://msdn.microsoft.com/en-us/hh295787","https://rx.codeplex.com/license"));
            list.Add(new LicenseModel("ReactiveProperty","https://github.com/runceel/ReactiveProperty/blob/master/LICENSE.txt"));
            return list;
        }
    }
}
