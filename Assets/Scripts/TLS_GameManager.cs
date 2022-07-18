using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_GameManager : MonoBehaviour
    {
        public static TLS_GameManager instance;

        public LevelManager levelManager;
        public TLS_ParticleEffects particleEffect;
        public TLS_CharacterController characterController;
        public TLS_UIManager UIManager;
        public TLS_SoundManager soundManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

    }
}
