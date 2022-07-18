using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_PlayerController : MonoBehaviour
    {
        #region SerializedField
        [SerializeField] public TLS_Utility.PlayerVariation[] playerVariations;
        [SerializeField] GameObject EnemyDetector;
        [SerializeField] private TLS_GameManager gameManager;
        [SerializeField] private float attackDelay;
        #endregion

        #region Private Data
        private TLS_AnimationController animationController;
        private InputSystem inputSystem;
        private PlayerType playerType;

        private float nextAttacky;
        #endregion

        private void Awake()
        {
            animationController = GetComponent<TLS_AnimationController>();

            inputSystem = new InputSystem();

            inputSystem.Player.Enable();

            inputSystem.Player.Attack.performed += Attack;

            // ---------- Remove -----------
            playerType = PlayerType.Light;
            nextAttacky = 0;

        }

        private void Start()
        {
            GameObject obj = System.Array.Find(playerVariations, playerVariations => playerVariations.playerVariationType == playerType).playerVariationPrefeb;
            obj = Instantiate(obj, this.transform);
            animationController.Init(obj.GetComponent<Animator>());
        }

        private void Attack(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (Time.time < nextAttacky) return;
            nextAttacky = Time.time + attackDelay;
            animationController.PlayAnimation(AnimationState.Attack);
            animationController.CanChangeAnimationState = false;
            PlaySwordWaveVFX();
        }

        private void PlaySwordWaveVFX()
        {
            if(gameManager != null)
            {
            gameManager.particleEffect.swordWaveVFX.gameObject.SetActive(true);
            gameManager.particleEffect.swordWaveVFX.transform.SetPositionAndRotation(this.transform.position, (transform.rotation.y < 0 ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, -90)));
            gameManager.particleEffect.swordWaveVFX.Play();
            }
            GameObject tempObj = Instantiate(EnemyDetector, transform.position, Quaternion.identity);
            tempObj.GetComponent<TLS_EnemyDetecter>().Init(transform.rotation.y < 0 ? -1 : 1, this.transform);
        }

        public LayerMask enemyLayer;
        public float swordRange;

        public void DetectEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, swordRange, enemyLayer);

            Debug.DrawRay(transform.position, transform.right * swordRange, Color.red, 5f);

            if (hit && hit.transform.CompareTag("Skeleton"))
            {
                hit.transform.GetComponent<TLS_EnemyController>().PlayDeathAnimation();

                gameManager.UIManager.SkullCounter();

                gameManager.particleEffect.fireDeathVFX.transform.position = hit.transform.GetComponent<TLS_EnemyController>().transform.GetChild(1).transform.position;
                gameManager.particleEffect.fireDeathVFX.gameObject.SetActive(true);
                gameManager.particleEffect.fireDeathVFX.Play();
            }

            if (hit && hit.transform.CompareTag("HellHound"))
            {
                Destroy(hit.transform.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Portal"))
            {
                Debug.Log("TriggerWorked");
                gameManager.levelManager.LoadNextScene();
                gameManager.UIManager.portal.gameObject.SetActive(false);
                gameManager.UIManager.portal.transform.parent.gameObject.SetActive(false);
            }
        }

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if(detectEnemy)
        //    {
        //        if(collision.CompareTag("Enemy"))
        //        {
        //            Destroy(collision.gameObject);
        //        }
        //    }
        //}
    }
}