using System;
using System.Collections.Generic;
using System.Text;

namespace SojoBus.Core.Jphol {
    public interface IHoliday {
        string DayName { get; }
        HolidayType Type { get; }

        bool MatchDay(DateTime date);
    }
}
