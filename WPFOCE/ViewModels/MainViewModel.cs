using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPFOCE.BusinessLogic;
using System.Reflection.Emit;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace WPFOCE.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public DelegateCommand CreateNewWave { get; }
        public string StatusLabel
        {
            get => m_statusLabel;
            set
            {
                if (m_statusLabel != value)
                {
                    m_statusLabel = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusLabel)));
                }
            }
        }

        public SolidColorBrush StatusBarColor
        {
            get => m_statusBarColor;
            set
            {
                if (m_statusBarColor != value)
                {
                    m_statusBarColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusBarColor)));
                }
            }
        }

        private string m_statusLabel;
        private SolidColorBrush m_statusBarColor;


        public MainViewModel()
        {
            CreateNewWave = new DelegateCommand(CreateNew, CanCreateNew);
        }

        private void CreateNew(object? param)
        {
            StatusLabel = "Neu erstellt!";
        }

        private bool CanCreateNew(object? param)
        {
            return true;
        }
    }
}
