using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Camera _playerEyes;

    [Header("Movement Settings")]
    public float slowRunSpeed = 4.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    // Переменная для хранения направления движения перед прыжком
    private Vector3 jumpDirection;
    private float originalSpeed;
    // Переменные для хранения первоначальных значений скорости
    private float originalVelocityX;
    private float originalVelocityZ;

    [Header("Mouse Settings")]
    public float sensitivityHor = 3.5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;
    private bool inventoryPanel_isActive = false;

    [Header("Crouch Settings")]
    public float speed_fromStandToCrouch = 4.0f;
    public float speed_fromCrouchToStand = 3.0f;

    private bool canCrouch = true;
    public float standingHeight = 2.0f; // высота персонажа в стоя
    public float crouchingHeight = 1.0f; // высота персонажа в приседе
    private Vector3 standingCenter; //= new Vector3(0, 0.0f, 0); // центр персонажа в стоячем положении
    private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0); // центр персонажа в приседании
    private bool isCrouching = false; //отслеживание состояния приседания


    private Vector3 velocity;
    private bool isGrounded;

    #region animation
    [SerializeField] private Animator _animator;
    private string _slowRunningAnimName = "SlowRunning";
    private string _idleAnimName = "StandingIdle";
    #endregion



    void Start()
    {
        originalSpeed = slowRunSpeed;
        characterController = GetComponent<CharacterController>();
        standingCenter = characterController.center;
        standingHeight = characterController.height;

        //_playerEyes.transform.position = new Vector3(standingCenter.x, standingCenter.y + 0.911f, standingCenter.z);

        if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
        {
            sensitivityHor = GameController.instance.settingsManager.ControlDTO.mouseSens;
        }

        originalVelocityX = velocity.x;
        originalVelocityZ = velocity.z;


    }

    void Update()
    {
        // Проверяем, на земле ли игрок
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Обнуляем вертикальную скорость при касании земли
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            velocity.x = originalVelocityX;
            velocity.z = originalVelocityZ;
        }

        // Вращение по горизонтали
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        // Движение по горизонтали и вперёд/назад
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");


        Vector3 moveDirection = transform.right * deltaX + transform.forward * deltaZ;
        if (isGrounded)
        {
            
            jumpDirection = moveDirection; // Сохраняем направление перед прыжком
            characterController.Move(moveDirection * slowRunSpeed * Time.deltaTime);
        }
        if (!isGrounded)
        {
            jumpDirection.Normalize(); // Нормализуем направление перед прыжком для корректного движения во время прыжка
            velocity.x = jumpDirection.x * slowRunSpeed;
            velocity.z = jumpDirection.z * slowRunSpeed;
        }
        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Открытие/закрытие инвентаря
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel_isActive = !inventoryPanel_isActive;
            inventoryPanel.SetActive(inventoryPanel_isActive);
        }

        // Приседание
        if (canCrouch)
        {
            HandleCrouch();
        }

        //animations
        if (moveDirection != Vector3.zero && isGrounded && !isCrouching)
        {
            _animator.Play(_slowRunningAnimName);
        }
        if (moveDirection == Vector3.zero)
        {
            _animator.Play(_idleAnimName);
        }
    }

    private void LateUpdate()
    {
        _playerEyes.transform.position = new Vector3(
            characterController.transform.position.x,
            characterController.transform.position.y + characterController.height - 0.089f,
            characterController.transform.position.z);
    }
    private void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!isCrouching)
            {
                isCrouching = true;
            }
        }
        else
        {
            if (isCrouching)
            {
                isCrouching = false;
            }
        }

        float targetHeight = isCrouching ? crouchingHeight : standingHeight;
        Vector3 targetCenter = isCrouching ? crouchingCenter : standingCenter;

        float transitionSpeed = isCrouching ? speed_fromStandToCrouch : speed_fromCrouchToStand;

        // Вот, собственно и плавное изменение высоты коллайдера и центра
        characterController.height = Mathf.Lerp(characterController.height, targetHeight, Time.deltaTime * transitionSpeed);
        characterController.center = Vector3.Lerp(characterController.center, targetCenter, Time.deltaTime * transitionSpeed);
    }
}

