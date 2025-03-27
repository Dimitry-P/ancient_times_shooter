using UnityEngine;
using UnityEngine.InputSystem;

public class BGMenu : MonoBehaviour
{
    string horMouseDirection = "Horizontal";
    string vertMouseDirection = "Vertical";
    [SerializeField] float speed = 0.5f;
    private Vector3 lastMousePosition;

    void Start()
    {
        SetCursorToCenter();
        // �������������� ��������� ������� �������
        lastMousePosition = Input.mousePosition;
    }
    void Update()
    {
        Vector3 currentMousePos = Input.mousePosition;

        var mousePath = currentMousePos - lastMousePosition;
       

        if (mousePath.sqrMagnitude > 0)
        {
            transform.Translate(new Vector3(mousePath.x * speed, mousePath.y/2, 0) * -1 * Time.deltaTime);
        }
        lastMousePosition = currentMousePos;
    }

    void SetCursorToCenter()
    {
        // �������� ������� ������
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ������������� ������� ������� � ����� ������
        //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // ���������� ������, ���� �� ��� ����������
        //Cursor.lockState = CursorLockMode.Locked; // ��������� ������ � ������ ������
        //Cursor.visible = false; // �������� ������ (�� �������)

        // ������������� ������ � ����� ������
        Mouse.current.WarpCursorPosition(new Vector2(screenWidth / 2, screenHeight / 2));
    }
}
