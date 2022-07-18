using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_Health : MonoBehaviour
    {
        #region SrializedField
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private bool isPlayer;
        [SerializeField] private TLS_GameManager gameManager;
        #endregion

        private TLS_AnimationController animationController;

        private void Awake()
        {
            MaxOutHealth();
        }

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            animationController = GetComponent<TLS_AnimationController>();
            gameManager = TLS_GameManager.instance;
        }

        public void Damage(int damage)
        {
            if (isPlayer)
            {
                gameManager.particleEffect.playerBloodVFX.gameObject.SetActive(true);
                gameManager.particleEffect.playerBloodVFX.transform.position = transform.position;
                gameManager.particleEffect.playerBloodVFX.Play();
                gameManager.UIManager.ModifyPlayerHealth(currentHealth, maxHealth);
            }
            else
            {
            }

            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                if (animationController != null)
                {
                    animationController.PlayAnimation(AnimationState.Hurt);
                    animationController.CanChangeAnimationState = false;
                }
            }
        }

        public void Heal(int healAmount)
        {
            currentHealth += healAmount;
        }

        public void MaxOutHealth()
        {
            currentHealth = maxHealth;
        }

        private void Die()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        }

    }
}