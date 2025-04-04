using UnityEngine;
using System;
using System.IO;

public class SceneControllerForEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    void Start()
    {
        Screen.fullScreen = true; // Включаем полноэкранный режим
    }


    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab);
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = UnityEngine.Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}

// Класс настроек
[System.Serializable]
public class GameSettings
{
    public float volume;
    public bool fullscreen;
}
