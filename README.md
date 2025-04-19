Метод vs. Свойство: transform.Rotate() — это метод, который изменяет текущее вращение, а transform.rotation — это свойство, которое задает конкретное вращение.

Относительное vs. Абсолютное: transform.Rotate() вращает объект относительно его текущего положения, тогда как transform.rotation устанавливает абсолютное вращение.

Накопление: При использовании transform.Rotate() вращение накапливается, в то время как при установке transform.rotation можно задавать конкретное значение, которое
заменяет текущее.


---
## Вариант 1: Отскок с использованием Rigidbody
### Пример кода
```csharp
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AutoBounceWithRigidbody : MonoBehaviour
{
    public float jumpHeight = 2f; // Высота прыжка
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Устанавливаем начальную скорость для падения
        rb.velocity = new Vector3(0, -Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight), 0);
    }

    void Update()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Формула для начальной скорости прыжка
        float jumpVelocity = Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight);
        
        Vector3 velocity = rb.velocity;
        velocity.y = jumpVelocity;
        rb.velocity = velocity;

        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что мы коснулись земли (можно улучшить проверку)
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
```
Объяснение:

    В методе Start() устанавливаем начальную скорость для падения объекта.
    В методе Update() проверяем, находится ли объект на земле. Если да, то вызываем метод Jump(), который устанавливает вертикальную скорость для прыжка.
    Используем OnCollisionEnter для определения, когда объект приземляется.

##Вариант 2: Отскок с использованием CharacterController
###Пример кода
```csharp

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AutoBounceWithCharacterController : MonoBehaviour
{
    public float jumpHeight = 2f; // Высота прыжка
    public float gravity = -9.81f; // Ускорение свободного падения
    
    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        // Устанавливаем начальную скорость для падения
        verticalVelocity = -Mathf.Sqrt(2 * -gravity * jumpHeight);
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // небольшой отрицательный импульс для удержания контакта с землей
            
            Jump(); // Прыжок при приземлении
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 move = new Vector3(0, verticalVelocity, 0);
        
        controller.Move(move * Time.deltaTime);
    }

    void Jump()
    {
        // Формула для начальной скорости прыжка
        verticalVelocity = Mathf.Sqrt(2 * -gravity * jumpHeight);
    }
}
```

Объяснение:

    В методе Start() устанавливаем начальную скорость для падения.
    В методе Update() проверяем, находится ли объект на земле. Если да, то вызываем метод Jump(), который устанавливает вертикальную скорость для прыжка.
    Используем controller.isGrounded для проверки касания земли и управления движением.
