using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ScrollRect inventoryScrollRect;
    public GameObject itemPrefab; // ������ �������� ���������
    [HideInInspector] public List<Pickable> pickAbleItems;

    public void AddItem(Pickable pickableItem)
    {
        pickAbleItems.Add(pickableItem);
        Debug.Log($"items in inventory {pickAbleItems.Count}");

        // ������� ���������� ���������
        foreach (Transform child in inventoryScrollRect.content)
        {
            Destroy(child.gameObject);
        }
        // �������� ������ ��������
        float viewportWidth = inventoryScrollRect.viewport.rect.width;
        // ���������� ����� ��������� �� ������
        foreach (Pickable item in pickAbleItems)
        {
            GameObject newItem = Instantiate(itemPrefab, inventoryScrollRect.content);
            TMP_Text itemText = newItem.GetComponentInChildren<TMP_Text>(); // �������� ��������� ������            

            if (itemText != null)
            {
                itemText.text = item.PickableName; // ������������� ����� �������� (��������������, ��� � Pickable ���� ���� itemName)

                // �������� RectTransform ��� ��������� ������
                RectTransform itemTextRectTransform = itemText.GetComponent<RectTransform>();
                if (itemTextRectTransform != null)
                {
                    // ������������� ������ ������ ������ ������ ��������
                    itemTextRectTransform.sizeDelta = new Vector2(viewportWidth, itemTextRectTransform.sizeDelta.y);
                }
            }
        }
    }
}
