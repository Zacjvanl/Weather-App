using System;
using System.Threading.Tasks;
using System.Net.Http;
using WeatherApp.Models;
using Newtonsoft.Json;

namespace WeatherApp.Services
{
    public class ApiService
    {
        public async Task<WeatherDataValuesListModel> GetData()
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("http://twister.utm.edu/?command=DataQuery&uri=twister%3AUTM_1.Table1&format=json&mode=since-record&p1=624768&p2=2017-09-13T22:00:00&headsig=30291&nextpoll=10000&order=collected&_=1505340243729");
                string resp;
                try
                {
                    resp = await client.GetStringAsync(url);
                    resp = resp.Replace("\\n", "");
                }
                catch (Exception e)
                {
                    throw e;
                }
                WeatherDataModel root = new WeatherDataModel();
                try
                {
                    root = JsonConvert.DeserializeObject<WeatherDataModel>(resp);
                }
                catch (Exception e)
                {
                    throw e;
                }

                WeatherDataValuesListModel weatherDataValuesListModel = setJSONObject(root);

                return weatherDataValuesListModel;

            }
        }
        public WeatherDataValuesListModel setJSONObject(WeatherDataModel weatherDataModel)
        {
            WeatherDataValuesListModel weatherDataValuesListModel;
            weatherDataValuesListModel = new WeatherDataValuesListModel();


            foreach (DataListModel model in weatherDataModel.data)
            {
                WeatherDataValuesModel weatherDataValuesModel = new WeatherDataValuesModel();
                weatherDataValuesModel.Time_Stamp = model.time;
                weatherDataValuesModel.Record = model.no;
                weatherDataValuesModel.T1_Avg = model.vals[0];
                weatherDataValuesModel.T2_Avg = model.vals[1];
                weatherDataValuesModel.T1_Asp_Avg = model.vals[2];
                weatherDataValuesModel.RH1 = model.vals[3];
                weatherDataValuesModel.RH2 = model.vals[4];
                weatherDataValuesModel.U1_Avg = model.vals[5];
                weatherDataValuesModel.U2_Avg = model.vals[6];
                weatherDataValuesModel.UDir1 = model.vals[7];
                weatherDataValuesModel.UDir2 = model.vals[8];
                weatherDataValuesModel.U1_Max = model.vals[9];
                weatherDataValuesModel.U2_Max = model.vals[10];
                weatherDataValuesModel.P_mb_Avg = model.vals[11];
                weatherDataValuesModel.PPN_mm_Tot = model.vals[12];
                weatherDataValuesModel.TC1_Avg = model.vals[13];
                weatherDataValuesModel.SoilW1_Avg = model.vals[14];
                weatherDataValuesModel.SoilW2_Avg = model.vals[15];
                weatherDataValuesModel.SoilW3_Avg = model.vals[16];
                weatherDataValuesModel.SW_UP_Avg = model.vals[17];
                weatherDataValuesModel.SW_Down_Avg = model.vals[18];
                weatherDataValuesModel.LW_UP_Avg = model.vals[19];
                weatherDataValuesModel.LW_Down_Avg = model.vals[20];
                weatherDataValuesModel.CNR1TC_Avg = model.vals[21];
                weatherDataValuesModel.CNR1TK_Avg = model.vals[22];
                weatherDataValuesModel.NetSW_Avg = model.vals[23];
                weatherDataValuesModel.NetLW_Avg = model.vals[24];
                weatherDataValuesModel.Albedo_Avg = model.vals[25];
                weatherDataValuesModel.UpTot_Avg = model.vals[26];
                weatherDataValuesModel.DnTot_Avg = model.vals[27];
                weatherDataValuesModel.NetTot_Avg = model.vals[28];
                weatherDataValuesModel.CG3UpCo_Avg = model.vals[29];
                weatherDataValuesModel.CG3DnCo_Avg = model.vals[30];
                weatherDataValuesModel.Batt_Volt_Avg = model.vals[31];
                weatherDataValuesModel.T_Panel_Avg = model.vals[32];

                weatherDataValuesListModel.weatherDataValuesModel.Add(weatherDataValuesModel);
            }
            return weatherDataValuesListModel;
        }
    }
}
