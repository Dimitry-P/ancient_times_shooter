using UnityEngine;

public class Pickable : MonoBehaviour
{
    [HideInInspector] public string PickableName = string.Empty;
    public void DestroyWhenInteracted()
    {
        Destroy(gameObject);
    }
}
