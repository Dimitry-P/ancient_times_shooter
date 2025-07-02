using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private enum RotateAround
    {
        aroundX, aroundY, aroundZ
    }

    [SerializeField] private float _angleSpeed;
    [SerializeField] private RotateAround _rotateAround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = Vector3.zero;
        switch (_rotateAround)
        {
            case RotateAround.aroundX:
                axis = Vector3.right;
                break;
            case RotateAround.aroundY:
                axis = Vector3.up;
                break;
            case RotateAround.aroundZ:
                axis = Vector3.forward;
                break;
        }

        transform.Rotate(axis, _angleSpeed * Time.deltaTime);
    }
}
