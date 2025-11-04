using UnityEngine;

public class OpenGameMenu : MonoBehaviour
{
    [SerializeField] private Canvas _gameMenuPanel;
    [SerializeField] private FPSInput _fpsInput;
    [SerializeField] private MouseLook _mouseLook;
    bool _isMainMenuOpened;
    private bool _isPaused;


    private void Awake()
    {

    }
    void Start()
    {
        _gameMenuPanel.gameObject.SetActive(false);
        Debug.Log($"_isMainMenuOpened {_isMainMenuOpened}");
        Debug.Log($"_isPaused {_isPaused}");
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isMainMenuOpened = !_isMainMenuOpened;
            _gameMenuPanel.gameObject.SetActive(_isMainMenuOpened);
            Time.timeScale = _isMainMenuOpened == true ? 0 : 1;
            _fpsInput.enabled = !_isMainMenuOpened;
            _mouseLook.enabled = !_isMainMenuOpened;
            if (_isMainMenuOpened)
            {
                _isPaused= true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                _isPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            Debug.Log("esc");
            Debug.Log($"_isPaused {_isPaused}");
        }
    }
}
