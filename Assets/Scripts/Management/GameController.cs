using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Button startButton; // Кнопка старта
    public static GameController instance;

    public SettingsManager settingsManager;
    public SceneController sceneController;
    private async void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        settingsManager = new SettingsManager();
        await settingsManager.SetSettings();

        sceneController = new SceneController();

        Debug.Log($"mouseSens {settingsManager.ControlDTO.mouseSens}");

    }

    void Start()
    {
        // Подключаем обработчик события нажатия на кнопку "Старт"
        startButton.onClick.AddListener(OnStartButtonClicked);
   
        Screen.fullScreen = true;
        Screen.SetResolution(1920, 1080, true);
    }
    
    void OnStartButtonClicked()
    {
        // Переключаем в полноэкранный режим
        Screen.fullScreen = true;
        Debug.Log("Полноэкранный режим включен.");

        // Загружаем игровую сцену
        sceneController.LoadScene();
    }
}
