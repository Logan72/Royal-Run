using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Header("Audio clips")]
    [SerializeField] AudioClip[] backgroundMusics;
    [SerializeField] AudioClip rockSFX;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip appleSFX;
    [SerializeField] AudioClip potionSFX;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip checkpointSFX;
    [SerializeField] AudioClip buttonSFX;
    [SerializeField] AudioClip specialButtonSFX;
    [SerializeField] AudioClip countdownSFX;
    [Header("Volumes")]
    [SerializeField] float rockSFX_maxVolume;
    [SerializeField] float rockSFX_minVolume;
    [SerializeField] float coinSFX_volumeScale;
    [SerializeField] float appleSFX_volumeScale;
    [SerializeField] float potionSFX_volumeScale;
    [SerializeField] float gameOverSFX_volumeScale;
    [SerializeField] float checkpointSFX_volumeScale;
    [SerializeField] float buttonSFX_volumeScale;
    [SerializeField] float specialButtonSFX_volumeScale;
    [SerializeField] float countdownSFX_volumeScale;
    public float CountdownSFX_length { get { return countdownSFX.length; } }

    public void PlayBackgroundMusics()
    {
        Utility.KnuthShuffle(backgroundMusics);
        StartCoroutine(PlayBackgroundMusicsCoroutine());
    }

    IEnumerator PlayBackgroundMusicsCoroutine()
    {
        int i = 0;

        while (true)
        {
            audioSource.clip = backgroundMusics[i];
            audioSource.Play();
            if (++i == backgroundMusics.Length) i = 0;
                        
            yield return new WaitForSecondsRealtime(audioSource.clip.length);
        }
    }

    public void PlayGameOverSFX()
    {
        audioSource.PlayOneShot(gameOverSFX, gameOverSFX_volumeScale);
    }

    public void PlayCheckpointSFX()
    {
        audioSource.PlayOneShot(checkpointSFX, checkpointSFX_volumeScale);
    }

    public void PlayCoinSFX()
    {
        audioSource.PlayOneShot(coinSFX, coinSFX_volumeScale);
    }

    public void PlayAppleSFX()
    {
        audioSource.PlayOneShot(appleSFX, appleSFX_volumeScale);
    }

    public void PlayPotionSFX()
    {
        audioSource.PlayOneShot(potionSFX, potionSFX_volumeScale);
    }

    public void PlayRockSFX(AudioSource rockAudioSource, float interpolationValue)
    {
        rockAudioSource.clip = rockSFX;
        rockAudioSource.volume = Mathf.Lerp(rockSFX_maxVolume, rockSFX_minVolume, interpolationValue);
        rockAudioSource.Play();
    }

    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(buttonSFX, buttonSFX_volumeScale);
    }

    public void PlaySpecialButtonSFX()
    {
        audioSource.PlayOneShot(specialButtonSFX, specialButtonSFX_volumeScale);
    }

    public void PlayCountdownSFX()
    {
        audioSource.PlayOneShot(countdownSFX, countdownSFX_volumeScale);
    }
}
