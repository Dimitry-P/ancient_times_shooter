using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Button startButton; // ������ ������
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
        // ���������� ���������� ������� ������� �� ������ "�����"
        startButton.onClick.AddListener(OnStartButtonClicked);
   
        Screen.fullScreen = true;
        Screen.SetResolution(1920, 1080, true);
    }
    
    void OnStartButtonClicked()
    {
        // ����������� � ������������� �����
        Screen.fullScreen = true;
        Debug.Log("������������� ����� �������.");

        // ��������� ������� �����
        sceneController.LoadScene();
    }
}
