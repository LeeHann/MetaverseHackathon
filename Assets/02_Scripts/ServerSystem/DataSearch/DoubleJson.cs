using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DoubleJson : MonoBehaviour
{
    JsonData obj = new JsonData();

    Dictionary<string, Pair[]> dic = new Dictionary<string, Pair[]>();
    private void Start() {
        Pair[] equipment = new Pair[5]{new Pair("weapon", "123"), new Pair("weapon", "123"), new Pair("weapon", "123"), new Pair("weapon", "123"), new Pair("weapon", "123")};

        dic.Add("Header", equipment);
        obj.Add(dic);
        Dictionary<string, string> equip = new Dictionary<string, string>
        {
            { "111", "123" },
            { "222", "111" }
        };
        obj.Add(equip);
        Debug.Log(obj);
    }
}

public class Pair
{
    public string key;
    public string content;

    public Pair (string key, string content)
    {
        this.key = key;
        this.content = content;
    }
}
