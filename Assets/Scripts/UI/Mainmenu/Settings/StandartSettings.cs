using UnityEngine;

public class StandartSettings
{
    public readonly ControlDTO controlSettingsOnStart;
    public readonly VideoDTO videoSettingsOnStart;
    public readonly AudioDTO audioSettingsOnStart;

    public StandartSettings()
    {
        controlSettingsOnStart = new ControlDTO();
        videoSettingsOnStart = new VideoDTO();
        audioSettingsOnStart = new AudioDTO();


        controlSettingsOnStart.mouseSens = 2.9f;

        audioSettingsOnStart.musicVolume = 5.0f;

        videoSettingsOnStart.widthScreen = Screen.width;
        videoSettingsOnStart.heightScreen = Screen.height;
        videoSettingsOnStart.quality = VideoQuality.Medium;
    }
}
