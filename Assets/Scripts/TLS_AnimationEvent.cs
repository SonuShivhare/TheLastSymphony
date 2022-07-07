using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_AnimationEvent : MonoBehaviour
    {
        private TLS_AnimationController animationController;
        private TLS_CharacterController characterController;

        private void Start()
        {
            animationController = transform.parent.GetComponent<TLS_AnimationController>();
            characterController = transform.parent.GetComponent<TLS_CharacterController>();
        }

        public void CanChangeAnimationState()
        {
            if (characterController.IsGrounded())
            {
                animationController.CanChangeAnimationState = true;
            }
            else
            {
                animationController.CanChangeAnimationState = true;
                animationController.PlayAnimation(AnimationState.Jump);
                animationController.CanChangeAnimationState = false;
            }
        }
    }
}