using UnityEngine;
using System.Collections;
public class Fireball : MonoBehaviour
{
    public float speed = 30.0f;
    public int damage = 1;

    private Rigidbody rb;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed; // ƒвигаем вперЄд
            //Debug.Log("Fireball velocity: " + rb.linearVelocity);
        }
        Destroy(gameObject,2.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Fireball hit: " + other.gameObject.name);
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        if (target != null)
        {
            target.ReactToHit();
        }
        Destroy(gameObject);
    }
}