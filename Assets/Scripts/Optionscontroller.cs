using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optionscontroller : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultvolume = 1f;
    [SerializeField] Slider difSlider;
    [SerializeField] float defaultdif = 0f;
    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difSlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            Debug.Log(volumeSlider.value);
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No musicplayer found! Did you start from splashscreen?");

        }
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.setMasterVolume(volumeSlider.value);
        PlayerPrefsController.setDifficulty(difSlider.value);
        FindObjectOfType<LevelLoader>().GoToMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultvolume;
        difSlider.value = defaultdif;
    }

}
