using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SojoBus.Core.Jphol {
    abstract class AbsHoliday : IHoliday {

        public AbsHoliday(string dayName,HolidayType type) {
            this.DayName = dayName;
            this.Type = type;
        }

        public string DayName { get; }

        public HolidayType Type { get; }

        public abstract bool MatchDay(DateTime date);
    }

    class Holiday : AbsHoliday {

        public Holiday(string dayName,HolidayType type) : base(dayName,type) { }

        public override bool MatchDay(DateTime date) {
            throw new NotImplementedException();
        }
    }

    class YearHoliday : AbsHoliday {

        public class YearData {

            public List<int> Yeays { get; }
            public int Month { get; }
            public int[] DayInYearOfSurplus { get; }

            public YearData(List<int> years,int month,int[] dayInYearOfSurplus) {
                this.Yeays = years;
                this.Month = month;
                this.DayInYearOfSurplus = dayInYearOfSurplus;
            }
        }

        public YearData[] Data { get; }

        public YearHoliday(string dayName,HolidayType type,YearData[] data) : base(dayName,type) {
            this.Data = data;
        }

        public override bool MatchDay(DateTime date) {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            if(this.Data.All(x => x.Yeays.Contains(year) == false))
                return false;
            YearData data = this.Data.Single(x => x.Yeays.Contains(year));
            if(month != data.Month)
                return false;
            return data.DayInYearOfSurplus[year % data.DayInYearOfSurplus.Length] == day;
        }
    }

    class DayOfWeekHoliday : AbsHoliday {

        public int Month { get; }
        public int DayOfWeek { get; }
        public int DayOfWeekInMonth { get; }

        public DayOfWeekHoliday(string dayName,HolidayType type,int month,int dayOfWeekInMonth,int dayOfWeek) : base(dayName,type) {
            this.Month = month;
            this.DayOfWeek = dayOfWeek;
            this.DayOfWeekInMonth = dayOfWeekInMonth;
        }

        public override bool MatchDay(DateTime date) {
            int month = date.Month;
            int dayOfWeek = (int)date.DayOfWeek;
            int dayOfWeekInMonth = (date.Day - dayOfWeek) / 7 + 1;
            return month == this.Month && dayOfWeek == this.DayOfWeek && dayOfWeekInMonth == this.DayOfWeekInMonth;
        }
    }

    class DayOfMonthHoliday : AbsHoliday {

        public int Month { get; }
        public int Day { get; }

        public DayOfMonthHoliday(string dayName,HolidayType type,int month,int day) : base(dayName,type) {
            this.Month = month;
            this.Day = day;
        }

        public override bool MatchDay(DateTime date)
            => date.Month == this.Month && date.Day == this.Day;
    }
}
