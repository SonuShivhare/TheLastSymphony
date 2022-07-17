using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    [CreateAssetMenu(fileName = "EnemyName", menuName = "EnemiesData")]
    public class TLS_SO_EnemiesData : ScriptableObject
    {
        public EnemyType enemyType;
        public TLS_Level_01_EnemyProperty skeleton;
        public TLS_Level_01_EnemyProperty hellHound;
        public TLS_BringerOfDeath bringerOfDeath;

        public void ResetData()
        {
            //skeleton = null;
            //hellHound = null;
            //bringerOfDeath = null;
            //skeleton = new TLS_Level_01_EnemyProperty(EnemyType.Skeleton);
            //hellHound = new TLS_Level_01_EnemyProperty(EnemyType.HellHound);
            //bringerOfDeath = new TLS_Level_01_EnemyProperty(EnemyType.BringerOfDeath);
        }
    }
}