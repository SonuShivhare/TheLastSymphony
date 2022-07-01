using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_PlayerManager : MonoBehaviour
    {
        #region SerializedField
        [SerializeField] public TLS_Utility.PlayerVariation[] playerVariations;
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

    }
}