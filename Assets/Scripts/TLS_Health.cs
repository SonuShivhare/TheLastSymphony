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
        }

        public void Damage(int damage)
        {
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