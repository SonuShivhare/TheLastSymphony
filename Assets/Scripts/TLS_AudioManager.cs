using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public struct ImageSpriteData
{
    public Image Image;
    public Sprite OnSprite;
    public Sprite OffSprite;
}

public class TLS_AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject ambientSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource BGMAudioSource;
    [SerializeField] private AudioSource waterAudioSource;

    public AudioClip Truck;
    public AudioClip Harvest;
    public AudioClip Coin;
    public AudioClip water;
    public AudioClip sow;

    [SerializeField] private ImageSpriteData soundImageData;
    [SerializeField] private ImageSpriteData MusicImageData;
    [SerializeField] private ImageSpriteData VibrationImageData;

    public bool isSoundPlaying = true;
    public bool isBGMPlaying = true;
    public bool isVibrating = true;

    private void Awake()
    {
        VibrationImageData.Image.GetComponent<Button>().interactable = SystemInfo.supportsVibration;

        if (isSoundPlaying)
        {
            ambientSound.SetActive(true);
            audioSource.mute = false;
            soundImageData.Image.sprite = soundImageData.OnSprite;
        }
        else 
        {
            ambientSound.SetActive(false);
            audioSource.mute = true;
            soundImageData.Image.sprite = soundImageData.OffSprite;
        }

        if (isBGMPlaying)
        {
            BGMAudioSource.Play();
            MusicImageData.Image.sprite = MusicImageData.OnSprite;
        }
        else
        {
            BGMAudioSource.Stop();
            MusicImageData.Image.sprite = MusicImageData.OffSprite;
        }

        if (isVibrating)
        {
            VibrationImageData.Image.sprite = VibrationImageData.OnSprite;
        }
        else
        {
            VibrationImageData.Image.sprite = VibrationImageData.OffSprite;
        }
    }

    public void PlayHarvesting()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Harvest, 0.5f);
        }
    }

    public void PlayCoinAnimationSound()
    {
        if (!audioSource.isPlaying) audioSource.PlayOneShot(Coin,0.5f);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    public void PlaySowingSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sow, 0.5f);
        }
    }

    public void PlayWateringSound()
    {
        if (!waterAudioSource.isPlaying)
        {
            waterAudioSource.loop = true;
            waterAudioSource.clip = water;
            waterAudioSource.volume = 0.5f;
            waterAudioSource.Play();
        }
    }

    public void StopWateringSound()
    {
        if (waterAudioSource.isPlaying)
        {
            waterAudioSource.Stop();
            waterAudioSource.loop = false;
            waterAudioSource.clip = null;
        }
    }

    public void SwitchSoundState()
    {
        isSoundPlaying = !isSoundPlaying;

        if (isSoundPlaying)
        {
            ambientSound.SetActive(true);
            audioSource.mute = false;
            waterAudioSource.mute = false;
            soundImageData.Image.sprite = soundImageData.OnSprite;
        }
        else
        {
            ambientSound.SetActive(false);
            audioSource.mute = true;
            waterAudioSource.mute = true;
            soundImageData.Image.sprite = soundImageData.OffSprite;
        }
    }
    public void SwitchMusicState()
    {
        isBGMPlaying = !isBGMPlaying;

        if (isBGMPlaying)
        {
            BGMAudioSource.Play();
            MusicImageData.Image.sprite = MusicImageData.OnSprite;
        }
        else
        {
            BGMAudioSource.Stop();
            MusicImageData.Image.sprite = MusicImageData.OffSprite;
        }
    }

    public void SwitchVibrationState()
    {
        isVibrating = !isVibrating;

        if (isVibrating)
        {
            VibrationImageData.Image.sprite = VibrationImageData.OnSprite;
        }
        else
        {
            VibrationImageData.Image.sprite = VibrationImageData.OffSprite;
        }
    }
}
