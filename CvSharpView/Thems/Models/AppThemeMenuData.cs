using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CvSharpView.Data;
using MahApps.Metro;

namespace CvSharpView.Thems.Models
{
    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme()
        {
            ThemeManager.ChangeThemeBaseColor(Application.Current, this.Name);
            GlobalData.AppConfig.ThemeName = this.Name;
            GlobalData.Save();
        }
    }
}
