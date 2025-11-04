using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_VideoResolution : MonoBehaviour
{
    [SerializeField] private Button lowerBttn;
    [SerializeField] private Button higherBttn;
    [SerializeField] private TMP_Text textResolution;

    private Vector2[] videoResolutions = { };
    private sbyte videoResIndex = 0;
    [HideInInspector] public Vector2 currentVideoRes;

    [SerializeField] private SettingsController settingsController;


    private void Awake()
    {
        videoResolutions = Resolutions.resolutions;
    }

    void Start()
    {
        textResolution.text = GameSettigsController.instance.settingsManager.VideoDTO.widthScreen.ToString() + "x" + GameSettigsController.instance.settingsManager.VideoDTO.heightScreen.ToString();
        lowerBttn.onClick.AddListener(()=>ChangeVideoQuality(-1));
        higherBttn.onClick.AddListener(()=>ChangeVideoQuality(1));
    }
    void ChangeVideoQuality(sbyte d)
    {
        videoResIndex += d;

        if (videoResIndex < 0)
        {
            videoResIndex = 0;
        }
        else if (videoResIndex >= videoResolutions.Length)
        {
            videoResIndex = (sbyte)(videoResolutions.Length - 1);
        }

        textResolution.text = (int)videoResolutions[videoResIndex].x + "x" + (int)videoResolutions[videoResIndex].y;
        currentVideoRes = videoResolutions[videoResIndex];

        if (GameSettigsController.instance.settingsManager.VideoDTO.widthScreen != (int)currentVideoRes.x)
        {

            GameSettigsController.instance.settingsManager.VideoDTO.widthScreen = (int)videoResolutions[videoResIndex].x;
            GameSettigsController.instance.settingsManager.VideoDTO.heightScreen = (int)videoResolutions[videoResIndex].y;

            settingsController.applaySettingsBttn.gameObject.SetActive(true);
        }
    }
}
