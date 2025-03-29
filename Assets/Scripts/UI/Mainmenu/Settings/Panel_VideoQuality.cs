using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_VideoQuality : MonoBehaviour
{
    [SerializeField] private Button lowerBttn;
    [SerializeField] private Button higherBttn;
    [SerializeField] private TMP_Text textQuality;

    private VideoQuality[] videoQualities = { VideoQuality.Low, VideoQuality.Medium, VideoQuality.High };
    private sbyte videoQualitiesIndex = 0;
    [HideInInspector] public VideoQuality currentVideoQuality;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //textQuality.text = videoQualities[videoQualitiesIndex];
        textQuality.text = VideoQuality.Low.ToString();
        lowerBttn.onClick.AddListener(()=>ChangeVideoQuality(-1));
        higherBttn.onClick.AddListener(()=>ChangeVideoQuality(1));
    }
    void ChangeVideoQuality(sbyte d)
    {
        videoQualitiesIndex += d;

        if (videoQualitiesIndex < 0)
        {
            videoQualitiesIndex = 0;
        }
        else if (videoQualitiesIndex >= videoQualities.Length)
        {
            videoQualitiesIndex = (sbyte)(videoQualities.Length - 1);
        }

        textQuality.text = videoQualities[videoQualitiesIndex].ToString();
        currentVideoQuality = videoQualities[videoQualitiesIndex];

        //if (GameController.instance.SettingsData.video.quality != currentVideoQuality)
        //{
        //    Debug.Log("changes");
        //}
    }
}
