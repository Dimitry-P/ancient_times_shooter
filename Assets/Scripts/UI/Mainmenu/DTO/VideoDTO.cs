using System;
using UnityEngine;

[Serializable]
public enum qSettings
{
    PC_low,
    PC_medium,
    PC_high
}
[Serializable]
public static class Resolutions
{
    public static Vector2[] resolutions =
    {
        new Vector2(800, 600),
        new Vector2(1280, 960),
        new Vector2(1920, 1080),
        new Vector2(2560, 1440)
    };
}

[Serializable]
public class VideoDTO
{
    public int widthScreen = Screen.width;
    public int heightScreen = Screen.height;

    public string quality;
}
