using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_AnimationEvent : MonoBehaviour
    {
        public bool accessPlayerCompo;

        private TLS_AnimationController animationController;
        private TLS_CharacterController characterController;
        private TLS_PlayerController playerController;

        private void Start()
        {
            if(accessPlayerCompo)
            {
                animationController = transform.parent.GetComponent<TLS_AnimationController>();
                characterController = transform.parent.GetComponent<TLS_CharacterController>();
                playerController = transform.parent.GetComponent<TLS_PlayerController>();
            }
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

        public void DetectEnemy()
        {
            //playerController.DetectEnemy();
        }

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    }
}