using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Button startButton; // ������ ������
    public static GameController instance;

    public SettingsManager settingsManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);




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
        SceneManager.LoadScene("GameScene"); // �������� �� ��� ����� ������� �����
    }
}
