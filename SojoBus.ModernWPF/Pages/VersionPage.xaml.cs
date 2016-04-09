using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SojoBus.ModernWPF.Pages {
    /// <summary>
    /// Interaction logic for VersionPage.xaml
    /// </summary>
    public partial class VersionPage : UserControl {
        public VersionPage() {
            InitializeComponent();
            version.Text = Constant.Version;
        }
    }
}
