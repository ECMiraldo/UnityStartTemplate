using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UISettings : MonoBehaviour
{
    #region Audio
    [SerializeField] private AudioMixer audioMixer;
    public void SetMasterVolume(float level) => audioMixer.SetFloat("MasterVol", level);
    public void SetVFxVolume(float level) => audioMixer.SetFloat("SFXVol", level);
    public void SetMusicVolume(float level) => audioMixer.SetFloat("MusicVol", level);

    #endregion

    #region Resolution

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void GetUserResolutions()
    {
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        List<string> resolutionsOptions = new();
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionsOptions.Add(option);
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionsOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, true);
    }

    #endregion

    #region Graphics
    public void ChangeQuality(int quality) => QualitySettings.SetQualityLevel(quality);
    #endregion


    private void Start()
    {
        GetUserResolutions();
    }
}
