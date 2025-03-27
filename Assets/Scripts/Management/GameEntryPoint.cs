using UnityEngine;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    public GameEntryPoint()
    {
            
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame() //независимо от того с какой сцены запускается игра в первую очередь запускается данный метод
        //в этом методе хорошо устанавливать какие-то игровые настройки до запуска игры
        //к примеру установить FPS
    {
        if (_instance == null)
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep; //подходит для мобилок, чтобы экран не гас, если не тыкаем в экран

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

    }

    private void RunGame()
    {

    }
}
