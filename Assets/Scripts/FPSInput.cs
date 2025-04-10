using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Movement Settings")]
    public float speed = 6.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    private float originalSpeed;

    [Header("Mouse Settings")]
    public float sensitivityHor = 3.5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;
    private bool inventoryPanel_isActive = false;

    [Header("Crouch Settings")]
    public float speed_fromStandToCrouch = 4.0f;
    public float speed_fromCrouchToStand = 3.0f;

    private bool canCrouch = true;
    public float standingHeight = 2.0f; // ������ ��������� � ����
    public float crouchingHeight = 1.0f; // ������ ��������� � �������
    private Vector3 standingCenter = new Vector3(0, 0.0f, 0); // ����� ��������� � ������� ���������
    private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0); // ����� ��������� � ����������
    private bool isCrouching = false; //������������ ��������� ����������


    private Vector3 velocity;
    private bool isGrounded;



    void Start()
    {
        originalSpeed = speed;
        characterController = GetComponent<CharacterController>();
        standingHeight = characterController.height;

        if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
        {
            sensitivityHor = GameController.instance.settingsManager.ControlDTO.mouseSens;
        }
    }

    void Update()
    {
        // ���������, �� ����� �� �����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // �������� ������������ �������� ��� ������� �����
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // �������� �� �����������
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        // �������� �� ����������� � �����/�����
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * deltaX + transform.forward * deltaZ;
        characterController.Move(move * speed * Time.deltaTime);

        // ������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ��������� ����������
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // ��������/�������� ���������
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel_isActive = !inventoryPanel_isActive;
            inventoryPanel.SetActive(inventoryPanel_isActive);
        }

        // ����������
        if (canCrouch)
        {
            HandleCrouch();
        }

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

        // ���, ���������� � ������� ��������� ������ ���������� � ������
        characterController.height = Mathf.Lerp(characterController.height, targetHeight, Time.deltaTime * transitionSpeed);
        characterController.center = Vector3.Lerp(characterController.center, targetCenter, Time.deltaTime * transitionSpeed);
    }
}


#region crouch with corutines
/*
 using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Movement Settings")]
    public float speed = 6.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    private float originalSpeed;

    [Header("Mouse Settings")]
    public float sensitivityHor = 3.5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;
    private bool inventoryPanel_isActive = false;

    [Header("Crouch Settings")]
    
    public float crouchHeight = 1.0f;
    public float standingHeight = 2.0f;
    public float speed_fromStandToCrouch = 4.0f;
    public float speed_fromCrouchToStand = 3.0f;
    public Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    public Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching = false;
    private bool canCrouch = true;
    private Coroutine crouchCoroutine;



    private Vector3 velocity;
    private bool isGrounded;



    void Start()
{
    originalSpeed = speed;
    characterController = GetComponent<CharacterController>();
    standingHeight = characterController.height;

    if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
    {
        sensitivityHor = GameController.instance.settingsManager.ControlDTO.mouseSens;
    }
}

void Update()
{
    // ���������, �� ����� �� �����
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    // �������� ������������ �������� ��� ������� �����
    if (isGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }

    // �������� �� �����������
    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

    // �������� �� ����������� � �����/�����
    float deltaX = Input.GetAxis("Horizontal");
    float deltaZ = Input.GetAxis("Vertical");

    Vector3 move = transform.right * deltaX + transform.forward * deltaZ;
    characterController.Move(move * speed * Time.deltaTime);

    // ������
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    // ��������� ����������
    velocity.y += gravity * Time.deltaTime;
    characterController.Move(velocity * Time.deltaTime);

    // ��������/�������� ���������
    if (Input.GetKeyDown(KeyCode.I))
    {
        inventoryPanel_isActive = !inventoryPanel_isActive;
        inventoryPanel.SetActive(inventoryPanel_isActive);
    }

    // ����������
    // ������������ ��������� ������
    if (canCrouch)
    {
        if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftControl)))
        {

            
            if (isCrouching)
            {
                if (crouchCoroutine == null) // ���������, �� �������� �� ��� ��������
                {

                    crouchCoroutine = StartCoroutine(ChangeHeight(speed_fromCrouchToStand));
                }
            }
            else
            {
                if (crouchCoroutine == null) // ���������, �� �������� �� ��� ��������
                {

                    crouchCoroutine = StartCoroutine(ChangeHeight(speed_fromStandToCrouch));
                }
            }
        }
    }

}


    private IEnumerator ChangeHeight(float speed)
    {
        float elapsedTime = 0f;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;

        float currentHeight = characterController.height;

        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;

        Vector3 currentCenter = characterController.center;

        while (elapsedTime < speed)
        {
            float t = elapsedTime / speed;

            characterController.height = Mathf.Lerp(currentHeight, targetHeight, t);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �������� �� ��, ��� ������ � ����� ����������� ����� � �������� ��������
        characterController.height = targetHeight;
        characterController.center = targetCenter;
        isCrouching = !isCrouching;
        crouchCoroutine = null;
    }

}

 */
#endregion