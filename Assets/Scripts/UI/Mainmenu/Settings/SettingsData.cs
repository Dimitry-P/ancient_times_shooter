using UnityEngine;

public class SettingsData
{
    public ControlDTO control;

    public VideoDTO video;
    public SettingsData()
    {
            control = new ControlDTO();
        video = new VideoDTO();
    }
}
