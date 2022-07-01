using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TLS_CharacterController : MonoBehaviour
    {
        #region SerializedField

        [Space(15)]
        [SerializeField] private LayerMask midGroundLayerMask;

        [SerializeField] private float playerSpeed;
        [SerializeField] private float jumpForce;

        [SerializeField][Range(0, 0.5f)] private float groundDetectionRange;
        #endregion

        #region Private Data
        private InputSystem inputActions;
        private new Rigidbody2D rigidbody2D;

        private TLS_AnimationController animationController;
        private TLS_PlayerManager playerManager;

        private Vector2 tempVector;

        private bool isFacingRight;

        #endregion

        #region MonoBehaviour Calls

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();

            animationController = GetComponent<TLS_AnimationController>();
            playerManager = GetComponent<TLS_PlayerManager>();

            inputActions = new InputSystem();
            inputActions.Player.Enable();
            inputActions.Player.Jump.started += Jump;

            isFacingRight = true;
        }

        private void FixedUpdate()
        {
            PerformMovement();
        }
        #endregion

        private void PerformMovement()
        {
            tempVector = inputActions.Player.Movement.ReadValue<Vector2>() * playerSpeed;
            tempVector.y = rigidbody2D.velocity.y;
            rigidbody2D.velocity = tempVector;

            HandleIdleAndRunAnimation(rigidbody2D.velocity.x);

            if (rigidbody2D.velocity.x > 0 && !isFacingRight) Flip();
            if (rigidbody2D.velocity.x < 0 && isFacingRight) Flip();
        }

        private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (IsGrounded()) rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            animationController.PlayAnimation(AnimationState.Jump);

            animationController.CanChangeAnimationState = false;

            StartCoroutine(JumpAnimationCheck());
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, groundDetectionRange, midGroundLayerMask);
        }

        private IEnumerator JumpAnimationCheck()
        {
            yield return new WaitForSeconds(TLS_Constants.GroundCheckStartDelay);
            while (!IsGrounded())
            {
                yield return new WaitForSeconds(TLS_Constants.GroundCheckBetweenDelay);
            }

            animationController.PlayAnimation(AnimationState.Idle);
            animationController.CanChangeAnimationState = true;
        }

        private void HandleIdleAndRunAnimation(float magnitude)
        {
            if (magnitude != 0 && animationController.PlayerAnimationState != AnimationState.Run)
            {
                animationController.PlayAnimation(AnimationState.Run);
            }
            else if (magnitude == 0 && animationController.PlayerAnimationState != AnimationState.Idle)
            {
                animationController.PlayAnimation(AnimationState.Idle);
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180, 0);
        }
    }
}
