using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_BringerOfDeathController : MonoBehaviour
    {
        private Transform player;
        private EnemyStates enemyState;

        public void Init(Transform player)
        {
            this.player = player;
        }

        private void Update()
        {
            switch (enemyState)
            {
                case EnemyStates.None:
                    break;
                case EnemyStates.Idle:
                    break;
                case EnemyStates.Walk:
                    break;
                case EnemyStates.Attack:
                    break;
                case EnemyStates.Defense:
                    break;
                case EnemyStates.CastSpell:
                    break;
                case EnemyStates.Teleport:
                    break;
                case EnemyStates.Die:
                    break;
                default:
                    break;
            }
        }

    }
}