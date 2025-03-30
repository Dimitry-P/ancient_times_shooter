using System;
using UnityEngine;

public enum VideoQuality
{
    Low, Medium, High
}

[Serializable]
public class VideoDTO
{
    public int widthScreen = Screen.width;
    public int heightScreen = Screen.height;

    public VideoQuality quality;
}
