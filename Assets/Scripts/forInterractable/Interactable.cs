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
            if (chestInventory != null)
            {
                //chestInventory.GetRandomChestInventory();
            }
        }

        if (thisTransformLayerName == "Pickable")
        {
            //Debug.Log($"layer name {thisTransformLayerName}");
            Pickable pickableObj = GetComponent<Pickable>();
            if (pickableObj != null)
            {
                ////Debug.Log($"obj name {pickableObj.name}");
                //pickableObj.DestroyWhenInteracted();
                
            }
        }
    }
}
