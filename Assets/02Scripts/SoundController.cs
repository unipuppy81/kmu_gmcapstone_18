using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public AudioMixer BGMMixer;
    public Slider masterSlider;
    public Slider bgmSlider;

    public void MasterControl()
    {
        float sound = masterSlider.value;

        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);

    }
    public void BGMControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) BGMMixer.SetFloat("BGM", -80);
        else BGMMixer.SetFloat("BGM", sound);

    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

}
