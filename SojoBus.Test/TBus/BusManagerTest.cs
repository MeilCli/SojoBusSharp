using SojoBus.Core.TBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SojoBus.Test.TBus {
    class BusManagerTest {

        private BusManager busManager = new BusManager();

        public BusManagerTest() { }

        public void Test() {
            foreach(var bus in busManager.GetKandaiFromTonda(new DateTime(2016,4,1),-1)) {
                Console.Out.WriteLine(bus.ToString());
            }
        }
    }
}
