using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float sensitivityHor = 4.0f;
    void Start()
    {
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
}