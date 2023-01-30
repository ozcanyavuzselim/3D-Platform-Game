using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomix;

    private bool isFullscreen;
    public void SetResolution(int index)
    {
        if(index == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }else if(index == 1)
        {
            Screen.SetResolution(1000, 800, false);
        }
    }
    public void setQuality(int qulaityIndex)
    {
        QualitySettings.SetQualityLevel(qulaityIndex);
    }

    public void SetFullscreen(bool fulscreen_enable)
    {
        Screen.fullScreen = fulscreen_enable;
        isFullscreen = fulscreen_enable;
    }
    public void SetMouseSensivity(float volue)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", volue);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mauseSensitivity = volue;
        }
    }

    public void SetMasterVolime(float value)
    {
        audiomix.SetFloat("MaterVolume", value);
    }
    public void SetMusicVolime(float value)
    {
        audiomix.SetFloat("MusicVolume", value);
    }
}
