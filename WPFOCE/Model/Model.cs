using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEditor;
using UnityEngine;

namespace WPFOCE.Model
{
    class ModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Wave> WaveList
        {
            get => m_waveList.Waves;
            set
            {
                if(m_waveList.Waves == value)
                {
                    m_waveList.Waves = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WaveList)));
                }
            }
        }

        public WaveList m_waveList = new WaveList();

    }
}
