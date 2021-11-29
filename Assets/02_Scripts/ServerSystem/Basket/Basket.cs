using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public GameObject basketItemPrefab;
    public Transform basketContent;
    public Text TotalPrice;

    private void OnEnable() {
        while (slots.Count < UIManager.ItemsInBasket.Count)    // 현재 장바구니에 들어있는 만큼 슬롯 생성
            SlotMaker();
        while (slots.Count > UIManager.ItemsInBasket.Count)
        {
            var tmp = slots[slots.Count-1];
            PopSlot();
            Destroy(tmp);
        }

        MatchValue();
        CalculateTotalPrice();
    }

    public void SlotMaker()
    {
        var newObj = Instantiate(basketItemPrefab);
        newObj.GetComponentInChildren<Toggle>().onValueChanged.AddListener((bool isOn) => CalculateTotalPrice());
        newObj.transform.SetParent(basketContent.transform);
        slots.Add(newObj);
    }

    public void PopSlot()
    {
        slots.RemoveAt(index: slots.Count-1);
    }

    public void PopSlot(GameObject tmp)
    {
        slots.Remove(tmp);
    }

    public void MatchValue()
    {
        int index;
        for (index=0; index<UIManager.ItemsInBasket.Count; index++)
        {
            var newObj = slots[index].GetComponentInChildren<BasketItem>();
            var info = UIManager.ItemsInBasket[index];

            newObj.Name.text = info.Name;
            newObj.Price.text = info.Price;
            newObj.info = info;
        }
    }

    public void OnClickBuy()
    {
        // 선택된 객체만 구매
        foreach (var item in slots)
        {
            if (item.GetComponent<BasketItem>().info.isCheck == true)
            {
                // 구매하기
            }
        }
    }

    public void OnClickTrash()
    {
        // 선택된 객체만 버리기
        int cnt = UIManager.ItemsInBasket.Count;
        int cntS = slots.Count;
        for (int i=cnt-1; i>=0; i--)
        {   if (UIManager.ItemsInBasket.Count < i + 1) continue;
            if (UIManager.ItemsInBasket[i].isCheck == true)
            {
                // slot과 ItemsInBasket의 atomicity
                for (int j=cntS-1; j>=0; j--)
                {   if (slots.Count < j + 1) continue;
                    if (UIManager.ItemsInBasket[i].Name == slots[j].GetComponentInChildren<BasketItem>().info.Name)
                    {
                        var tmp = slots[j].gameObject;
                        PopSlot(slots[j].gameObject);
                        Destroy(tmp);
                        UIManager.instance.RemoveItem(UIManager.ItemsInBasket[i]);
                    }
                }
                
            }
        }
        CalculateTotalPrice();
    }

    public void OnClickClear()
    {
        int cnt = UIManager.ItemsInBasket.Count;
        for (int i=cnt-1; i>=0; i--)
        // foreach (var i in UIManager.ItemsInBasket)
        {
            var tmp = slots[i].gameObject;
            PopSlot(slots[i].gameObject);
            Destroy(tmp);
            UIManager.ItemsInBasket.Remove(UIManager.ItemsInBasket[i]);
        }
        CalculateTotalPrice();
    }

    public void CalculateTotalPrice()
    {
        // Debug.Log("Calculate");
        int totalPrice = 0;
        foreach (var num in UIManager.ItemsInBasket)
        {   
            if (num.isCheck == true)
                totalPrice += int.Parse((num.Price.Replace("원", "")).Replace(",", ""));
            // Debug.Log("num.isCheck : " + num.isCheck);
        }
        TotalPrice.text = UIManager.ChangeMoneyText(totalPrice) + "원";
    }
}
