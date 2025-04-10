using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;

    [Header("Movement Settings")]
    public float speed = 6.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

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
    public float crouchSpeed = 3.0f;
    private bool isCrouching = false;
    private float originalSpeed;

    private Vector3 velocity;
    private bool isGrounded;

    private float crouchTransitionSpeed = 6f; // скорость приседания / вставания
    private float targetHeight;
    private Vector3 targetCenter;



    void Start()
    {
        originalSpeed = speed;
        _charController = GetComponent<CharacterController>();
        standingHeight = _charController.height;

        targetHeight = standingHeight;
        targetCenter = new Vector3(0, standingHeight / 2f, 0);

        if (GameController.instance != null && GameController.instance.settingsManager != null && GameController.instance.settingsManager.ControlDTO != null)
        {
            sensitivityHor = GameController.instance.settingsManager.ControlDTO.mouseSens;
        }
    }

    void Update()
    {
        // Проверяем, на земле ли игрок
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Обнуляем вертикальную скорость при касании земли
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Вращение по горизонтали
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        // Движение по горизонтали и вперёд/назад
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * deltaX + transform.forward * deltaZ;
        _charController.Move(move * speed * Time.deltaTime);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        _charController.Move(velocity * Time.deltaTime);

        // Открытие/закрытие инвентаря
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel_isActive = !inventoryPanel_isActive;
            inventoryPanel.SetActive(inventoryPanel_isActive);
        }

        // Приседание
        // Перепроверим изменения высоты
        if (Input.GetKey(KeyCode.C))
        {
            if (!isCrouching)
            {
                isCrouching = true;
                _charController.height = crouchHeight; // Например, 1.0f
                _charController.center = new Vector3(0, crouchHeight / 2f, 0);
                //speed = crouchSpeed;
            }
        }
        else
        {
            if (isCrouching)
            {
                isCrouching = false;
                _charController.height += standingHeight; // Например, 2.0f
                _charController.center += new Vector3(0, standingHeight - 2f, 0);
                //speed = originalSpeed;
            }
        }
    }
}
