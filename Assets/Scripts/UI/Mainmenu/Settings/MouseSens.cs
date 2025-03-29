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

        // Добавляем слушатель для обновления текста при изменении значения слайдера
        mouseSensSlider.onValueChanged.AddListener(UpdateMouseSensText);
    }

    private void UpdateMouseSensText(float value)
    {
        // Округляем значение до одного знака после запятой
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        mouseSensTMP.text = roundedValue.ToString("F1"); // Форматируем текст с одним знаком после запятой
    }
}
