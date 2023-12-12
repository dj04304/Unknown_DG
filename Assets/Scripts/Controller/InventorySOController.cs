using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySOController : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemDataList;
    public List<Image> itemImages;

    private Dictionary<Image, ItemData> imageToItemMap = new Dictionary<Image, ItemData>(); // Dictionary�� �̿��ؼ� Image�� Key������ ItemData�� �����´�.

    private void Start()
    {
        if(itemImages.Count > 0 && itemDataList != null)
        {
            int minCount = Mathf.Min(itemImages.Count, itemDataList.Count); // List index Exception�� ���� ������ �ּڰ��� ItemDataSo�� �����ش�.

            Debug.Log("minCount " + minCount);

            for (int i = 0; i < minCount; i++)
            {
                Image image = itemImages[i];
                ItemData itemData = itemDataList[i];
                imageToItemMap.Add(image, itemData);

                Debug.Log("image " + image);
                Debug.Log("itemData " + itemData);

                SetItemData(image, itemData); // �������� Set���ִ� ����
            }
        }
        
    }
    public void SetItemData(Image itemImage, ItemData newItemData)
    {
        
        // Prefab ���� �� ��ġ ����
        if (newItemData != null)
        {
            Debug.Log("set?");
            Debug.Log("prefab: " + newItemData.prefab);
            Debug.Log("Name" + newItemData.itemName);
            Instantiate(newItemData.prefab, itemImage.transform);
        }
    }

}
