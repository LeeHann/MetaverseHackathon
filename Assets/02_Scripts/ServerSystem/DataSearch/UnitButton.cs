using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public Button button;

    public void SetButton(string buttonName, List<string> parameters, System.Action callback)
    {
        button.GetComponentInChildren<Text>().text = buttonName;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => callback());

    }
}
