using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float sensitivityHor = 3.5f;

    #region Jump
    private Vector3 velocity;
    private bool isGrounded;
    public float jumpHeight = 2f;
    #endregion

    void Start()
    {
        if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
        {
            sensitivityHor = GameController.instance.settingsManager.ControlDTO.mouseSens;
        }
        else
        {
            Debug.LogWarning("GameController или его компоненты не инициализированы.");
            sensitivityHor = 3.5f;
        }

        _charController = GetComponent<CharacterController>();
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

    private void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // Сбросить вертикальную скорость при приземлении

        velocity.y += gravity * Time.deltaTime;

        // Перемещение контроллера с учетом вертикальной скорости
        _charController.Move(velocity * Time.deltaTime);
    }
}