using UnityEngine;
using System.Collections;
using System.IO;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    private OnStartSettings onStartSettings; //���� ����� �������� �� ��������� ������� ������� ������� ����
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float sensitivityHor = 4.0f;

    void Start()
    {
        #region ��� ���� ���������
        onStartSettings = new OnStartSettings();
        sensitivityHor = onStartSettings.controlSettingsOnStart.mouseSens;
        #endregion

        _charController = GetComponent<CharacterController>();
    
        string path = Path.Combine(Application.persistentDataPath, "settings.json");

        //// ���� ���� ���������� � ��������� ���������
        //if (File.Exists(path))
        //{
        //    string json = File.ReadAllText(path);
        //    GameSettings settings = JsonUtility.FromJson<GameSettings>(json);

        //    // ��������� ���������
        //    //Screen.fullScreen = settings.fullscreen;
        //    AudioListener.volume = settings.volume;

        //    Debug.Log("��������� ���������: fullscreen=" + settings.fullscreen + ", volume=" + settings.volume);
        //}
        //else
        //{
        //    Debug.LogWarning("���� �������� �� ������! ������������ ����������� ��������.");
        //}
        //Debug.Log("���� �������� ������: " + File.Exists(path));
        //Debug.Log("���������� �����: " + File.ReadAllText(path));
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}