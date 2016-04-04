using SojoBus.Core.TBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.Core.Model {
    public class BusModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        private static  BusManager busManager = new BusManager();

        public List<Bus> Bus { private set; get; } = new List<Bus>();
        public bool IsSundayOrHoliday { private set; get; }
        public bool IsSaturday { private set; get; }
        public bool IsWeekday { private set; get; }
        public bool IsGakki { private set; get; }

        public BusModel() {}

        public void LoadDay(DateTime date) {
            this.IsSundayOrHoliday = busManager.IsSunday(date) || busManager.IsHoliday(date);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsSundayOrHoliday)));
            this.IsSaturday = busManager.IsSaturday(date);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsSaturday)));
            this.IsWeekday = this.IsSundayOrHoliday == false && this.IsSaturday == false;
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsWeekday)));
            this.IsGakki = busManager.IsGakki(date);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsGakki)));
        }

        public void LoadToKandaiFromTakatuki(DateTime date,int take = -1) {
            this.Bus = busManager.GetKandaiFromTakatuki(date,take);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Bus)));
        }

        public void LoadToKandaiFromTonda(DateTime date,int take = -1) {
            this.Bus = busManager.GetKandaiFromTonda(date,take);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Bus)));
        }

        public void LoadToTakatukiFromKandai(DateTime date,int take = -1) {
            this.Bus = busManager.GetTakatukiFromRapyuta(date,take);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Bus)));
        }

        public void LoadToTondaFromKandai(DateTime date,int take = -1) {
            this.Bus = busManager.GetTondaFromRapyuta(date,take);
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Bus)));
        }

    }
}
