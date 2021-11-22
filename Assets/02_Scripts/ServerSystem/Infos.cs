using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : SingletonBase<Infos>
{
    public Dictionary<int, ItemInfo> dicData = new Dictionary<int, ItemInfo>();
    public void AddItem(ItemInfo info)
    {
        if (dicData.ContainsKey(info.id)) return;
        dicData.Add(info.id, info);
    }

    public ItemInfo GetItem(int id)
    {
        if (dicData.ContainsKey(id))
            return dicData[id];
        return null;
    }

    public Dictionary<int, ItemInfo> GetAllItems()
    {
        return dicData;
    }

    public int GetItemsCount()
    {
        return dicData.Count;
    }
}

public class ItemInfo
{
   public int id;  
   public string name;  // 상품 이름
   public int price;    // 상품 가격
   public string imgPath;
   
   public ItemInfo(int id, string name, int price, string imgPath)
   {
      this.id = id;
      this.name = name;
      this.price = price;
      this.imgPath = imgPath;
   }
}
