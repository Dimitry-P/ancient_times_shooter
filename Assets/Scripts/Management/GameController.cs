using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    private SceneController sceneController;
    public SettingsDTO SettingsDTO;

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
