using UnityEngine.UI;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        //[SerializeField] private AudioSource BGMAudioSource;

        //public AudioClip playerWalk;
        //public AudioClip playerDamage;
        //public AudioClip playerDie;

        //public AudioClip enemy;
        //public AudioClip enemyDie;

        //public AudioClip swordHit;

        public Image soundImage;
        //public Image musicImage;
        //public Image vibrationImage;

        //public Sprite onSprite;

        public bool isSoundPlaying = true;
        //public bool isBGMPlaying = true;
        //public bool isVibrating = true;

        //private void Awake()
        //{
        //    //vibrationImage.GetComponent<Button>().interactable = SystemInfo.supportsVibration;

        //    if (isSoundPlaying)
        //    {
        //        audioSource.mute = false;
        //        soundImage.sprite = onSprite;
        //    }
        //    else
        //    {
        //        audioSource.mute = true;
        //        soundImage.sprite = offSprite;
        //    }

        //    if (isBGMPlaying)
        //    {
        //        //BGMAudioSource.Play();
        //        musicImage.sprite = onSprite;
        //    }
        //    else
        //    {
        //        //BGMAudioSource.Stop();
        //        musicImage.sprite = offSprite;
        //    }

        //    if (isVibrating)
        //    {
        //        vibrationImage.sprite = onSprite;
        //    }
        //    else
        //    {
        //        vibrationImage.sprite = offSprite;
        //    }
        //}

        public void PlaySwordHitSound()
        {
            if (!audioSource.isPlaying)
            {
                //audioSource.PlayOneShot(swordHit, 0.5f);
            }
        }

        public void StopSound()
        {
            audioSource.Stop();
        }

        public void SwitchSoundState()
        {
            isSoundPlaying = !isSoundPlaying;

            if (isSoundPlaying)
            {
                audioSource.mute = false;
                //soundImage.sprite = onSprite;
            }
            else
            {
                audioSource.mute = true;
                //soundImage.sprite = offSprite;
            }
        }

        //public void SwitchMusicState()
        //{
        //    isBGMPlaying = !isBGMPlaying;

        //    if (isBGMPlaying)
        //    {
        //        //BGMAudioSource.Play();
        //        //musicImage.sprite = onSprite;
        //    }
        //    else
        //    {
        //        //BGMAudioSource.Stop();
        //        //musicImage.sprite = offSprite;
        //    }
        //}
    }
}

