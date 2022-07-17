using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticleEffectsCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem swordSpinVFX;
    [SerializeField] private ParticleSystem swordHitVFX;
    [SerializeField] private ParticleSystem swordSlashVFX;
    [SerializeField] private ParticleSystem swordWaveVFX;

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag(""))
        {
            
        }
    }
}
