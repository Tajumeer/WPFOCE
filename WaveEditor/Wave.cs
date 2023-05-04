using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveEditor
{
    [Serializable]
    public class Wave
    { 
        private float timer;

        private List<Enemy> enemyTypes = new List<Enemy>();

        private Vector2 spawnpoint;
    }

    [Serializable]
    public class Enemy
    {
        public String Name;
        public int HealthPoints;
    }


    [Serializable]
    public class WaveList
    {
        public List<Wave> Waves = new List<Wave>();
    }
}
