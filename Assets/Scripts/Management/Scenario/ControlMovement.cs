using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    private float accumulatedDistance = 0f; //накопленное расстояние
    [SerializeField] private CharacterController controller;
    private float threshold = 0.1f; //порог для отчёта

    void Start()
    {
        lastPosition = controller.transform.position;
        Debug.Log($"accumulatedDistance{accumulatedDistance}");
    }

    void Update()
    {
        Vector3 currentPosition = controller.transform.position;
    

        float deltaDist = Vector3.Distance(currentPosition, lastPosition);
        accumulatedDistance += deltaDist;

        if (accumulatedDistance >= threshold)
        {
            Debug.Log($"aaaaaaaaaaa{currentPosition}");
            Scenario.instance.PlayerTraveled(accumulatedDistance);
            // сброс счётчика
            accumulatedDistance = 0f;
        }

        lastPosition = currentPosition;
    }
}
