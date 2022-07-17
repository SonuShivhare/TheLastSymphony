using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_EnemyController : MonoBehaviour
    {
        #region private Field
        private Transform target;

        private float speed;
        private int damage;

        private bool isChasingPlayer;
        private bool isFacingRight;
        #endregion

        private void Awake()
        {
            isChasingPlayer = false;
            isFacingRight = false;
        }
        public void Init(Transform target, float speed, int damage)
        {
            this.target = target;
            this.speed = speed;
            this.damage = damage;

            if (target.position.x < transform.position.x)
            {
                if (isFacingRight) Flip();
            }
            else
            {
                if (!isFacingRight) Flip();
            }
        }

        private void FixedUpdate()
        {
            if (isChasingPlayer)
            {
                if (target.position.x < transform.position.x)
                {
                    if (isFacingRight) Flip();
                    transform.Translate(-speed * Time.fixedDeltaTime, 0, 0, Space.World);
                }
                else
                {
                    if (!isFacingRight) Flip();
                    transform.Translate(speed * Time.fixedDeltaTime, 0, 0, Space.World);
                }
            }
        }

        public void ChaseTheTarget()
        {
            isChasingPlayer = true;
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<TLS_Health>().Damage(damage);
                Destroy(gameObject);
            }
        }

        public void PlayDeathAnimation()
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}