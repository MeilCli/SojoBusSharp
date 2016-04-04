using SojoBus.Core.Jphol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.Test.Jphol {
    class HolidayManagerTest {

        private HolidayManager manager = new HolidayManager();

        private void checkHoliday(int year,int month,int day,bool condition) {
            if(manager.IsHoliday(year,month,day) != condition) {
                Console.Out.WriteLine($"HolidayError! {year}/{month}/{day}");
                foreach(IHoliday h in manager.GetHoliday(year,month,day)) {
                    Console.Out.WriteLine($"HolidayError! {h.DayName}");
                }
            }
            
        }

        private void checkNationalHoliday(int year,int month,int day,bool condition) {
            if((manager.GetHoliday(year,month,day)?.Any(x => x.Type == HolidayType.NationalHoliday) ?? false) != condition)
                Console.Out.WriteLine($"NationalHolidayError! {year}/{month}/{day}");
        }

        public void Test() {
            //元旦
            checkHoliday(2015,1,1,true);
            checkNationalHoliday(2015,1,1,true);

            //成人の日
            checkHoliday(2015,1,12,true);
            checkNationalHoliday(2015,1,12,true);

            //平日
            checkHoliday(2015,1,15,false);
            checkNationalHoliday(2015,1,15,false);

            checkHoliday(2016,4,4,false);
            checkNationalHoliday(2016,4,4,false);

            checkHoliday(2016,4,5,false);
            checkNationalHoliday(2016,4,5,false);

            //日曜であるが祝日ではない
            checkHoliday(2015,2,1,false);
            checkNationalHoliday(2015,2,1,false);

            //建国記念の日
            checkHoliday(2015,2,11,true);
            checkNationalHoliday(2015,2,11,true);

            //春分の日
            checkHoliday(2015,3,21,true);
            checkNationalHoliday(2015,3,21,true);

            //昭和の日
            checkHoliday(2015,4,29,true);
            checkNationalHoliday(2015,4,29,true);

            //憲法記念日
            checkHoliday(2015,5,3,true);
            checkNationalHoliday(2015,5,3,true);

            //みどりの日
            checkHoliday(2015,5,4,true);
            checkNationalHoliday(2015,5,4,true);

            //こどもの日
            checkHoliday(2015,5,5,true);
            checkNationalHoliday(2015,5,5,true);

            //振替休日
            checkHoliday(2015,5,6,true);
            checkNationalHoliday(2015,5,6,false);

            //海の日
            checkHoliday(2015,7,20,true);
            checkNationalHoliday(2015,7,20,true);

            //山の日
            checkHoliday(2016,8,11,true);
            checkNationalHoliday(2016,8,11,true);

            //敬老の日
            checkHoliday(2015,9,21,true);
            checkNationalHoliday(2015,9,21,true);

            //国民の休日
            checkHoliday(2015,9,22,true);
            checkNationalHoliday(2015,9,22,false);

            //秋分の日
            checkHoliday(2015,9,23,true);
            checkNationalHoliday(2015,9,23,true);

            //体育の日
            checkHoliday(2015,10,12,true);
            checkNationalHoliday(2015,10,12,true);

            //文化の日
            checkHoliday(2015,11,3,true);
            checkNationalHoliday(2015,11,3,true);

            //勤労感謝の日
            checkHoliday(2015,11,23,true);
            checkNationalHoliday(2015,11,23,true);

            //天皇誕生日
            checkHoliday(2015,12,23,true);
            checkNationalHoliday(2015,12,23,true);
        }
    }
}
