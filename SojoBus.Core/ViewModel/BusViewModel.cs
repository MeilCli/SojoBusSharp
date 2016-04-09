using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SojoBus.Core.Model;
using SojoBus.Core.TBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.Core.ViewModel {
    public class BusViewModel {

        private BusModel info = new BusModel();
        private BusModel tonda = new BusModel();
        private BusModel takatuki = new BusModel();
        private BusModel takatukiViaTonda = new BusModel();
        private BusModel tondaDetail = new BusModel();
        private BusModel takatukiDetail = new BusModel();
        private DateTime date {
            get {
                return DateTime.Now;
            }
        }

        private DateTime dateOfStartDay {
            get {
                var d = date.AddHours(-date.Hour);
                d = d.AddMinutes(-date.Minute);
                return d;
            }
        }

        public ReadOnlyReactiveProperty<string> Info { get; }
        public ReactiveCommand LoadInfo { get; }

        public ReadOnlyReactiveProperty<string> Tonda { get; }
        public ReactiveCommand LoadToKandaiFromTonda { get; }
        public ReactiveCommand LoadToTondaFromKandai { get; }


        public ReadOnlyReactiveProperty<string> Takatuki { get; }
        public ReactiveCommand LoadToKanadaiFromTakatuki { get; }
        public ReactiveCommand LoadToTakatukiFromKandai { get; }

        public ReadOnlyReactiveProperty<string> TakatukiViaTonda { get; }
        public ReactiveCommand LoadToKanadaiFromTakatukiViaTonda { get; }

        public ReadOnlyReactiveProperty<string> TondaDetail { get; }
        public ReactiveCommand LoadToKandaiFromTondaDetail { get; }
        public ReactiveCommand LoadToTondaFromKandaiDetail { get; }


        public ReadOnlyReactiveProperty<string> TakatukiDetail { get; }
        public ReactiveCommand LoadToKanadaiFromTakatukiDetail { get; }
        public ReactiveCommand LoadToTakatukiFromKandaiDetail { get; }

        public BusViewModel() {
            var _isSundayOrHoliday = info.ObserveProperty(x => x.IsSundayOrHoliday);
            var _isSaturday = info.ObserveProperty(x => x.IsSaturday);
            var _isWeekday = info.ObserveProperty(x => x.IsWeekday);
            var _isGakki = info.ObserveProperty(x => x.IsGakki);
            this.Info = _isSundayOrHoliday.CombineLatest(_isSaturday,_isWeekday,_isGakki,infoToString).ToReadOnlyReactiveProperty();
            this.LoadInfo = new ReactiveCommand();
            this.LoadInfo.Subscribe(x => info.LoadDay(date));

            this.Tonda = tonda.ObserveProperty(x => x.Bus).Select(busToString).ToReadOnlyReactiveProperty();
            this.LoadToKandaiFromTonda = new ReactiveCommand();
            this.LoadToKandaiFromTonda.Subscribe(x => tonda.LoadToKandaiFromTonda(date,3));
            this.LoadToTondaFromKandai = new ReactiveCommand();
            this.LoadToTondaFromKandai.Subscribe(x => tonda.LoadToTondaFromKandai(date,3));

            this.Takatuki = takatuki.ObserveProperty(x => x.Bus).Select(busToString).ToReadOnlyReactiveProperty();
            this.LoadToKanadaiFromTakatuki = new ReactiveCommand();
            this.LoadToKanadaiFromTakatuki.Subscribe(x => takatuki.LoadToKandaiFromTakatuki(date,3));
            this.LoadToTakatukiFromKandai = new ReactiveCommand();
            this.LoadToTakatukiFromKandai.Subscribe(x => takatuki.LoadToTakatukiFromKandai(date,3));

            this.TakatukiViaTonda = takatukiViaTonda.ObserveProperty(x => x.Bus).Select(dualBusToString).ToReadOnlyReactiveProperty();
            this.LoadToKanadaiFromTakatukiViaTonda = new ReactiveCommand();
            this.LoadToKanadaiFromTakatukiViaTonda.Subscribe(x => takatukiViaTonda.LoadToKandaiFromTakatukiViaTonda(date,6));

            this.TondaDetail = tondaDetail.ObserveProperty(x => x.Bus).Select(busToDetailString).ToReadOnlyReactiveProperty();
            this.LoadToKandaiFromTondaDetail = new ReactiveCommand();
            this.LoadToKandaiFromTondaDetail.Subscribe(x => tondaDetail.LoadToKandaiFromTonda(dateOfStartDay));
            this.LoadToTondaFromKandaiDetail = new ReactiveCommand();
            this.LoadToTondaFromKandaiDetail.Subscribe(x => tondaDetail.LoadToTondaFromKandai(dateOfStartDay));

            this.TakatukiDetail = takatukiDetail.ObserveProperty(x => x.Bus).Select(busToDetailString).ToReadOnlyReactiveProperty();
            this.LoadToKanadaiFromTakatukiDetail = new ReactiveCommand();
            this.LoadToKanadaiFromTakatukiDetail.Subscribe(x => takatukiDetail.LoadToKandaiFromTakatuki(dateOfStartDay));
            this.LoadToTakatukiFromKandaiDetail = new ReactiveCommand();
            this.LoadToTakatukiFromKandaiDetail.Subscribe(x => takatukiDetail.LoadToTakatukiFromKandai(dateOfStartDay));

        }

        private string infoToString(bool isSundayOrHoliday,bool isSaturday,bool isWeekday,bool isGakki) {
            string s = "";
            if(isSundayOrHoliday)
                s += "日曜/祝日";
            if(isSaturday)
                s += "土曜";
            if(isWeekday)
                s += "平日";
            if(isGakki == false)
                s += "(学休期間)";
            return s + "の時刻表";
        }

        private string busToString(List<Bus> bus) {
            var sb = new StringBuilder();
            foreach(var b in bus) {
                sb.Append($"{b.Time / 100:00}:{b.Time % 100:00} ");
                sb.AppendLine();
                if((b.Type & BusType.ViaTonda) == BusType.ViaTonda)
                    sb.Append("JR富田駅経由");
                if((b.Type & BusType.ToRapyuta) == BusType.ToRapyuta)
                    sb.Append("関西大学行き");
                if((b.Type & BusType.ToHagitani) == BusType.ToHagitani)
                    sb.Append("萩谷行き");
                if((b.Type & BusType.ToHagitaniKouen) == BusType.ToHagitaniKouen)
                    sb.Append("萩谷総合公園行き");
                if((b.Type & BusType.ToTakatuki) == BusType.ToTakatuki)
                    sb.Append("JR高槻駅北行き");
                if((b.Type & BusType.ToTonda) == BusType.ToTonda)
                    sb.Append("JR富田駅行き");
                if((b.Type & BusType.IsTyokkou) == BusType.IsTyokkou)
                    sb.Append("直行");
                sb.AppendLine();
                sb.Append('↓');
                sb.AppendLine();
            }
            if(sb.Length > 3) {
                sb.Remove(sb.Length - 3,2);
            }
            if(sb.Length == 0) {
                sb.Append("最終バスの時間を過ぎました");
            }
            return sb.ToString();
        }

        private string dualBusToString(List<Bus> bus) {
            var sb = new StringBuilder();
            bool isFirst = true;
            foreach(var b in bus) {
                sb.Append($"{b.Time / 100:00}:{b.Time % 100:00} ");
                sb.AppendLine();
                if((b.Type & BusType.ViaTonda) == BusType.ViaTonda)
                    sb.Append("JR高槻駅北発JR富田駅経由");
                else
                    sb.Append("JR富田駅発");
                if((b.Type & BusType.ToRapyuta) == BusType.ToRapyuta)
                    sb.Append("関西大学行き");
                if((b.Type & BusType.ToHagitani) == BusType.ToHagitani)
                    sb.Append("萩谷行き");
                if((b.Type & BusType.ToHagitaniKouen) == BusType.ToHagitaniKouen)
                    sb.Append("萩谷総合公園行き");
                if((b.Type & BusType.ToTakatuki) == BusType.ToTakatuki)
                    sb.Append("JR高槻駅北行き");
                if((b.Type & BusType.ToTonda) == BusType.ToTonda)
                    sb.Append("JR富田駅行き");
                if((b.Type & BusType.IsTyokkou) == BusType.IsTyokkou)
                    sb.Append("直行");
                if(isFirst == false) {
                    sb.AppendLine();
                    sb.Append('↓');
                    sb.AppendLine();
                    isFirst = true;
                } else {
                    sb.AppendLine();
                    sb.Append('⇒');
                    sb.AppendLine();
                    isFirst = false;
                }
            }
            if(sb.Length > 3) {
                sb.Remove(sb.Length - 3,2);
            }
            if(sb.Length == 0) {
                sb.Append("最終バスの時間を過ぎました");
            }
            return sb.ToString();
        }

        private string busToDetailString(List<Bus> bus) {
            var sb = new StringBuilder();
            int index = 0;
            Bus b;
            for(int i = 6;i <= 23;i++) {
                sb.Append(i);
                sb.Append("時：");
                while(index < bus.Count) {
                    b = bus[index];
                    if(b.Time / 100 != i) {
                        break;
                    }
                    sb.Append(' ');
                    sb.Append(b.Time % 100);
                    index++;
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
