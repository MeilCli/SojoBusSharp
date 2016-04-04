using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.Core.Model {
    public class LicenseModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        private string _text;
        public string Text {
            set{
                if(value != _text)
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Text)));
                _text = value;
            }
            get{
                return _text;
            }
        }

        public LicenseModel(string name,params string[] url) {
            string text = name;
            text += "\n\n";
            text += string.Join("\n",url);
            this.Text = text;
        }

    }
}
