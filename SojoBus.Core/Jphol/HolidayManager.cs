using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SojoBus.Core.Jphol {
    public class HolidayManager {
        public List<IHoliday> HolidayList { get; }

        public HolidayManager() {
            this.HolidayList = make();
        }

        public bool IsHoliday(int year,int month,int day) => IsHoliday(new DateTime(year,month,day));

        public bool IsHoliday(DateTime date) => GetHoliday(date) != null;

        public List<IHoliday> GetHoliday(int year,int month,int day) => GetHoliday(new DateTime(year,month,day));

        public List<IHoliday> GetHoliday(DateTime date) {
            int year = date.Year;
            {
                List<IHoliday> r = this.HolidayList.Where(x => x.MatchDay(date)).ToList();
                if(isMakeUpHoliday(date,r))
                    r.Add(new Holiday("振替休日",HolidayType.MakeUpHoliday));
                if(r.Count > 0)
                    return r;
            }
            {
                //国民の祝日に挟まれていたら休日
                DateTime c1 = date.AddDays(1);
                DateTime c2 = date.AddDays(-1);
                if(this.HolidayList.Any(x => x.Type == HolidayType.NationalHoliday && x.MatchDay(c1))
                    && this.HolidayList.Any(x => x.Type == HolidayType.NationalHoliday && x.MatchDay(c2)))
                    return new List<IHoliday>() { new Holiday("国民の休日",HolidayType.Holiday) };
            }
            if(isMakeUpHoliday(date,null))
                return new List<IHoliday>() { new Holiday("振替休日",HolidayType.MakeUpHoliday) };
            return null;
        }

        private bool isMakeUpHoliday(DateTime date,List<IHoliday> holiday) {
            if(holiday?.Any(x => x.Type == HolidayType.NationalHoliday) ?? false)
                return false;
            if(IsSunday(date))
                return false;
            for(int i = 1;i <= (int)date.DayOfWeek;i++) {
                date = date.AddDays(-1);
                if(this.HolidayList.Where(x => x.MatchDay(date)).All(x => x.Type != HolidayType.NationalHoliday))
                    return false;
            }
            return true;
        }

        public bool IsSunday(DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;

        public bool IsSaturday(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;

        private List<IHoliday> make() {
            var list = new List<IHoliday>();
            int dayOfWeek2 = (int)DayOfWeek.Monday;
            {
                list.Add(new DayOfMonthHoliday("元旦",HolidayType.NationalHoliday,1,1));
                list.Add(new DayOfWeekHoliday("成人の日",HolidayType.NationalHoliday,1,2,dayOfWeek2));
                list.Add(new DayOfMonthHoliday("建国記念の日",HolidayType.NationalHoliday,2,11));
                {
                    //https://ja.wikipedia.org/wiki/%E6%98%A5%E5%88%86
                    //1992~2023
                    var data1 = new YearHoliday.YearData(Enumerable.Range(1992,32).ToList(),3,new int[] { 20,20,21,21 });
                    //2023~2055
                    var data2 = new YearHoliday.YearData(Enumerable.Range(2023,32).ToList(),3,new int[] { 20,20,20,21 });
                    list.Add(new YearHoliday("春分の日",HolidayType.NationalHoliday,new YearHoliday.YearData[] { data1,data2 }));
                }
                list.Add(new DayOfMonthHoliday("昭和の日",HolidayType.NationalHoliday,4,29));
                list.Add(new DayOfMonthHoliday("憲法記念日",HolidayType.NationalHoliday,5,3));
                list.Add(new DayOfMonthHoliday("みどりの日",HolidayType.NationalHoliday,5,4));
                list.Add(new DayOfMonthHoliday("こどもの日",HolidayType.NationalHoliday,5,5));
                list.Add(new DayOfWeekHoliday("海の日",HolidayType.NationalHoliday,7,3,dayOfWeek2));
                list.Add(new DayOfMonthHoliday("山の日",HolidayType.NationalHoliday,8,11));
                list.Add(new DayOfWeekHoliday("敬老の日",HolidayType.NationalHoliday,9,3,dayOfWeek2));
                {
                    //https://ja.wikipedia.org/wiki/%E7%A7%8B%E5%88%86
                    //2012~2043
                    var data1 = new YearHoliday.YearData(Enumerable.Range(2012,32).ToList(),9,new int[] { 22,23,23,23 });
                    list.Add(new YearHoliday("秋分の日",HolidayType.NationalHoliday,new YearHoliday.YearData[] { data1 }));
                }
                list.Add(new DayOfWeekHoliday("体育の日",HolidayType.NationalHoliday,10,2,dayOfWeek2));
                list.Add(new DayOfMonthHoliday("文化の日",HolidayType.NationalHoliday,11,3));
                list.Add(new DayOfMonthHoliday("勤労感謝の日",HolidayType.NationalHoliday,11,23));
                list.Add(new DayOfMonthHoliday("天皇誕生日",HolidayType.NationalHoliday,12,23));
            }
            {
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,1,1));
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,1,2));
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,1,3));
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,12,29));
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,12,30));
                list.Add(new DayOfMonthHoliday("公共団体の休日",HolidayType.Holiday,12,31));
            }
            return list;
        }
    }
}
