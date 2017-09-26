using System;

namespace WeatherApp.Models
{
    public class WeatherDataValuesModel
    {
        public DateTime Time_Stamp { get; set; }
        public object Record { get; set; }
        public object T1_Avg { get; set; }
        public object T2_Avg { get; set; }
        public object T1_Asp_Avg { get; set; }
        public object RH1 { get; set; }
        public object RH2 { get; set; }
        public object U1_Avg { get; set; }
        public object U2_Avg { get; set; }
        public object UDir1 { get; set; }
        public object UDir2 { get; set; }
        public object U1_Max { get; set; }
        public object U2_Max { get; set; }
        public object P_mb_Avg { get; set; }
        public object PPN_mm_Tot { get; set; }
        public object TC1_Avg { get; set; }
        public object SoilW1_Avg { get; set; }
        public object SoilW2_Avg { get; set; }
        public object SoilW3_Avg { get; set; }
        public object SW_UP_Avg { get; set; }
        public object SW_Down_Avg { get; set; }
        public object LW_UP_Avg { get; set; }
        public object LW_Down_Avg { get; set; }
        public object CNR1TC_Avg { get; set; }
        public object CNR1TK_Avg { get; set; }
        public object NetSW_Avg { get; set; }
        public object NetLW_Avg { get; set; }
        public object Albedo_Avg { get; set; }
        public object UpTot_Avg { get; set; }
        public object DnTot_Avg { get; set; }
        public object NetTot_Avg { get; set; }
        public object CG3UpCo_Avg { get; set; }
        public object CG3DnCo_Avg { get; set; }
        public object Batt_Volt_Avg { get; set; }
        public object T_Panel_Avg { get; set; }
    }
}
