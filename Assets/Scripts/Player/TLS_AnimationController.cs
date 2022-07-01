using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_AnimationController : MonoBehaviour
    {
        private Animator animator;

        private AnimationState playerAnimationState;

        private bool canChangeAnimationState;

        #region Properties
        public AnimationState PlayerAnimationState
        {
            get { return playerAnimationState; }
        }

        public bool CanChangeAnimationState
        {
            set { canChangeAnimationState = value; }
        }
        #endregion

        public void Init(Animator animator)
        {
            this.animator = animator;
            canChangeAnimationState = true;
        }

        public void PlayAnimation(AnimationState state)
        {
            if(!canChangeAnimationState) return;
            playerAnimationState = state;
            animator.Play(state.ToString());
        }
    }
}
