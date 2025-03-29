using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject currentOpenedPanel;
    [SerializeField] private GameObject mainMenuPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button controlsBttn = GetComponent<Button>();
        controlsBttn.onClick.AddListener(GoToMainMenuMethod);
    }

    void GoToMainMenuMethod()
    {
        currentOpenedPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
