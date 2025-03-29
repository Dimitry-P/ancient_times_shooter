using UnityEngine;
using UnityEngine.UI;

public class ApplySettingsParams : MonoBehaviour
{
    Button apply;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apply = GetComponent<Button>();
        apply.onClick.AddListener(ApplyChangedSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyChangedSettings()
    {

    }
}
