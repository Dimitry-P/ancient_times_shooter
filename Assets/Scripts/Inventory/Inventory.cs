using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ScrollRect inventoryScrollRect;
    public GameObject itemPrefab; // Префаб элемента инвентаря
    [HideInInspector] public List<Pickable> pickAbleItems;

    public void AddItem(Pickable pickableItem)
    {
        pickAbleItems.Add(pickableItem);
        Debug.Log($"items in inventory {pickAbleItems.Count}");

        // Очистка предыдущих элементов
        foreach (Transform child in inventoryScrollRect.content)
        {
            Destroy(child.gameObject);
        }
        // Получаем ширину вьюпорта
        float viewportWidth = inventoryScrollRect.viewport.rect.width;
        // Добавление новых элементов из списка
        foreach (Pickable item in pickAbleItems)
        {
            GameObject newItem = Instantiate(itemPrefab, inventoryScrollRect.content);
            TMP_Text itemText = newItem.GetComponentInChildren<TMP_Text>(); // Получаем компонент текста            

            if (itemText != null)
            {
                itemText.text = item.PickableName; // Устанавливаем текст элемента (предполагается, что у Pickable есть поле itemName)

                // Получаем RectTransform для настройки ширины
                RectTransform itemTextRectTransform = itemText.GetComponent<RectTransform>();
                if (itemTextRectTransform != null)
                {
                    // Устанавливаем ширину текста равной ширине вьюпорта
                    itemTextRectTransform.sizeDelta = new Vector2(viewportWidth, itemTextRectTransform.sizeDelta.y);
                }
            }
        }
    }
}
