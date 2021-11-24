using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 사과/배, 포도/복숭아 등 테이블 안의 세부 유닛을 자식으로 가지는 화면 좌측 패널
    // 테이블 별로 unit이 다르게 편성됨
    public GameObject UnitGroups;                                              
    [HideInInspector] public static UIManager instance;
    [HideInInspector] public UnitButton[] UnitObjects;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        UnitObjects = UnitGroups.GetComponentsInChildren<UnitButton>();
    }

    public void InitButton()
    {
        for (int i = 0; i < UnitObjects.Length; i++)
        {
            UnitObjects[i].gameObject.SetActive(false);
        }
    }

    public void SetFunctionButton(int num, string buttonName, List<string> parameterList, System.Action callback)
    {
        UnitObjects[num].gameObject.SetActive(true);
        UnitObjects[num].GetComponent<UnitButton>().SetButton(buttonName, parameterList, callback);
    }
}
