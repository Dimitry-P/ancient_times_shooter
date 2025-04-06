using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;


public class Panel_MouseSens : MonoBehaviour
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
        mouseSensSlider.value = GameController.instance.settingsManager.ControlDTO.mouseSens;
        mouseSensTMP.text = mouseSensSlider.value.ToString();

        // ��������� ��������� ��� ���������� ������ ��� ��������� �������� ��������
        mouseSensSlider.onValueChanged.AddListener(UpdateMouseSensText);
    }

    private void UpdateMouseSensText(float value)
    {
        // ��������� �������� �� ������ ����� ����� �������
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        mouseSensTMP.text = roundedValue.ToString("F1"); // ����������� ����� � ����� ������ ����� �������

        
        if (GameController.instance.settingsManager.ControlDTO.mouseSens != roundedValue)
        {
            //settingsController.applaySettingsBttn.Set
            GameController.instance.settingsManager.ControlDTO.mouseSens = roundedValue;

            OnSettingsChanged();
        }
    }


}
