using UnityEngine;

public class OpenGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenuPanel;
    [SerializeField] private FPSInput _fpsInput;
    bool isMainMenuOpened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameMenuPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMainMenuOpened = !isMainMenuOpened;
            _gameMenuPanel.gameObject.SetActive(isMainMenuOpened);
            Time.timeScale = isMainMenuOpened == true ? 0 : 1;
            _fpsInput.gameObject.SetActive(!isMainMenuOpened);
            Debug.Log("esc");
        }
    }
}
