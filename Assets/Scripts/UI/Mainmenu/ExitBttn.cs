using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitBttn : MonoBehaviour
{
    Button exitBttn;

    private void Start()
    {
        exitBttn = GetComponent<Button>();
        exitBttn.onClick.AddListener(Quit);
    }
    private void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    
}
