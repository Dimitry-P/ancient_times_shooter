using NUnit.Framework;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    GameScene,
    MainMenu
}

public class SceneController
{
    public Scenes currentScene;
    public SceneController()
    {
        currentScene = Scenes.MainMenu;        
    }
}
