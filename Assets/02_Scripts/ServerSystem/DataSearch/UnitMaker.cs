using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class UnitMaker : MonoBehaviour
{
    static public string tableName;
    public GameObject UIPanel;
    public bool isOpen;

    public GameObject ItemPrefab;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 테이블 중 하나 raycast 해서 오픈하기
            Debug.Log("fruit table section Open");
            isOpen = !isOpen;
            UIPanel.SetActive(isOpen);
            tableName = "fruit";    // tableName = gameObject.tag
        }    
    }

    // 데이터베이스에서 데이터조회 및 출력
    // 사과/배 버튼 클릭 시 -> fruit 테이블의 category="사과/배" 인 row 출력
    public void OnClickCategory(string category)
    {
        // section 버튼 중 하나 클릭 - ex) 사과/배
        Debug.Log("Clicked");

        Where where = new Where();
        where.Equal("category", category);
        Debug.Log("where : " + category);

        var bro = Backend.GameData.Get( /*tableName*/"fruit", where, 100);
        if (bro.IsSuccess())
        {
            JsonData jsonData = bro.GetReturnValuetoJSON()["rows"];
            Debug.Log(jsonData);
            // int id = (int)jsonData["id"][0];
            // string cate = jsonData["category"][0].ToString();
            // string name = jsonData["name"][0].ToString();
            // int price = (int)jsonData["price"][0];

            // Debug.Log("id : " + id + " category : " + cate + " name : " + name + " price : " + price);
        }
        else Debug.LogError(bro.GetErrorCode() + " " + bro.GetMessage());
/*
        Backend.GameData.Get( tableName, where, 100, ( callback ) => 
        {
            if (callback.IsSuccess())
            {
                JsonData jsonData = callback.GetReturnValuetoJSON()["rows"][0];
                int id = (int)jsonData["id"][0];
                string category = jsonData["category"][0].ToString();
                string name = jsonData["name"][0].ToString();
                int price = (int)jsonData["price"][0];

                Debug.Log("id : " + id + " category : " + category + " name : " + name + " price : " + price);
            }
            else Debug.LogError(callback.GetErrorCode());
        });
*/
    }
}
