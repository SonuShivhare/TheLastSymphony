using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheLastSymphony
{
    public class TLS_SoundManager : MonoBehaviour
    {
        public int levelIndex;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioSource BGMAudioSource;

        public AudioClip slash;
        public AudioClip zombie;
        public AudioClip death;

        public AudioClip[] BGMs;

        public Image soundImage;

        public bool isSoundPlaying = true;

        private void Awake()
        {
            levelIndex = SceneManager.GetActiveScene().buildIndex;
            if (levelIndex < 4)
            {
                AssignBGM(levelIndex);

                if (isSoundPlaying)
                {
                    audioSource.mute = false;
                    BGMAudioSource.mute = false;
                }
                else
                {
                    audioSource.mute = true;
                    BGMAudioSource.mute = true;
                }
            }
        }

        public void AssignBGM(int index)
        {
            BGMAudioSource.clip = null;
            BGMAudioSource.clip = BGMs[index];
            BGMAudioSource.Play();
        }

        public void PlaySwordSlashSound()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(slash, 0.5f);
            }
        }

        public void PlayDeathSound()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(death, 0.5f);
            }
        }

        public void PlayZombieSound()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(zombie, 0.5f);
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
                BGMAudioSource.mute = false;
            }
            else
            {
                audioSource.mute = true;
                BGMAudioSource.mute = true;
            }
        }
    }
}

