using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PickableSO", menuName = "Scriptable Objects/PickableSO")]
public class PickableSO : ScriptableObject
{
    public enum ItemType
    {
        Weapone,
        Posion,
        Food
    }
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
    public GameObject prefab;
}
