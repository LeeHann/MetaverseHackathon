using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public string Name;
    public string Price;

    public void OnClickItem()
    {
        UIManager.instance.ItemDetail.SetActive(true);
        UIManager.instance.ItemDetailTexts[0].text = Name;
        UIManager.instance.ItemDetailTexts[1].text = Price;
    }
}
