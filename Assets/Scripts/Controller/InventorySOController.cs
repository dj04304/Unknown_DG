using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySOController : MonoBehaviour
{
    public EquipPopupBtn equipPopupBtn;

    public GameObject equipPopup;
    // �˾��� ����� �ؽ�Ʈ��
    public TextMeshProUGUI popupItemName;
    public TextMeshProUGUI popupItemDescription;
    public TextMeshProUGUI popupItemStatus;

    [SerializeField] private List<ItemData> itemDataList;
    public List<Image> itemImages;

    private Dictionary<Image, ItemData> imageToItemMap = new Dictionary<Image, ItemData>(); // Dictionary�� �̿��ؼ� Image�� Key������ ItemData�� �����´�.
 


    private void Start()
    {
        if (itemImages.Count > 0 && itemDataList != null)
        {
            int minCount = Mathf.Min(itemImages.Count, itemDataList.Count); // List index Exception�� ���� ������ �ּڰ��� ItemDataSo�� �����ش�.

            Debug.Log("minCount " + minCount);

            for (int i = 0; i < minCount; i++)
            {
                Image image = itemImages[i];
                Button imageBtn = image.GetComponent<Button>();
                ItemData itemData = itemDataList[i];
                imageToItemMap.Add(image, itemData);

                //Debug.Log("image " + image);
                //Debug.Log("itemData " + itemData);

                SetItemData(image, itemData); // �������� Set���ִ� ����
                imageBtn.onClick.AddListener(() => OnImageClick(image));
               
            }
        }
        
    }

    private void OnImageClick(Image itemImage)
    {
        if(itemImage != null)
        {
            ItemData selectedItem = imageToItemMap[itemImage];

            Debug.Log("item : " + selectedItem);
            //InventoryItem invenItem = GetComponentInChildren<InventoryItem>();
            //InventoryItem invenItem = selectedItem.prefab.GetComponentInChildren<InventoryItem>();

            InventoryItem invenItem = GetComponentInChildren<InventoryItem>();

            Debug.Log("invenItem: " + invenItem);

            equipPopupBtn.SendItemData(selectedItem, invenItem); // ������Ʈ �Ѱ��ִ°��� �׷��� ������ �ʴ�.

            equipPopup.SetActive(true);
            popupItemName.text = selectedItem.itemName;
            popupItemDescription.text = selectedItem.description;
            popupItemStatus.text = selectedItem.status.ToString();


        }
    }

    private void SetItemData(Image itemImage, ItemData newItemData)
    {
        
        // Prefab ���� �� ��ġ ����
        if (newItemData != null)
        {
            Debug.Log("set?");
            Debug.Log("prefab: " + newItemData.prefab);

            Instantiate(newItemData.prefab, itemImage.transform);
        }
    }



}
