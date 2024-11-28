using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum AudioChannel
    {
        Master,
        Bgm,
        Sfx,
    }

    public float sfxVolumePercent { get; private set; }
    public float bgmVolumePercent { get; private set; }
    public float masterVolumePercent { get; private set; }

    AudioSource[] sfxSources;
    AudioSource[] musicSources;

    SoundLibrary library;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            library = GetComponent<SoundLibrary>();

            musicSources = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newMusicSource = new GameObject("Music Source " + (i + 1));
                musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                newMusicSource.transform.parent = transform;
            }

            sfxSources = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newSfxSource = new GameObject("sfx source " + (i + 1));
                sfxSources[i] = newSfxSource.AddComponent<AudioSource>();
                newSfxSource.transform.parent = transform;
            }

            masterVolumePercent = PlayerPrefs.GetFloat("master vol", 1f);
            bgmVolumePercent = PlayerPrefs.GetFloat("bgm vol", 1f);
            sfxVolumePercent = PlayerPrefs.GetFloat("sfx vol", 1);
        }
    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChannel.Bgm:
                bgmVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumePercent;
                break;
        }

        musicSources[0].volume = bgmVolumePercent * masterVolumePercent;
        musicSources[1].volume = bgmVolumePercent * masterVolumePercent;
        sfxSources[0].volume = sfxVolumePercent * masterVolumePercent;
        sfxSources[1].volume = sfxVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("master vol", masterVolumePercent);
        PlayerPrefs.SetFloat("bgm vol", bgmVolumePercent);
        PlayerPrefs.SetFloat("sfx vol", sfxVolumePercent);
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        musicSources[0].clip = clip;
        musicSources[0].loop = true;
        musicSources[0].Play();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    public void PlayAmbientSound(string ambientName, float fadeDuration = 1)
    {
        musicSources[1].clip = library.GetClipFromName(ambientName);
        musicSources[1].loop = true;
        musicSources[1].Play();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    public void PlaySound(string soundName)
    {
        sfxSources[0].PlayOneShot(library.GetClipFromName(soundName), sfxVolumePercent * masterVolumePercent);
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSources[0].PlayOneShot(clip, sfxVolumePercent * masterVolumePercent);
    }    

    public void StopWalkSound()
    {
        sfxSources[2].enabled = false;
    }

    public void StopAmbientSound()
    {
        sfxSources[1].Stop();
    }

    IEnumerator AnimateMusicCrossfade(float duration)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSources[0].volume = Mathf.Lerp(0, bgmVolumePercent * masterVolumePercent, percent);
            yield return null;
        }
    }
}