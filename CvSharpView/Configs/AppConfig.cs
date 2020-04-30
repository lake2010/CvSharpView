using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSharpView.Configs
{
    public class AppConfig
    {
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

        public string ColorSchemeName { get; set; }

        public string ThemeName { get; set; }

        public string LanguageName { get; set; }
    }
}
