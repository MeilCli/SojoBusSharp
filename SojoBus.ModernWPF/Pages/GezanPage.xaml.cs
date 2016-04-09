using SojoBus.Core.ViewModel;
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

namespace SojoBus.ModernWPF {
    /// <summary>
    /// Interaction logic for GezanPage.xaml
    /// </summary>
    public partial class GezanPage : UserControl {

        private BusViewModel busViewModel = new BusViewModel();

        public GezanPage() {
            InitializeComponent();
            takatuki.DataContext = busViewModel;
            tonda.DataContext = busViewModel;
            load();
        }

        private void load() {
            busViewModel.LoadToTakatukiFromKandai.Execute();
            busViewModel.LoadToTondaFromKandai.Execute();
        }
    }
}
