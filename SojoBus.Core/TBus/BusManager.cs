using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SojoBus.Core.Jphol;

namespace SojoBus.Core.TBus {
    public class BusManager {

        private HolidayManager holidayManager = new HolidayManager();

        public BusManager() { }


        public List<Bus> GetKandaiFromTakatuki(DateTime date,int take = 3) {
            bool isSundayOrHoliday = IsSunday(date) || IsHoliday(date);
            bool isSaturday = IsSaturday(date);
            bool isGakki = IsGakki(date);
            int time = toTime(date);
            List<Bus> list = Bus.GetTakatukiKita()
                .Where(filterHoliday(isSundayOrHoliday,isSaturday))
                .Where(filterTime(time))
                .Where(x => (x.Type & BusType.ToRapyuta) == BusType.ToRapyuta)
                .Where(filterGakki(isGakki))
                .Where(filterYasumi(isGakki)).ToList();
            if(take != -1)
                list = list.Take(take).ToList();
            return list;
        }

        public List<Bus> GetKandaiFromTonda(DateTime date,int take = 3) {
            bool isSundayOrHoliday = IsSunday(date) || IsHoliday(date);
            bool isSaturday = IsSaturday(date);
            bool isGakki = IsGakki(date);
            int time = toTime(date);
            List<Bus> list = Bus.GetTonda()
                .Where(filterHoliday(isSundayOrHoliday,isSaturday))
                .Where(filterTime(time))
                .Where(x => (x.Type & BusType.ToRapyuta) == BusType.ToRapyuta || (x.Type & BusType.ToHagitani) == BusType.ToHagitani || (x.Type & BusType.ToHagitaniKouen) == BusType.ToHagitaniKouen)
                .Where(filterGakki(isGakki))
                .Where(filterYasumi(isGakki)).ToList();
            if(take != -1)
                list = list.Take(take).ToList();
            return list;
        }

        public List<Bus> GetTakatukiFromRapyuta(DateTime date,int take = 3) {
            bool isSundayOrHoliday = IsSunday(date) || IsHoliday(date);
            bool isSaturday = IsSaturday(date);
            bool isGakki = IsGakki(date);
            int time = toTime(date);
            List<Bus> list = Bus.GetKansaiDaigaku()
                .Where(filterHoliday(isSundayOrHoliday,isSaturday))
                .Where(filterTime(time))
                .Where(x => (x.Type & BusType.ToTakatuki) == BusType.ToTakatuki && (x.Type & BusType.ViaTonda) != BusType.ViaTonda)
                .Where(filterGakki(isGakki))
                .Where(filterYasumi(isGakki)).ToList();
            if(take != -1)
                list = list.Take(take).ToList();
            return list;
        }

        public List<Bus> GetTondaFromRapyuta(DateTime date,int take = 3) {
            bool isSundayOrHoliday = IsSunday(date) || IsHoliday(date);
            bool isSaturday = IsSaturday(date);
            bool isGakki = IsGakki(date);
            int time = toTime(date);
            List<Bus> list = Bus.GetKansaiDaigaku()
                .Where(filterHoliday(isSundayOrHoliday,isSaturday))
                .Where(filterTime(time))
                .Where(x => (x.Type & BusType.ToTonda) == BusType.ToTonda || (x.Type & BusType.ViaTonda) == BusType.ViaTonda)
                .Where(filterGakki(isGakki))
                .Where(filterYasumi(isGakki)).ToList();
            if(take != -1)
                list = list.Take(take).ToList();
            return list;
        }

        private Func<Bus,bool> filterHoliday(bool isSundayOrHoliday,bool isSaturday) {
            return x => {
                if(isSundayOrHoliday)
                    return x.IsSunday;
                else if(isSaturday)
                    return x.IsSaturday;
                else
                    return x.IsWeekday;
            };
        }

        private Func<Bus,bool> filterTime(int time) {
            return x => x.Time >= time;
        }

        private Func<Bus,bool> filterGakki(bool isGakki) {
            return x => {
                if((x.Type & BusType.IsGakki) == BusType.IsGakki && isGakki == false)
                    return false;
                return true;
            };
        }

        private Func<Bus,bool> filterYasumi(bool isGakki) {
            return x => {
                if((x.Type & BusType.IsYasumi) == BusType.IsYasumi && isGakki == true)
                    return false;
                return true;
            };
        }


        private int toTime(DateTime date) => date.Hour * 100 + date.Minute;

        public bool IsHoliday(DateTime date) => holidayManager.IsHoliday(date);

        public bool IsSunday(DateTime date) => holidayManager.IsSunday(date);

        public bool IsSaturday(DateTime date) => holidayManager.IsSaturday(date);

        public bool IsGakki(DateTime date) {
            int month = date.Month;
            int day = date.Day;
            int time = month * 100 + day;
            //28年度版
            if(730 <= time && time <= 920)
                return false;
            if(1225 <= time && time <= 1231)
                return false;
            if(101 <= time && time <= 106)
                return false;
            if(131 <= time && time <= 331)
                return false;
            return true;
        }
    }
}
