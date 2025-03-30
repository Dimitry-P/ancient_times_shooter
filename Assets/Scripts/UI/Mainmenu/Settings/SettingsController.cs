
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class SettingsController : MonoBehaviour
{
    [SerializeField] public Button applaySettingsBttn;
    [SerializeField] private GameObject Panel_SettingsHeader;
    
    List<UnityEngine.UI.ScrollRect> scrollViewsInSettings;
    List<Button> bttnsInSettingsHeaderPanel;

    [SerializeField] private SettingsManager settingsManager;

    void Start()
    {
        scrollViewsInSettings = new List<ScrollRect>();
        foreach (Transform item in transform)
        {
            ScrollRect scrollView = item.GetComponent<ScrollRect>();
            if (item.name.StartsWith("Settings_ScrollView"))
            {
                scrollViewsInSettings.Add(scrollView);
            }
        }

        bttnsInSettingsHeaderPanel = new List<Button>();
        foreach (Transform item in Panel_SettingsHeader.transform)
        {
            Button buttonInSettings = item.GetComponent<Button>();
            if (buttonInSettings != null)
            {
                string buttonText = buttonInSettings.GetComponentInChildren<TMP_Text>().text;
                buttonInSettings.onClick.AddListener(() => ChangeSettingsCategory(buttonText));
                bttnsInSettingsHeaderPanel.Add(buttonInSettings);
            }
        }

        applaySettingsBttn.gameObject.SetActive(false);
        //applaySettingsBttn.onClick.AddListener(OnApplyButtonClicked);
    }

    private void ChangeSettingsCategory(string buttonText)
    {
        foreach (ScrollRect scrollView in scrollViewsInSettings)
        {
            if (scrollView.name.Contains(buttonText))
            {
                scrollView.gameObject.SetActive(true);
            }
            else
            {
                scrollView.gameObject.SetActive(false);
            }
        }
    }

}
