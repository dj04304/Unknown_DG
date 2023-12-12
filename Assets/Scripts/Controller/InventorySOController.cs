using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySOController : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemDataList;
    public List<Image> itemImages;

    private Dictionary<Image, ItemData> imageToItemMap = new Dictionary<Image, ItemData>(); // Dictionary를 이용해서 Image를 Key값으로 ItemData를 가져온다.

    private void Start()
    {
        if(itemImages.Count > 0 && itemDataList != null)
        {
            int minCount = Mathf.Min(itemImages.Count, itemDataList.Count); // List index Exception이 나기 때문에 최솟값인 ItemDataSo에 맞춰준다.

            Debug.Log("minCount " + minCount);

            for (int i = 0; i < minCount; i++)
            {
                Image image = itemImages[i];
                ItemData itemData = itemDataList[i];
                imageToItemMap.Add(image, itemData);

                Debug.Log("image " + image);
                Debug.Log("itemData " + itemData);

                SetItemData(image, itemData); // 아이템을 Set해주는 동작
            }
        }
        
    }
    public void SetItemData(Image itemImage, ItemData newItemData)
    {
        
        // Prefab 생성 및 위치 지정
        if (newItemData != null)
        {
            Debug.Log("set?");
            Debug.Log("prefab: " + newItemData.prefab);
            Debug.Log("Name" + newItemData.itemName);
            Instantiate(newItemData.prefab, itemImage.transform);
        }
    }

}
