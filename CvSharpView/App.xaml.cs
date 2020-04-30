using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CvSharpView.Common.EMutex;
using CvSharpView.Data;
using MahApps.Metro;

namespace CvSharpView
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            SoftwareMutex.RunMutext();
            GlobalData.Init();

            #region 皮肤和样式载入

            if (!string.IsNullOrEmpty(GlobalData.AppConfig.ColorSchemeName))
                ThemeManager.ChangeThemeColorScheme(this, GlobalData.AppConfig.ColorSchemeName);
            if (!string.IsNullOrEmpty(GlobalData.AppConfig.ThemeName))
                ThemeManager.ChangeThemeBaseColor(this, GlobalData.AppConfig.ThemeName);

            #endregion

            base.OnStartup(e);
        }
    }
}
