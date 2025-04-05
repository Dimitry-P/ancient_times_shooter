using UnityEngine;

public class OnStartSettings
{
    public readonly ControlDTO controlSettingsOnStart;
    public readonly VideoDTO videoSettingsOnStart;

    public OnStartSettings()
    {
        controlSettingsOnStart = new ControlDTO();
        videoSettingsOnStart = new VideoDTO();

        controlSettingsOnStart.mouseSens = 3.5f;
        controlSettingsOnStart.musicValue = 5.0f;

        videoSettingsOnStart.widthScreen = Screen.width;
        videoSettingsOnStart.heightScreen = Screen.height;
        videoSettingsOnStart.quality = VideoQuality.Medium;
    }
}
