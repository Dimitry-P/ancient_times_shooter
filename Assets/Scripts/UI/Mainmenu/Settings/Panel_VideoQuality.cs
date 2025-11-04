using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_VideoQuality : MonoBehaviour
{
    [SerializeField] private Button lowerBttn;
    [SerializeField] private Button higherBttn;
    [SerializeField] private TMP_Text textQuality;

    private string[] videoQualities = { };
    private sbyte videoQualityIndex = 0;
    [HideInInspector] public string currentVideoQuality;

    [SerializeField] private SettingsController settingsController;


    private void Awake()
    {
        videoQualities = QualitySettings.names;
    }

    void Start()
    {
        textQuality.text = GameSettigsController.instance.settingsManager.VideoDTO.quality;

        for (int i = 0; i < videoQualities.Length; i++)
        {
            if (QualitySettings.names[i] == videoQualities[i])
            {
                QualitySettings.SetQualityLevel(i);
            }
        }
        
        lowerBttn.onClick.AddListener(()=>ChangeVideoQuality(-1));
        higherBttn.onClick.AddListener(()=>ChangeVideoQuality(1));
    }
    void ChangeVideoQuality(sbyte d)
    {
        videoQualityIndex += d;

        if (videoQualityIndex < 0)
        {
            videoQualityIndex = 0;
        }
        else if (videoQualityIndex >= videoQualities.Length)
        {
            videoQualityIndex = (sbyte)(videoQualities.Length - 1);
        }

        textQuality.text = videoQualities[videoQualityIndex].ToString();
        currentVideoQuality = videoQualities[videoQualityIndex];

        if (GameSettigsController.instance.settingsManager.VideoDTO.quality != currentVideoQuality)
        {

            GameSettigsController.instance.settingsManager.VideoDTO.quality = currentVideoQuality;

            settingsController.applaySettingsBttn.gameObject.SetActive(true);
        }
    }
}
