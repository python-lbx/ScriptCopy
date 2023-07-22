using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start() 
    {
        resolutions = Screen.resolutions; //獲得解析度選項加入清單

        resolutionDropdown.ClearOptions(); //清除默除清單選項
        
        List<string> options = new List<string>(); //創建列表作選項存入

        int currentResolutionIndex = 0;
        for(int i = 0 ; i < resolutions.Length ; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //按格式組成字串
            options.Add(option); //列表新增選項

            if(resolutions[i].width  == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
               currentResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(options); //介面新增選項
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
}
