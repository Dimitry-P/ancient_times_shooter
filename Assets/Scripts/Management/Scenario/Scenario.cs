using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario : SingletonBase<Scenario>
{
    private Scenes currentGoal;

    // Цели для GameScene_Tropic
    private int enemiesKilled = 0;
    public int InemiesKilled => enemiesKilled;
    public int totalEnemiesInScene1 = 2;

    // Цели для GameScene_Sands
    private float distanceTraveled = 0f;
    public float DistanceTraveled => distanceTraveled;

    public float TargetDistance { get => targetDistance; }

    private float targetDistance = 10f;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "main_menu")
        {
            currentGoal = Scenes.MainMenu;
        }
        else if (scene.name == "GameScene_Tropic")
        {
            currentGoal = Scenes.GameScene_Tropic;
        }
        else if (scene.name == "GameScene_Sands")
        {
            currentGoal = Scenes.GameScene_Sands;
        }
    }

    public void EnemyKilled()
    {
        if (currentGoal == Scenes.GameScene_Tropic)
        {
            enemiesKilled++;
            Debug.Log($"Уничтожено противников: {enemiesKilled}/{totalEnemiesInScene1}");
            Goals.instance.OnChangeTropicGoal.Invoke();
            if (enemiesKilled >= totalEnemiesInScene1)
            {
                Debug.Log("Цель выполнена: уничтожить всех противников");
            }

        }
    }

    public void PlayerTraveled(float distance)
    {
        if (currentGoal == Scenes.GameScene_Sands)
        {
            distanceTraveled += distance;
            Debug.Log($"Пройдено: {distanceTraveled}/{targetDistance} метров");
            Goals.instance.OnChangeSandsGoal.Invoke();
            if (distanceTraveled >= targetDistance)
            {
                Debug.Log("Цель выполнена: пройти 10 метров");
            }
        }
    }
}
