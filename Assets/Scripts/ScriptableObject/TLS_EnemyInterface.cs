using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public abstract class TLS_EnemyInterface
    {
        public EnemyType enemyType;
        public GameObject prefeb;
        public float minSpeed;
        public float maxSpeed;
        public int damage;

    }
    [System.Serializable]
    public class TLS_Level_01_EnemyProperty : TLS_EnemyInterface
    {
        public float spawnRange;
        public float spawnDistanceFromPlayer;
        public float startingDelay;
        public float delayBetween;
    }

    [System.Serializable]
    public class TLS_BringerOfDeath
    {
        public EnemyType enemyType;
        public GameObject SpellGameObject;
        public float playerSwordAttackDistance;
        public float SwordAttackDealybetween; 
        public float SpellCastDelayMin; 
        public float SpellCastDelayMax; 
    }
}