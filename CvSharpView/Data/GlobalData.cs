using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvSharpView.Configs;
using Newtonsoft.Json;

namespace CvSharpView.Data
{
    public class GlobalData
    {
        public static void Init()
        {
            if (File.Exists(AppConfig.SavePath))
            {
                try
                {
                    var json = File.ReadAllText(AppConfig.SavePath);
                    AppConfig = (string.IsNullOrEmpty(json) ? new AppConfig() : JsonConvert.DeserializeObject<AppConfig>(json)) ?? new AppConfig();
                }
                catch
                {
                    AppConfig = new AppConfig();
                }
            }
            else
            {
                AppConfig = new AppConfig();
            }
        }

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(AppConfig);
            File.WriteAllText(AppConfig.SavePath, json);
        }

        public static AppConfig AppConfig { get; set; }
    }
}
