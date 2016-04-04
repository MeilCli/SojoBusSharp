using System;
using System.Collections.Generic;
using System.Text;

namespace SojoBus.Core.TBus {
    [Flags]
    public enum BusType {
        ToTakatuki = 1,
        ToTonda = 2,
        ToRapyuta = 4,
        ToHagitani = 8,
        ToHagitaniKouen = 16,
        IsGakki = 32,
        IsYasumi = 64,
        IsTyokkou = 128,
        ViaTonda = 256
    }
}
