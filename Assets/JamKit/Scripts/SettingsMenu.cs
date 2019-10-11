using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
	public GameObject		settingsMenuObject;
	public KeyCode			settingsMenuKey = KeyCode.Escape;

	public AudioMixer		mainMixer;

	[Space]
	public Slider			volumeSlider;
	public Dropdown			graphicDropdown;
	public Dropdown			resolutionDropdown;
	public Toggle			fullScreenToggle;
	public Toggle			vSyncToggle;

	Resolution[] 			resolutions;

	void Start()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		resolutionDropdown.AddOptions(resolutions.Select(r => r.width + " x " + r.height).ToList());

		int selected = resolutions.ToList().FindIndex(a => a.width == Screen.width && a.height == Screen.height);
		resolutionDropdown.value = selected;

		resolutionDropdown.RefreshShownValue();

		fullScreenToggle.isOn = Screen.fullScreen;
		vSyncToggle.isOn = QualitySettings.vSyncCount != 0;
	}

	public void SetFullScreen(bool fullScreen)
	{
		Screen.fullScreen = fullScreen;
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	
	public void SetResolution(int index)
	{
		Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
	}

	public void SetVSync(bool active)
	{
		QualitySettings.vSyncCount = (active) ? 1 : 0;
	}

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }

	//volume between 0 and 1
    public void SetVolume(float linearVolume)
	{
		mainMixer.SetFloat("MasterVolume", LinearToDecibel(linearVolume));
	}

	public void ShowSettingsMenu()
	{
		settingsMenuObject.SetActive(true);
	}

	void Update()
	{
		if (Input.GetKeyDown(settingsMenuKey))
			settingsMenuObject.SetActive(!settingsMenuObject.activeSelf);
	}
}
