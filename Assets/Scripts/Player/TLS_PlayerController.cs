using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_PlayerController : MonoBehaviour
    {
        #region SerializedField
        [SerializeField] public TLS_Utility.PlayerVariation[] playerVariations;
        [SerializeField] GameObject EnemyTrigger;

        #endregion

        #region Private Data
        private TLS_AnimationController animationController;

        private InputSystem inputSystem;

        private PlayerType playerType;
        #endregion


        private void Awake()
        {
            animationController = GetComponent<TLS_AnimationController>();

            inputSystem = new InputSystem();

            inputSystem.Player.Enable();

            inputSystem.Player.Attack.performed += Attack; ;

            // ---------- Remove -----------
            playerType = PlayerType.Light;

        }

        private void Start()
        {
            GameObject obj = System.Array.Find(playerVariations, playerVariations => playerVariations.playerVariationType == playerType).playerVariationPrefeb;
            obj = Instantiate(obj, this.transform);
            animationController.Init(obj.GetComponent<Animator>());
        }

        private void Attack(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            animationController.PlayAnimation(AnimationState.Attack);
            animationController.CanChangeAnimationState = false;
        }

        public LayerMask enemyLayer;
        public float swordRange;

        public void DetectEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, swordRange, enemyLayer);

            Debug.DrawRay(transform.position, transform.right * swordRange, Color.red, 5f);
            
            if( hit && hit.transform.CompareTag("Skeleton"))
            {
                hit.transform.GetComponent<TLS_EnemyController>().PlayDeathAnimation();
            }

            if(hit && hit.transform.CompareTag("HellHound"))
            {
                Destroy(hit.transform.gameObject);
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