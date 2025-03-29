using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;


public class MouseSens : MonoBehaviour
{
    [SerializeField] private TMP_Text mouseSensTMP;
    [SerializeField] private Slider mouseSensSlider;

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
    }
}
