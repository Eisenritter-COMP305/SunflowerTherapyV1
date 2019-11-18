/*****************************
* CREATED BY: George Zhou   *
* LAST MODIFIED: 11/11/2019 *
*****************************/

//This script contains all the audio enums
using UnityEngine;
[System.Serializable]
public enum BGM
{
   NONE = -1,
   STARTBGM,
   LEVEL1BGM,
   LEVEL2BGM,
   LEVEL3BGM,
   GAMEOVERBGGM,
   WINBGM,
   NUM_OF_CLIPS
}

[System.Serializable]
public enum SFX
{
    NONE = -1,
    COLLECTSFX,
    NUM_OF_CLIPS
}

[System.Serializable]
public class BGMusic
{
    public string name;
    public BGM BGM = BGM.NONE;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
}

[System.Serializable]
public class SFXEffect
{
    public string name;
    public SFX SFX = SFX.NONE;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
}