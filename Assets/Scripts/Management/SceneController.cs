using UnityEngine.SceneManagement;

public enum Scenes
{
    MainMenu,
    GameScene_Tropic,
    GameScene_Sands,
    Final_Subtiles
}

public class SceneController
{
    public Scenes currentScene;
    public SceneController()
    {
        currentScene = Scenes.MainMenu;        
    }

    public void LoadScene()
    {
        int indexCurrScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(Scenes.GameScene_Tropic.ToString());
    }
}
