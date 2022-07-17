using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_OnParticleEffectsCollision : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Skeleton") || other.CompareTag("HellHound"))
            {

            }
        }
    }
}
