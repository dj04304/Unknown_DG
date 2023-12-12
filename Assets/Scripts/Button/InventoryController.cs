using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public GameObject equipPopup;
    public Image[] inventories;

    private void Awake()
    {
        inventories = GetComponentsInChildren<Image>();

        //Debug.Log(inventories.Length);
    }

    private void Start()
    {
        foreach(Image invenItem in inventories)
        {
            Button imgButton = invenItem.GetComponent<Button>();

            if(imgButton != null )
            {
                imgButton.onClick.AddListener(() => OnImageClick(invenItem));
                //imgButton.onClick.AddListener(() => OnImageClick(imgButton));
            }

        }
    }

    private void OnImageClick(Image clickedImg)
    {
        Image itemName = clickedImg.GetComponentsInChildren<Image>()[1]; // 본인 포함
        //Image itemName = clickedImg.GetComponentInChildren<Image>();


        if (itemName != null )
        {
            Debug.Log("아이템 이름: " + itemName.gameObject.name);

            equipPopup.SetActive(true);

        }

        
    }

}
