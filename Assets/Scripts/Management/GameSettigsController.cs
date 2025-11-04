using UnityEngine;
using UnityEngine.UI;

public class GameSettigsController : MonoBehaviour
{
    [SerializeField] private Button startButton; // Кнопка старта
    public static GameSettigsController instance;

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
        startButton.onClick.AddListener(OnStartButtonClicked);
   
        Screen.fullScreen = true;
    }
    
    void OnStartButtonClicked()
    {
        Debug.Log("Полноэкранный режим включен.");
        sceneController.LoadScene();
    }


}
