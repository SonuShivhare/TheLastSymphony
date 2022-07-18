using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_EnemyDetecter : MonoBehaviour
    {
        public float Speed;
        public float distance;
        public float lifeTime;
        public bool isMoving;
        private Transform player;
        public int direction;
        private float currentLifeTime;

        private void Awake()
        {
            isMoving = false;
        }

        public void Init(int direction, Transform player)
        {
            this.direction = direction;
            isMoving = true;
            this.player = player;
            currentLifeTime = Time.time + lifeTime;
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                transform.Translate(new Vector3(direction * Speed * Time.deltaTime, 0, 0));
            }

            if (isMoving && Vector3.Distance(player.position, transform.position) > distance)
            {
                Destroy(gameObject);
            }

            if(Time.time > currentLifeTime) Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.LogWarning(collision.name);
            if (collision.CompareTag("Skeleton"))
            {
                collision.transform.GetComponent<TLS_EnemyController>().PlayDeathAnimation();

                TLS_GameManager.instance.UIManager.SkullCounter();
                TLS_GameManager.instance.soundManager.PlaySwordSlashSound();
                TLS_GameManager.instance.particleEffect.fireDeathVFX.transform.position = collision.transform.GetComponent<TLS_EnemyController>().transform.GetChild(1).transform.position;
                TLS_GameManager.instance.particleEffect.fireDeathVFX.gameObject.SetActive(true);
                TLS_GameManager.instance.particleEffect.fireDeathVFX.Play();
            }

            if (collision.CompareTag("HellHound"))
            {
                TLS_GameManager.instance.UIManager.SkullCounter();

                TLS_GameManager.instance.soundManager.PlaySwordSlashSound();

                Destroy(collision.transform.gameObject);

                TLS_GameManager.instance.particleEffect.soulFireDeath.transform.position = collision.transform.GetComponent<TLS_EnemyController>().transform.position;
                TLS_GameManager.instance.particleEffect.soulFireDeath.gameObject.SetActive(true);
                TLS_GameManager.instance.particleEffect.soulFireDeath.Play();
            }
            if (collision.CompareTag("BringerOfDeath"))
            {
                collision.transform.GetComponent<TLS_Health>().Damage(20);

                TLS_GameManager.instance.soundManager.PlaySwordSlashSound();

                TLS_GameManager.instance.particleEffect.soulFireDeath.transform.position = collision.transform.position;
                TLS_GameManager.instance.particleEffect.soulFireDeath.gameObject.SetActive(true);
                TLS_GameManager.instance.particleEffect.soulFireDeath.Play();
            }
        }
    }
}