using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketItem : MonoBehaviour
{
    public Item info = new Item();

    public Text Name;
    public Text Price;

    public void OnToggleCheck()
    {
        info.isCheck = this.GetComponentInChildren<Toggle>().isOn;
        // Debug.Log("isCheck " + info.isCheck);
        // UIManager.ItemsInBasket
    }
}
