using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] private GameObject requiredPanel;
    [SerializeField] private GameObject currentPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button controlsBttn = GetComponent<Button>();
        controlsBttn.onClick.AddListener(OpenControlsMethod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenControlsMethod()
    {
        currentPanel.SetActive(false);
        requiredPanel.SetActive(true);        
    }
}
