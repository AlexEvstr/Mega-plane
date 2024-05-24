using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    [SerializeField] private GameObject _soundsOn;
    [SerializeField] private GameObject _soundsOff;

    private void Start()
    {
        float sounds = PlayerPrefs.GetFloat("Sounds", 1);
        if (sounds == 1)
        {
            SoundsOn();
        }
        else
        {
            SoundsOff();
        }    
    }

    public void SoundsOff()
    {
        _soundsOn.SetActive(false);
        _soundsOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("Sounds", 0);
    }

    public void SoundsOn()
    {
        _soundsOff.SetActive(false);
        _soundsOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("Sounds", 1);
    }
}
