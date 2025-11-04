using UnityEngine;
using UnityEngine.SceneManagement;
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
        DestroyAllDontDestroyOnLoadObjects();
        startButton.onClick.AddListener(OnStartButtonClicked);
   
        Screen.fullScreen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    void OnStartButtonClicked()
    {
        Debug.Log("Полноэкранный режим включен.");
        sceneController.LoadScene();
    }

    public void DestroyAllDontDestroyOnLoadObjects()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            // Имя внутренней сцены для объектов DontDestroyOnLoad
            if (scene.name == Scenes.MainMenu.ToString())
            {
                GameObject[] roots = scene.GetRootGameObjects();
                foreach (GameObject root in roots)
                {

                    if (root.name == "Goals_Canvas")
                    {
                        Destroy(root);
                    }
                    
                }
            }
        }
    }
}
