using UnityEngine;
using UnityEngine.SceneManagement;



public class PortalToAnotherScene : MonoBehaviour
{
    public Scenes _scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<CharacterController>())
        {
            SceneManager.LoadSceneAsync(_scene.ToString());
        }
    }
}
