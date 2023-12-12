using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject target;
    public GameObject buttons;

    public void OnTarget()
    {
        target.SetActive(true);
        buttons.SetActive(false);
    }

    public void CloseTarget()
    {
        target.SetActive(false);
        buttons.SetActive(true);
    }

}
