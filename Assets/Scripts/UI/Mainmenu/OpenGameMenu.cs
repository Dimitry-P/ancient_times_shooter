using UnityEngine;

public class OpenGameMenu : MonoBehaviour
{
    bool isMainMenuOpened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("esc update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMainMenuOpened = !isMainMenuOpened;
            transform.gameObject.SetActive(isMainMenuOpened);
            Debug.Log("esc");
        }
    }
}
