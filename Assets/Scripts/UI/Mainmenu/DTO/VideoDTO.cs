using UnityEngine;

public enum VideoQuality
{
    Low, Medium, High
}

public class VideoDTO
{
    public int widthScreen;
    public int heightScreen;

    public VideoQuality quality;
}
