using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeLevel : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolumeLevel (float sliderValue)
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(sliderValue) * 20);
    }
}
