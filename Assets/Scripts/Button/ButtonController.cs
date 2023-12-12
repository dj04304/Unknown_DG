using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject status;
    public GameObject buttons;

    public void OnStatus()
    {
        status.SetActive(true);
        buttons.SetActive(false);
    }

    public void CloseStatus()
    {
        status.SetActive(false);
        buttons.SetActive(true);
    }

}
