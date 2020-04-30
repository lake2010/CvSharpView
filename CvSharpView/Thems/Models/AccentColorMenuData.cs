using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CvSharpView.Data;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro;

namespace CvSharpView.Thems.Models
{
    public class AccentColorMenuData
    {
        public string Name { get; set; }

        public Brush BorderColorBrush { get; set; }

        public Brush ColorBrush { get; set; }

        public AccentColorMenuData()
        {
            this.ChangeAccentCommand = new RelayCommand(this.DoChangeTheme);
        }

        public RelayCommand ChangeAccentCommand { get; }

        protected virtual void DoChangeTheme()
        {
            ThemeManager.ChangeThemeColorScheme(Application.Current, this.Name);
            GlobalData.AppConfig.ColorSchemeName = this.Name;
            GlobalData.Save();
        }
    }
}
