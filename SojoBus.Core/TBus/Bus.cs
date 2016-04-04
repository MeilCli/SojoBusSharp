using System;
using System.Collections.Generic;
using System.Text;

namespace SojoBus.Core.TBus {
    /*
    2002wt -> 20:02 平日 高槻行き
    平日:w
    土曜:d
    日曜:n
    高槻行き:t
    富田行き:s
    関西大学行き:r
    萩谷行き;h
    萩谷総合公園行き:k
    学期運行:g
    学休運行:y
    直行:e
    富田経由:v
     */
    public class Bus {

        public bool IsWeekday { get; }
        public bool IsSunday { get; }
        public bool IsSaturday { get; }
        public BusType Type { get; }
        public int Time { get; }

        public Bus(string text) {
            if(text.Length < 6)
                return;
            this.Time = int.Parse(text.Substring(0,4));
            foreach(char c in text.Substring(4).ToCharArray()) {
                switch(c) {
                    case 'w':
                        this.IsWeekday = true;
                        break;
                    case 'd':
                        this.IsSaturday = true;
                        break;
                    case 'n':
                        this.IsSunday = true;
                        break;
                    case 't':
                        this.Type = this.Type | BusType.ToTakatuki;
                        break;
                    case 's':
                        this.Type = this.Type | BusType.ToTonda;
                        break;
                    case 'r':
                        this.Type = this.Type | BusType.ToRapyuta;
                        break;
                    case 'h':
                        this.Type = this.Type | BusType.ToHagitani;
                        break;
                    case 'k':
                        this.Type = this.Type | BusType.ToHagitaniKouen;
                        break;
                    case 'g':
                        this.Type = this.Type | BusType.IsGakki;
                        break;
                    case 'y':
                        this.Type = this.Type | BusType.IsYasumi;
                        break;
                    case 'e':
                        this.Type = this.Type | BusType.IsTyokkou;
                        break;
                    case 'v':
                        this.Type = this.Type | BusType.ViaTonda;
                        break;
                }
            }
        }

        public override string ToString() {
            string s = $"{this.Time / 100}:{this.Time % 100} ";
            if((this.Type & BusType.ViaTonda) == BusType.ViaTonda) {
                s += "JR富田駅経由";
            }
            if((this.Type & BusType.ToRapyuta) == BusType.ToRapyuta)
                s += "関西大学行き";
            if((this.Type & BusType.ToHagitani) == BusType.ToHagitani)
                s += "萩谷行き";
            if((this.Type & BusType.ToHagitaniKouen) == BusType.ToHagitaniKouen)
                s += "萩谷総合公園行き";
            if((this.Type & BusType.ToTakatuki) == BusType.ToTakatuki)
                s += "JR高槻駅北行き";
            if((this.Type & BusType.ToTonda) == BusType.ToTonda)
                s += "JR富田駅行き";
            if((this.Type & BusType.IsTyokkou) == BusType.IsTyokkou) {
                s += "直行";
            }
            return s;
        }

        internal static List<Bus> GetTakatukiKita() {
            var list = new List<Bus>();
            list.Add(new Bus("0635wr"));
            list.Add(new Bus("0723wr"));
            list.Add(new Bus("0755wr"));
            list.Add(new Bus("0800dr"));
            list.Add(new Bus("0805nr"));
            list.Add(new Bus("0808wr"));
            list.Add(new Bus("0813wrg"));
            list.Add(new Bus("0814dr"));
            list.Add(new Bus("0818wrg"));
            list.Add(new Bus("0822wr"));
            list.Add(new Bus("0826wrge"));
            list.Add(new Bus("0828dr"));
            list.Add(new Bus("0829wrge"));
            list.Add(new Bus("0832wrge"));
            list.Add(new Bus("0833nr"));
            list.Add(new Bus("0835wr"));
            list.Add(new Bus("0840wrge"));
            list.Add(new Bus("0844dr"));
            list.Add(new Bus("0845wrg"));
            list.Add(new Bus("0850nr"));
            list.Add(new Bus("0855wr"));
            list.Add(new Bus("0902dr"));
            list.Add(new Bus("0910nr"));
            list.Add(new Bus("0915wr"));
            list.Add(new Bus("0920dr"));
            list.Add(new Bus("0925wrg"));
            list.Add(new Bus("0935wr"));
            list.Add(new Bus("0938dr"));
            list.Add(new Bus("0940nr"));
            list.Add(new Bus("0947wrg"));
            list.Add(new Bus("0955wdr"));
            list.Add(new Bus("1000wrg"));
            list.Add(new Bus("1005wrge"));
            list.Add(new Bus("1010wrg"));
            list.Add(new Bus("1010dnr"));
            list.Add(new Bus("1015wr"));
            list.Add(new Bus("1025wrg"));
            list.Add(new Bus("1030dr"));
            list.Add(new Bus("1035wr"));
            list.Add(new Bus("1040nr"));
            list.Add(new Bus("1043wrg"));
            list.Add(new Bus("1050dr"));
            list.Add(new Bus("1055wr"));
            list.Add(new Bus("1110dnr"));
            list.Add(new Bus("1115wr"));
            list.Add(new Bus("1130dr"));
            list.Add(new Bus("1135wr"));
            list.Add(new Bus("1140nr"));
            list.Add(new Bus("1150wdr"));
            list.Add(new Bus("1205wr"));
            list.Add(new Bus("1210dnr"));
            list.Add(new Bus("1220wr"));
            list.Add(new Bus("1230wdr"));
            list.Add(new Bus("1235wrg"));
            list.Add(new Bus("1240nr"));
            list.Add(new Bus("1250wdr"));
            list.Add(new Bus("1310wdnr"));
            list.Add(new Bus("1330dr"));
            list.Add(new Bus("1335wr"));
            list.Add(new Bus("1340nr"));
            list.Add(new Bus("1350wdr"));
            list.Add(new Bus("1405wr"));
            list.Add(new Bus("1410dnr"));
            list.Add(new Bus("1420wr"));
            list.Add(new Bus("1430dr"));
            list.Add(new Bus("1440wnr"));
            list.Add(new Bus("1450dr"));
            list.Add(new Bus("1505wr"));
            list.Add(new Bus("1510dnr"));
            list.Add(new Bus("1520wr"));
            list.Add(new Bus("1530dr"));
            list.Add(new Bus("1535wr"));
            list.Add(new Bus("1540nr"));
            list.Add(new Bus("1550wdr"));
            list.Add(new Bus("1605wr"));
            list.Add(new Bus("1610dnr"));
            list.Add(new Bus("1620wr"));
            list.Add(new Bus("1630dr"));
            list.Add(new Bus("1635wr"));
            list.Add(new Bus("1640nr"));
            list.Add(new Bus("1650wdr"));
            list.Add(new Bus("1705wr"));
            list.Add(new Bus("1710dnr"));
            list.Add(new Bus("1720wr"));
            list.Add(new Bus("1730dr"));
            list.Add(new Bus("1735wr"));
            list.Add(new Bus("1750wdr"));
            list.Add(new Bus("1805wr"));
            list.Add(new Bus("1820wr"));
            list.Add(new Bus("1835wr"));
            list.Add(new Bus("1850wr"));
            list.Add(new Bus("1905wr"));
            list.Add(new Bus("1920wr"));
            list.Add(new Bus("1935wr"));
            list.Add(new Bus("1950wr"));
            list.Add(new Bus("2010wr"));
            list.Add(new Bus("2030wr"));
            list.Add(new Bus("2050wr"));
            list.Add(new Bus("2100dr"));
            list.Add(new Bus("2120wr"));
            list.Add(new Bus("2150wr"));
            list.Add(new Bus("2301wr"));
            return list;
        }

        internal static List<Bus> GetTonda() {
            var list = new List<Bus>();
            list.Add(new Bus("0620wh"));
            list.Add(new Bus("0623dh"));
            list.Add(new Bus("0703wh"));
            list.Add(new Bus("0705dnh"));
            list.Add(new Bus("0729wdh"));
            list.Add(new Bus("0810nk"));
            list.Add(new Bus("0820wr"));
            list.Add(new Bus("0825wrg"));
            list.Add(new Bus("0830dk"));
            list.Add(new Bus("0831wh"));
            list.Add(new Bus("0834wrg"));
            list.Add(new Bus("0838wrg"));
            list.Add(new Bus("0905dnh"));
            list.Add(new Bus("0935wk"));
            list.Add(new Bus("0955wr"));
            list.Add(new Bus("0955nk"));
            list.Add(new Bus("1005dh"));
            list.Add(new Bus("1010wrg"));
            list.Add(new Bus("1022wh"));
            list.Add(new Bus("1055nh"));
            list.Add(new Bus("1110wr"));
            list.Add(new Bus("1112dk"));
            list.Add(new Bus("1148nh"));
            list.Add(new Bus("1156wh"));
            list.Add(new Bus("1201dh"));
            list.Add(new Bus("1225dr"));
            list.Add(new Bus("1230wk"));
            list.Add(new Bus("1255nh"));
            list.Add(new Bus("1302wh"));
            list.Add(new Bus("1307dh"));
            list.Add(new Bus("1322wr"));
            list.Add(new Bus("1330nk"));
            list.Add(new Bus("1358wh"));
            list.Add(new Bus("1400nh"));
            list.Add(new Bus("1407dk"));        
            list.Add(new Bus("1415wr"));
            list.Add(new Bus("1439dh"));
            list.Add(new Bus("1445wk"));
            list.Add(new Bus("1507dr"));
            list.Add(new Bus("1510wnh"));
            list.Add(new Bus("1547dh"));
            list.Add(new Bus("1558wh"));
            list.Add(new Bus("1621dnh"));
            list.Add(new Bus("1645wr"));
            list.Add(new Bus("1718wh"));
            list.Add(new Bus("1730dnh"));
            list.Add(new Bus("1738wr"));
            list.Add(new Bus("1805wr"));
            list.Add(new Bus("1840wh"));
            list.Add(new Bus("1850nh"));
            list.Add(new Bus("1855dh"));
            list.Add(new Bus("1905wr"));
            list.Add(new Bus("1935wh"));
            list.Add(new Bus("1959nh"));
            list.Add(new Bus("2009dh"));
            list.Add(new Bus("2045wr"));
            list.Add(new Bus("2121nh"));
            list.Add(new Bus("2127dh"));
            list.Add(new Bus("2150wh"));
            return list;
        }

        internal static List<Bus> GetKansaiDaigaku() {
            var list = new List<Bus>();
            list.Add(new Bus("0635ws"));
            list.Add(new Bus("0701ws"));
            list.Add(new Bus("0704wt"));
            list.Add(new Bus("0704ds"));
            list.Add(new Bus("0733wt"));
            list.Add(new Bus("0744ws"));
            list.Add(new Bus("0746dntv"));
            list.Add(new Bus("0749dt"));
            list.Add(new Bus("0759nt"));
            list.Add(new Bus("0803wt"));
            list.Add(new Bus("0810wds"));
            list.Add(new Bus("0819dt"));
            list.Add(new Bus("0839dt"));
            list.Add(new Bus("0841nt"));
            list.Add(new Bus("0848wt"));
            list.Add(new Bus("0858dt"));
            list.Add(new Bus("0905wsg"));
            list.Add(new Bus("0909nt"));
            list.Add(new Bus("0913wt"));
            list.Add(new Bus("0914ds"));
            list.Add(new Bus("0917dt"));
            list.Add(new Bus("0918wtv"));
            list.Add(new Bus("0928wt"));
            list.Add(new Bus("0930wsg"));
            list.Add(new Bus("0937dt"));
            list.Add(new Bus("0941nt"));
            list.Add(new Bus("0945ws"));
            list.Add(new Bus("0948dntv"));
            list.Add(new Bus("0957dt"));
            list.Add(new Bus("1004wt"));
            list.Add(new Bus("1011nt"));
            list.Add(new Bus("1017dt"));
            list.Add(new Bus("1027ns"));
            list.Add(new Bus("1023wt"));
            list.Add(new Bus("1037dt"));
            list.Add(new Bus("1040ws"));
            list.Add(new Bus("1041nt"));
            list.Add(new Bus("1042wt"));
            list.Add(new Bus("1048ds"));
            list.Add(new Bus("1057dt"));
            list.Add(new Bus("1103wt"));
            list.Add(new Bus("1103wtv"));
            list.Add(new Bus("1111nt"));
            list.Add(new Bus("1117dt"));
            list.Add(new Bus("1119wt"));
            list.Add(new Bus("1135wt"));
            list.Add(new Bus("1137dt"));
            list.Add(new Bus("1137ns"));
            list.Add(new Bus("1140ws"));
            list.Add(new Bus("1141nt"));
            list.Add(new Bus("1149ds"));
            list.Add(new Bus("1151wt"));
            list.Add(new Bus("1157dt"));
            list.Add(new Bus("1210wt"));
            list.Add(new Bus("1211nt"));
            list.Add(new Bus("1217dt"));
            list.Add(new Bus("1220wtg"));
            list.Add(new Bus("1229ns"));
            list.Add(new Bus("1230wt"));
            list.Add(new Bus("1237dt"));
            list.Add(new Bus("1239ws"));
            list.Add(new Bus("1240wtg"));
            list.Add(new Bus("1241nt"));
            list.Add(new Bus("1242ds"));
            list.Add(new Bus("1250wt"));
            list.Add(new Bus("1257dt"));
            list.Add(new Bus("1304wt"));
            list.Add(new Bus("1307ws"));
            list.Add(new Bus("1311nt"));
            list.Add(new Bus("1317dt"));
            list.Add(new Bus("1324wt"));
            list.Add(new Bus("1337dt"));
            list.Add(new Bus("1337ns"));
            list.Add(new Bus("1341nt"));
            list.Add(new Bus("1343ws"));
            list.Add(new Bus("1344wt"));
            list.Add(new Bus("1348ds"));
            list.Add(new Bus("1357dt"));
            list.Add(new Bus("1404wt"));
            list.Add(new Bus("1411nt"));
            list.Add(new Bus("1417dt"));
            list.Add(new Bus("1424wt"));
            list.Add(new Bus("1437wdt"));
            list.Add(new Bus("1439ds"));
            list.Add(new Bus("1441wtg"));
            list.Add(new Bus("1441nt"));
            list.Add(new Bus("1441ws"));
            list.Add(new Bus("1445wtg"));
            list.Add(new Bus("1446ns"));
            list.Add(new Bus("1450wt"));
            list.Add(new Bus("1457dt"));
            list.Add(new Bus("1509wt"));
            list.Add(new Bus("1511nt"));
            list.Add(new Bus("1517dt"));
            list.Add(new Bus("1520ws"));
            list.Add(new Bus("1522ds"));
            list.Add(new Bus("1535ds"));
            list.Add(new Bus("1536wtg"));
            list.Add(new Bus("1537dt"));
            list.Add(new Bus("1541nt"));
            list.Add(new Bus("1551wt"));
            list.Add(new Bus("1551ns"));
            list.Add(new Bus("1557dt"));
            list.Add(new Bus("1610wtge"));
            list.Add(new Bus("1611nt"));
            list.Add(new Bus("1615wt"));
            list.Add(new Bus("1617dt"));
            list.Add(new Bus("1620wtg"));
            list.Add(new Bus("1624wtg"));
            list.Add(new Bus("1625wsg"));
            list.Add(new Bus("1628wtg"));
            list.Add(new Bus("1628dtv"));
            list.Add(new Bus("1631wtv"));
            list.Add(new Bus("1636wt"));
            list.Add(new Bus("1637dt"));
            list.Add(new Bus("1641nt"));
            list.Add(new Bus("1649wtv"));
            list.Add(new Bus("1651wt"));
            list.Add(new Bus("1657dt"));
            list.Add(new Bus("1702dntv"));
            list.Add(new Bus("1705wt"));
            list.Add(new Bus("1710ws"));
            list.Add(new Bus("1711nt"));
            list.Add(new Bus("1715wtg"));
            list.Add(new Bus("1717dt"));
            list.Add(new Bus("1725wt"));
            list.Add(new Bus("1729ds"));
            list.Add(new Bus("1737dt"));
            list.Add(new Bus("1738ws"));
            list.Add(new Bus("1743wt"));
            list.Add(new Bus("1749ns"));
            list.Add(new Bus("1755wtge"));
            list.Add(new Bus("1757dt"));
            list.Add(new Bus("1759wt"));
            list.Add(new Bus("1801ws"));
            list.Add(new Bus("1803wtg"));
            list.Add(new Bus("1808wtg"));
            list.Add(new Bus("1810ws"));
            list.Add(new Bus("1812ds"));
            list.Add(new Bus("1813ntv"));
            list.Add(new Bus("1814wt"));
            list.Add(new Bus("1830ws"));
            list.Add(new Bus("1834wt"));
            list.Add(new Bus("1850wt"));
            list.Add(new Bus("1910wt"));
            list.Add(new Bus("1931ns"));
            list.Add(new Bus("1936ws"));
            list.Add(new Bus("1940wt"));
            list.Add(new Bus("1941ds"));
            list.Add(new Bus("1944dt"));
            list.Add(new Bus("1945wsg"));
            list.Add(new Bus("1955wt"));
            list.Add(new Bus("2010wt"));
            list.Add(new Bus("2016ws"));
            list.Add(new Bus("2035wt"));
            list.Add(new Bus("2040ns"));
            list.Add(new Bus("2045wsg"));
            list.Add(new Bus("2051ds"));
            list.Add(new Bus("2120wt"));
            list.Add(new Bus("2130dt"));
            list.Add(new Bus("2130ws"));
            list.Add(new Bus("2149wt"));
            list.Add(new Bus("2202ns"));
            list.Add(new Bus("2208ds"));
            list.Add(new Bus("2219wt"));
            list.Add(new Bus("2231ws"));
            return list;
        }
    }
}
