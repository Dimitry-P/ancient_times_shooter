using UnityEngine;
using System.Collections;
public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private Rigidbody rb;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed; // ƒвигаем вперЄд
            Debug.Log("Fireball velocity: " + rb.linearVelocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fireball hit: " + other.gameObject.name);
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}