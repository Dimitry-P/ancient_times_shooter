
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] public Button applaySettingsBttn;
    [SerializeField] private GameObject Panel_SettingsHeader;
    
    [SerializeField] List<ScrollRect> scrollViewsInSettings;
    List<Button> bttnsInSettingsHeaderPanel;

    void Start()
    {

        bttnsInSettingsHeaderPanel = new List<Button>();

        int index = 0; // для связывания с scrollViewsInSettings
        foreach (Transform item in Panel_SettingsHeader.transform)
        {
            Button bttnInSettingsHeaderPanel = item.GetComponent<Button>();
            if (bttnInSettingsHeaderPanel != null)
            {
                bttnInSettingsHeaderPanel.onClick.AddListener(() => ChangeSettingsCategory(bttnInSettingsHeaderPanel));
                bttnsInSettingsHeaderPanel.Add(bttnInSettingsHeaderPanel);

                // Получаем компонент WindowExpander и связываем со ScrollRect
                WindowExpander windowExpander = bttnInSettingsHeaderPanel.GetComponent<WindowExpander>();
                if (windowExpander != null && index < scrollViewsInSettings.Count)
                {
                    windowExpander.associatedScrollView = scrollViewsInSettings[index];
                }

                index++;
            }
        }

        applaySettingsBttn.gameObject.SetActive(false);
    }

    private void ChangeSettingsCategory(Button clickedButton)
    {
        // Перед тем как открывать, закрываем все ScrollViews
        foreach (var scrollView in scrollViewsInSettings)
        {
            scrollView.gameObject.SetActive(false);
        }

        // Открываем только связанный ScrollView
        WindowExpander windowExpander = clickedButton.GetComponent<WindowExpander>();
        if (windowExpander != null)
        {
            windowExpander.OpenObject();
        }
    }
}
