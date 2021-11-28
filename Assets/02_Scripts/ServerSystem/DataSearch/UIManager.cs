using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;
using UnityEngine.UI;

public partial class UIManager : MonoBehaviour
{
    // 사과/배, 포도/복숭아 등 테이블 안의 세부 유닛을 자식으로 가지는 화면 좌측 패널
    // 테이블 별로 unit이 다르게 편성됨
    [HideInInspector] public static UIManager instance;
    public GameObject UnitGroups;                                              
    [HideInInspector] public UnitButton[] UnitObjects;
    public GameObject ItemGroups;
    public int limitOfItem = 70;
    public GameObject item;
    [HideInInspector] public ItemButton[] ItemObjects;
    static public string tableName;
    public GameObject UIPanel;
    public ProductViewSlide ProductView;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 테이블 중 하나 raycast 해서 오픈하기
            Debug.Log("fruit table section Open");
            UIPanel.SetActive(true);
            tableName = "fruit";    // tableName = gameObject.tag
            SelectSection();
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        ProductView.ViewClose();
    }

    void Start()
    {
        UnitObjects = UnitGroups.GetComponentsInChildren<UnitButton>();
        ItemObjects = new ItemButton[limitOfItem];
        for (int i=0; i<limitOfItem; i++)
        {
            ItemObjects[i] = Instantiate(item, ItemGroups.transform).GetComponent<ItemButton>();
        }
        InitButton();
    }

    public void InitButton()
    {
        for (int i = 0; i < UnitObjects.Length; i++)
        {
            UnitObjects[i].gameObject.SetActive(false);
        }
        ResetItemButton();
    }

    public void ResetItemButton()
    {
        for (int i = 0; i < ItemObjects.Length; i++)
        {
            ItemObjects[i].gameObject.SetActive(false);
        }
    }

    public void SetFunctionButton(int num, System.Action<string> callback, string category)
    {
        Debug.Log("num : " + num);
        UnitObjects[num].gameObject.SetActive(true);
        UnitObjects[num].GetComponent<UnitButton>().SetButton(callback, category);
    }


    public void MatchUnitData(string category)
    {
        if (!ProductView.gameObject.activeSelf) ProductView.ViewOpen();
        ResetItemButton();
        // unit 버튼 중 하나 클릭 - ex) 사과/배
        Where where = new Where();
        where.Equal("category", category);
        
        var bro = Backend.GameData.Get(tableName, where, 100);
        if (bro.IsSuccess())
        {
            JsonData jsonData = bro.GetReturnValuetoJSON()["rows"];
            // Debug.Log(jsonData.ToJson());
            for (int i = jsonData.Count-1; i>=0; i--)
            {
                var id = jsonData[i]["id"][0];
                string cate = jsonData[i]["category"][0].ToString();
                string name = jsonData[i]["name"][0].ToString();
                var price = jsonData[i]["price"][0];

                Debug.Log("id : " + id + " category : " + cate + " name : " + name + " price : " + price); 
                // 값 매치
                // 카테고리에 따라 사진 매치
                Text[] childTexts = ItemObjects[jsonData.Count - 1 - i].GetComponentsInChildren<Text>();
                childTexts[0].text = name;
                childTexts[1].text = ChangeMoneyText(int.Parse(price.ToString())) + "원";
                ItemObjects[jsonData.Count - 1 - i].gameObject.SetActive(true);
            }
            
            // 아이템 베이스 패널 오른쪽으로 이동

        }
        else
        {
            // 에러메시지 화면에 UI로 띄우기  
            Debug.LogError(bro.GetErrorCode() + " " + bro.GetMessage());
        } 
    }

    //Text 변경 메서드
    static public string ChangeMoneyText(int money)
    {
        return (string.Format("{0:#,###}", money));
    }
}
