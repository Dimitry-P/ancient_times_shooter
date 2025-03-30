using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_VideoQuality : MonoBehaviour, ISettingsObserver
{
    [SerializeField] private Button lowerBttn;
    [SerializeField] private Button higherBttn;
    [SerializeField] private TMP_Text textQuality;

    private VideoQuality[] videoQualities = { VideoQuality.Low, VideoQuality.Medium, VideoQuality.High };
    private sbyte videoQualitiesIndex = 0;
    [HideInInspector] public VideoQuality currentVideoQuality;

    [SerializeField] private SettingsController settingsController;

    void Start()
    {
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

        GameController.instance.settingsManager.VideoDTO  = new VideoDTO();
        GameController.instance.settingsManager.VideoDTO.quality = VideoQuality.Low; // изменить когда по€витс€ сохранение и загрузка

        if (GameController.instance.settingsManager.VideoDTO.quality != currentVideoQuality)
        {

            GameController.instance.settingsManager.VideoDTO.quality = currentVideoQuality;

            OnSettingsChanged();
        }
    }

    public void OnSettingsChanged()
    {
        settingsController.applaySettingsBttn.gameObject.SetActive(true); // ѕоказываем кнопку при изменении настроек
    }
}
