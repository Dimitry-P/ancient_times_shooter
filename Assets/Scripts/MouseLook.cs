using UnityEngine;
using System.Collections;
public class MouseLook : MonoBehaviour
{
    public float sensitivityHor = 3.5f;
    public float sensitivityVert = 4.0f;

    public float minimumVert = -85.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0;
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    void Start()
    {
        if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
        {
            sensitivityVert = GameController.instance.settingsManager.ControlDTO.mouseSens;
        }
        else
        {
            Debug.LogWarning("GameController или его компоненты не инициализированы.");
            sensitivityVert = 3.5f;
        }


        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;


    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}