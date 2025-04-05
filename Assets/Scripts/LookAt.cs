using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Camera cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraMain.transform);

    }
}
