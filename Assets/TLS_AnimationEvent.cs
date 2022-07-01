using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_AnimationEvent : MonoBehaviour
    {
        public void CanChangeAnimationState()
        {
            transform.parent.GetComponent<TLS_AnimationController>().CanChangeAnimationState = true;
        }
    }
}