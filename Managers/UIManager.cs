using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadMenu;
    public GameObject settingMenu;

    public AudioMixer masterMixer;
    public Slider masterAudioSlider;
    public Slider bgmAudioSlider;
    public Slider sfxAudioSlider;

    public GameObject menuCanvas;
    public GameObject inGameMainMenu;
    public GameObject inGameSaveMenu;
    public GameObject inGameLoadMenu;
    public GameObject inGameSettingMenu;

    public AudioMixer inGameMasterMixer;
    public Slider inGameMasterAudioSlider;
    public Slider inGameBgmAudioSlider;
    public Slider inGameSfxAudioSlider;


    private static UIManager instance;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public void MasterAudioControl()
    {
        float sound = masterAudioSlider.value;

        if (sound <= -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    }
    public void BGMAudioControl()
    {
        float sound = bgmAudioSlider.value;

        if (sound <= -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }
    public void SFXAudioControl()
    {
        float sound = sfxAudioSlider.value;

        if (sound <= -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }


    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadButton()
    {
        mainMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
    public void SettingButton()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }
    public void LoadExitButton()
    {
        loadMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void SettingExitButton()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }




    public void InGameSaveButton()
    {
        inGameMainMenu.SetActive(false);
        inGameSaveMenu.SetActive(true);
    }
    public void InGameLoadButton()
    {
        inGameMainMenu.SetActive(false);
        inGameLoadMenu.SetActive(true);
    }
    public void InGameSettingButton()
    {
        inGameMainMenu.SetActive(false);
        inGameSettingMenu.SetActive(true);
    }
    public void InGameExitButton()
    {
        menuCanvas.SetActive(false);
        inGameMainMenu.SetActive(true);
        inGameSaveMenu.SetActive(false);
        inGameLoadMenu.SetActive(false);
        inGameSettingMenu.SetActive(false);
    }
    public void InGameMenuactivate()
    {
        menuCanvas.SetActive(true);
        inGameMainMenu.SetActive(true);
        inGameSaveMenu.SetActive(false);
        inGameLoadMenu.SetActive(false);
        inGameSettingMenu.SetActive(false);
    }
    public void InGameSaveExitButton()
    {
        inGameSaveMenu.SetActive(false);
        inGameMainMenu.SetActive(true);
    }
    public void InGameLoadExitButton()
    {
        inGameLoadMenu.SetActive(false);
        inGameMainMenu.SetActive(true);
    }
    public void InGameSettingExitButton()
    {
        inGameSettingMenu.SetActive(false);
        inGameMainMenu.SetActive(true);
    }
}
