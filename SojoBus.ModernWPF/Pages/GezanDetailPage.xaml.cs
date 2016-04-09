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
    /// Interaction logic for GezanDetailPage.xaml
    /// </summary>
    public partial class GezanDetailPage : UserControl {

        private BusViewModel busViewModel = new BusViewModel();

        public GezanDetailPage() {
            InitializeComponent();
            takatuki.DataContext = busViewModel;
            tonda.DataContext = busViewModel;
            load();
        }

        private void load() {
            busViewModel.LoadToTakatukiFromKandaiDetail.Execute();
            busViewModel.LoadToTondaFromKandaiDetail.Execute();
        }
    }
}
