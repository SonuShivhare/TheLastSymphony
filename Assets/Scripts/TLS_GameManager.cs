using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_GameManager : MonoBehaviour
    {
        public static TLS_GameManager instance;

        public TLS_ParticleEffects particleEffect;
        public TLS_CharacterController characterController;

        private void Awake()
        {
            if (instance == null)
            {
                Destroy(this);
            }
        }

    }
}
