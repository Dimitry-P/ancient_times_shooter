using UnityEngine;
using System.Collections;
public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    void Start()
    {
        Debug.Log(" Fireball spawned: " + gameObject.name);
    }




    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fireball hit: " + other.name);
        Debug.Log("Destroying: " + gameObject.name);
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        if (GetComponent<MeshRenderer>()) GetComponent<MeshRenderer>().enabled = false;
        if (GetComponent<TrailRenderer>()) GetComponent<TrailRenderer>().enabled = false;
        if (GetComponent<ParticleSystem>()) GetComponent<ParticleSystem>().Stop();
        if (GetComponent<ParticleSystem>()) GetComponent<ParticleSystem>().Stop();
        if (GetComponent<TrailRenderer>()) GetComponent<TrailRenderer>().enabled = false;
        Destroy(transform.root.gameObject);
        DestroyImmediate(gameObject);
        Debug.Log("Fireball destroyed!");
        StartCoroutine(CheckIfDestroyed());
    }
    IEnumerator CheckIfDestroyed()
    {
        yield return new WaitForSeconds(1f);
        if (this != null) Debug.Log("Fireball STILL EXISTS!");
        else Debug.Log("Fireball finally gone!");
    }
}