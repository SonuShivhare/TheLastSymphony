using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public abstract class TLS_EnemyInterface
    {
        [SerializeField] public EnemyType enemyType;
        [SerializeField] public GameObject prefeb;
        [SerializeField] public float minSpeed;
        [SerializeField] public float maxSpeed;
        [SerializeField] public int damage;

        protected TLS_EnemyInterface(EnemyType enemyType)
        {
            this.enemyType = enemyType;
        }
    }
    [System.Serializable]
    public class TLS_Level_01_EnemyProperty : TLS_EnemyInterface
    {
        public float spawnRange;
        public float spawnDistanceFromPlayer;
        public float startingDelay;
        public float delayBetween;

        public TLS_Level_01_EnemyProperty(EnemyType enemyType) : base(enemyType)
        {
        }
    }












    [System.Serializable]
    public class TLS_Skeleton : TLS_EnemyInterface
    {
        public float spawnRange;
        public float spawnDistanceFromPlayer;
        public int count;
        public float startingDelay;
        public float delayBetween;

        TLS_Skeleton() : base(EnemyType.Skeleton) { }
    }

    [System.Serializable]
    public class TLS_HellHound : TLS_EnemyInterface
    {
        public float spawnRange;
        public float spawnDistanceFromPlayer;
        public int count;
        public float startingDelay;
        public float delayBetween;

        TLS_HellHound() : base(EnemyType.HellHound) { }
    }


    [System.Serializable]
    public class TLS_BringerOfDeath : TLS_EnemyInterface
    {
        public float spawnRange;
        public float spawnDistanceFromPlayer;
        public int count;

        public TLS_BringerOfDeath() : base(EnemyType.BringerOfDeath) { }
    }
}