using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    

    private SceneController sceneController;

    public SettingsDTO SettingsDTO;
    private SettingsData _settingsData;
    public SettingsData SettingsData { get { return _settingsData; } set{ _settingsData = value; } }


    public SettingsManager settingsManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Object.DontDestroyOnLoad(this.gameObject);
            sceneController = new SceneController();

        }
        else 
        {
            Destroy(this.gameObject);
            return;
        }

    }


    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(nameof(Scenes.GameScene));
        instance.sceneController.currentScene = (Scenes)SceneManager.GetActiveScene().buildIndex;
    }
}
