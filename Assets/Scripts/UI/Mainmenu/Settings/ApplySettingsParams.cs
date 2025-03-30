using UnityEngine;
using UnityEngine.UI;

public class ApplySettingsParams : MonoBehaviour
{
    Button applaySettingsBttn;

    [SerializeField] private SettingsManager settingsManager;

    void Start()
    {
        applaySettingsBttn = GetComponent<Button>();
        applaySettingsBttn.onClick.AddListener(ApplyChangedSettings);
    }


    private void ApplyChangedSettings()
    {
        applaySettingsBttn.gameObject.SetActive(false);

        //Debug.Log($"{ GameController.instance.settingsManager.VideoDTO.quality.ToString()}");
        //добавить логику записи параметров в класс для хранения Settings
    }

    //private void OnDisable()
    //{
    //    Debug.Log("changes");
    //}
}
