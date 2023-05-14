using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using WPFOCE.Model;
using WaveEditor;
using System.Windows.Input;
using System.Windows;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//TODO: Model erstellen, Laden/Speichern, mEhR dElEgAtE cOmMaNdS!!11 (auch PropertyChanghed gedöns)

namespace WPFOCE.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string m_path;

        public DelegateCommand CreateNewWaveList { get; }
        public DelegateCommand CreateNewWave { get; }
        public DelegateCommand ClickLeft { get; }
        public DelegateCommand ClickRight { get; }
        public DelegateCommand Save { get; }
        public DelegateCommand Load { get; }

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

        public int Index
        {
            get => m_index;
            set
            {
                if(m_index != value)
                {
                    m_index = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Index)));
                }
            }
        }

        private int m_index;
        private ModelClass m_model = new ModelClass();
        private string m_statusLabel;

        public MainViewModel()
        {
            CreateNewWaveList = new DelegateCommand(CreateNew, CanCreateNew);
            CreateNewWave = new DelegateCommand(DoCreateNewWave, CanCreateNewWave);
            ClickLeft = new DelegateCommand(DoClickLeft, CanClickLeft);
            ClickRight = new DelegateCommand(DoClickRight, CanClickRight);
            Save = new DelegateCommand(DoSave, CanSave);
            Load = new DelegateCommand(DoLoad, CanLoad);
            ShowCurrentWave(m_model.WaveList.Count - 1);
        }

        private void DoSave(object? param)
        {
            if (m_path == null)
            {
                SaveAsData();
                return;
            }

            SaveFS();
        }

        private bool CanSave(object? param)
        {
            return true;
        }
        private void SaveAsData()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Waves|*.wav";

            if (dialog.ShowDialog() == true)
            {
                m_path = dialog.FileName;
                SaveFS();
            }
        }
        private void DoLoad(object? param)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Waves|*.wav";

            if (dialog.ShowDialog() == true)
            {
                m_path = dialog.FileName;
                LoadFS();
            }
        }

        private bool CanLoad(object? param)
        {
            return true;
        }
        private void SaveFS()
        {
            using (FileStream fs = new FileStream(m_path, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, m_model.m_waveList);
            }

            StatusLabel = "Waves gespeichert!";
        }

        private void LoadFS()
        {
            using (FileStream fs = new FileStream(m_path, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                m_model.m_waveList = (WaveList)bin.Deserialize(fs);
            }

            ShowCurrentWave(m_model.WaveList.Count);
            StatusLabel = "Waves geladen!";
        }


        private void DoClickRight(object? param)
        {
            ShowCurrentWave(Index);
        }

        private bool CanClickRight(object? param)
        {
            if (m_model is null)
                return false;

            if (Index == m_model.WaveList.Count)
                return false;
            return true;
        }

        private void DoClickLeft(object? param)
        {
            ShowCurrentWave(Index - 2);
        }

        private bool CanClickLeft(object? param)
        {
            if (m_model is null)
                return false;

            if (Index <= 1)
                return false;
            return true;
        }

        private void CreateNew(object? param)
        {
            m_model.WaveList = new List<Wave>();
            StatusLabel = "Neue Liste erstellt!";
            ShowCurrentWave(m_model.WaveList.Count - 1);
        }

        private bool CanCreateNew(object? param)
        {
            return true;
        }

        private void DoCreateNewWave(object? param)
        {
            m_model.WaveList.Add(new Wave());
            StatusLabel = "Neue Welle erstellt!";
            ShowCurrentWave(m_model.WaveList.Count - 1);
        }

        private bool CanCreateNewWave(object? param)
        {
            if (m_model.WaveList is not null)
                return true;
            return false;
        }

        private void ShowCurrentWave(int _index)
        {
            Index = _index + 1;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
