using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public static List<Item> ItemsInBasket = new List<Item>();
    public Item selectedItem;

    public void AddItem(Item item)
    {
        ItemsInBasket.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (ItemsInBasket.Contains(item)) 
            ItemsInBasket.Remove(item);
    }

    public void OnClickBasket()
    {
        ItemsInBasket.Add(selectedItem); 
        Debug.Log("Basket : " + selectedItem.Name);
    }
}
