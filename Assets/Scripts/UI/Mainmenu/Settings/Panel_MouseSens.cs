using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;


public class Panel_MouseSens : MonoBehaviour, ISettingsObserver
{
    [SerializeField] private TMP_Text mouseSensTMP;
    [SerializeField] private Slider mouseSensSlider;

    [SerializeField] private SettingsController settingsController;

    public void OnSettingsChanged()
    {
        settingsController.applaySettingsBttn.gameObject.SetActive(true); // ���������� ������ ��� ��������� ��������
    }

    void Start()
    {
        mouseSensSlider.value = 0.5f;
        mouseSensTMP.text = mouseSensSlider.value.ToString();

        // ��������� ��������� ��� ���������� ������ ��� ��������� �������� ��������
        mouseSensSlider.onValueChanged.AddListener(UpdateMouseSensText);
    }

    private void UpdateMouseSensText(float value)
    {
        // ��������� �������� �� ������ ����� ����� �������
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        mouseSensTMP.text = roundedValue.ToString("F1"); // ����������� ����� � ����� ������ ����� �������

        
        GameController.instance.settingsManager.ControlDTO = new ControlDTO();
        GameController.instance.settingsManager.ControlDTO.mouseSens = 0;
        if (GameController.instance.settingsManager.ControlDTO.mouseSens != roundedValue)
        {
            //settingsController.applaySettingsBttn.Set
            GameController.instance.settingsManager.ControlDTO.mouseSens = roundedValue;

            OnSettingsChanged();
        }
    }


}
