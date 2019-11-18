/*****************************
* CREATED BY: George Zhou   *
* LAST MODIFIED: 11/11/2019 *
*****************************/

//This script contains data for scene setting

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioCatalog", menuName = "Scene/Audio Catalog")]
[System.Serializable]
public class AudioCatalog: ScriptableObject
{
    public BGMusic[] BGMList;
    public SFXEffect[] SFXList;
}