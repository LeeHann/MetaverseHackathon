using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public string Name;
    public string Price;

    public void OnClickItem()
    {
        UIManager.instance.selectedItem = new Item(Name, Price);
        UIManager.instance.ItemDetail.SetActive(true);
        UIManager.instance.ItemDetailTexts[0].text = Name;
        UIManager.instance.ItemDetailTexts[1].text = Price;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public string Price;
    public bool isCheck;

    public Item(string Name="", string Price="", bool isCheck=true)
    {
        this.Name = Name;
        this.Price = Price;
        this.isCheck = isCheck;
    }
}
