using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    Button button;

    public void SetButton(System.Action<string> callback, string category)
    {
        button = GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = category;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => callback(category));
    }
}
