using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SojoBus.Test.Jphol;
using SojoBus.Test.TBus;

namespace SojoBus.Test {
    class Program {
        static void Main(string[] args) {
            Console.Out.WriteLine("Start");
            new HolidayManagerTest().Test();
            new BusManagerTest().Test();
            Console.Out.WriteLine("End");
        }
    }
}
