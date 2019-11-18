using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public BGM activeBGM;
    public AudioCatalog audioCatalog;


    private void AudioConfiguration()
    {
        if ((activeBGM != BGM.NONE) && (activeBGM != BGM.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = gameObject.AddComponent<AudioSource>();
            activeAudioSource.clip = audioCatalog.BGMList[(int)activeBGM].clip;
            activeAudioSource.loop = audioCatalog.BGMList[(int)activeBGM].loop;
            activeAudioSource.volume = audioCatalog.BGMList[(int)activeBGM].volume;
            activeAudioSource.playOnAwake = true;
            activeAudioSource.Play();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {

    }

    public void Play(SFX sfx)
    {
        if ((sfx != SFX.NONE) && (sfx != SFX.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = gameObject.AddComponent<AudioSource>();
            activeAudioSource.clip = audioCatalog.SFXList[(int)sfx].clip;
            activeAudioSource.loop = audioCatalog.SFXList[(int)sfx].loop;
            activeAudioSource.volume = audioCatalog.SFXList[(int)sfx].volume;
            activeAudioSource.Play();
        }
    }

    private void Start()
    {
        AudioConfiguration();
    }
}