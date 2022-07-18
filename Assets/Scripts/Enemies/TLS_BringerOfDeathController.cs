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
        private bool isCastingSpell;

        private float nextAttack = 0;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            enemiesProperty = enemiesData.bringerOfDeath;
            enemyState = EnemyStates.Idle;
            isCastingSpell = false;
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
            if (Vector3.Distance(player.position, transform.position) < enemiesProperty.playerSwordAttackDistance && isCastingSpell)
            {
                isCastingSpell = false;
                enemyState = EnemyStates.Attack;
            }

            if (Vector3.Distance(player.position, transform.position) < enemiesProperty.playerSwordAttackDistance && nextAttack < Time.time && !isCastingSpell)
            {

                enemyState = EnemyStates.Attack;
                nextAttack = Time.time + enemiesProperty.SwordAttackDealybetween;
                SwordAttack();
            }
            else if (Vector3.Distance(player.position, transform.position) > enemiesProperty.playerSwordAttackDistance && enemyState == EnemyStates.Idle &&!isCastingSpell)
            {
                enemyState = EnemyStates.CastSpell;
                isCastingSpell = true;
                StartCoroutine(CastSpell());
            }
        }

        public void SwordAttack()
        {
            animator.Play("Attack");

            StartCoroutine(TLS_Utility.AfterDelay(() => { enemyState = EnemyStates.Idle; }, 1));
        }

        public IEnumerator CastSpell()
        {
            while (isCastingSpell)
            {
                float delay = Random.Range(enemiesProperty.SpellCastDelayMin, enemiesProperty.SpellCastDelayMax);
                yield return new WaitForSeconds(delay);
                nextAttack = Time.time + enemiesProperty.SwordAttackDealybetween;
                animator.Play("CastSpell");
                Vector3 position = player.position;

                yield return new WaitForSeconds(1f);

                Instantiate(enemiesProperty.SpellGameObject, position, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }

        public void OnTriggerStay(Collider other)
        {
            Debug.Log(other.gameObject);
        }

    }
}