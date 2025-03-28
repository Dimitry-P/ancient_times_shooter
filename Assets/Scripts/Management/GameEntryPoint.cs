using UnityEngine;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    public GameEntryPoint()
    {
            
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame() //���������� �� ���� � ����� ����� ����������� ���� � ������ ������� ����������� ������ �����
        //� ���� ������ ������ ������������� �����-�� ������� ��������� �� ������� ����
        //� ������� ���������� FPS
    {
        if (_instance == null)
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep; //�������� ��� �������, ����� ����� �� ���, ���� �� ������ � �����

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

    }

    private void RunGame()
    {

    }
}
