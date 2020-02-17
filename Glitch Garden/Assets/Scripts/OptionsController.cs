using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefController.GetMasterVolume();
        difficultySlider.value = PlayerPrefController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefController.SetMasterVolumne(volumeSlider.value);
        PlayerPrefController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetToDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
