using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_BringerOfDeathController : MonoBehaviour
    {
        [SerializeField] private TLS_SO_EnemiesData enemiesData;
        private TLS_BringerOfDeath enemiesProperty;

        public Transform player;
        public EnemyStates enemyState;
        private Animator animator;
        private Coroutine castSpell;

        private float nextAttack = 0;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            enemiesProperty = enemiesData.bringerOfDeath;
            enemyState = EnemyStates.Idle;
        }

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
            DetectPlayer();
        }

        private void DetectPlayer()
        {
            if (Vector3.Distance(player.position, transform.position) < enemiesProperty.playerSwordAttackDistance && nextAttack < Time.time && enemyState == EnemyStates.Idle)
            {
                enemyState = EnemyStates.Attack;
                nextAttack = Time.time + enemiesProperty.SwordAttackDealybetween;
                SwordAttack();
            }
            else if(Vector3.Distance(player.position, transform.position) > enemiesProperty.playerSwordAttackDistance && enemyState != EnemyStates.CastSpell && enemyState == EnemyStates.Idle)
            {
                enemyState = EnemyStates.CastSpell;
                float delay = Random.Range(enemiesProperty.SpellCastDelayMin, enemiesProperty.SpellCastDelayMax);
                castSpell = StartCoroutine(CastSpell(delay));
            }
        }

        public void SwordAttack()
        {
            animator.Play("Attack");

            StartCoroutine(TLS_Utility.AfterDelay(() => { enemyState = EnemyStates.Idle; }, 1.5f));
        }

        public IEnumerator CastSpell(float delay)
        {
            yield return new WaitForSeconds(delay);
            animator.Play("CastSpell");
            Vector3 position = player.position;
            
            StartCoroutine(TLS_Utility.AfterDelay(() => {
                nextAttack = Time.time + enemiesProperty.SwordAttackDealybetween;
                enemyState = EnemyStates.Idle;
                Instantiate(enemiesProperty.SpellGameObject, position, Quaternion.identity);
            }, 1.5f));
        }

        public void OnTriggerStay(Collider other)
        {
            Debug.Log(other.gameObject);
        }

    }
}