using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CvSharpView.Data;
using CvSharpView.Thems.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro;

namespace CvSharpView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            #region 皮肤与样使

            // create accent color menu items for the demo
            this.AccentColors = ThemeManager.ColorSchemes
                .Select(a => new AccentColorMenuData { Name = a.Name, ColorBrush = a.ShowcaseBrush })
                .ToList();

            // create metro theme color menu items for the demo
            this.AppThemes = ThemeManager.Themes
                .GroupBy(x => x.BaseColorScheme)
                .Select(x => x.First())
                .Select(a => new AppThemeMenuData() { Name = a.BaseColorScheme, BorderColorBrush = a.Resources["MahApps.Brushes.ThemeForeground"] as Brush, ColorBrush = a.Resources["MahApps.Brushes.ThemeBackground"] as Brush })
                .ToList();

            #endregion

            #region 国际化
            ResourceDictionaries = new List<ResourceDictionary>();

            var resources = Application.Current.Resources.MergedDictionaries.Where(x => x.Contains("Language"));
            foreach (var resource in resources)
            {
                ResourceDictionaries.Add(resource);
            }

            SelectChineseCommand = new RelayCommand(() =>
            {
                ChangedLanguageExecute("Chinese");
            });

            SelectEnglishCommand = new RelayCommand(() =>
            {
                ChangedLanguageExecute("English");
            });

            switch (GlobalData.AppConfig.LanguageName)
            {
                case "Chinese":
                    ChangedLanguageExecute("Chinese");
                    break;
                case "English":
                    ChangedLanguageExecute("English");
                    break;
                default:
                    break;
            }
            #endregion

        }

        #region 皮肤与样式导入

        public List<AccentColorMenuData> AccentColors { get; set; }

        public List<AppThemeMenuData> AppThemes { get; set; }

        #endregion

        #region 国际化

        public List<ResourceDictionary> ResourceDictionaries { get; set; }

        protected void DoChangeCulture(ResourceDictionary resourceDictionary)
        {
            var resources = Application.Current.Resources.MergedDictionaries.Where(x => x.Contains("Language"));

            var resourceDictionaries = resources.ToList();
            for (int i = 0; i < resourceDictionaries.Count(); i++)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionaries[i]);
            }

            resourceDictionaries = null;

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void ChangedLanguageExecute(string languageName)
        {
            DoChangeCulture(ResourceDictionaries.FirstOrDefault(x => x.Source.ToString().Contains(languageName)));
            GlobalData.AppConfig.LanguageName = languageName;
            GlobalData.Save();
        }

        public RelayCommand SelectChineseCommand { get; set; }

        public RelayCommand SelectEnglishCommand { get; set; }
        #endregion
    }
}