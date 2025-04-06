using UnityEngine;


public class Interactable : MonoBehaviour, IInteractable
{

    public void Interraction()
    {
        var layer = gameObject.layer;
        
        string thisTransformLayerName = LayerMask.LayerToName(layer);
        //Debug.Log($"layer name {thisTransformLayerName}");
        if (thisTransformLayerName == "Chests")
        { 
            //Debug.Log($"layer name {thisTransformLayerName}");
            var chestInventory = GetComponent<ChestInventory>();
            chestInventory.GetRandomChestInventory();
        }
    }
}
