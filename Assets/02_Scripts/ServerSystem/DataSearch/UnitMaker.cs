using System;
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
        // category = category.Replace("//", "/");

        Where where = new Where();
        where.Equal("category", category);
        Debug.Log("where : " + category);

        // var bro = Backend.GameData.Get( /*tableName*/"fruit", where, 100);
        // if (bro.IsSuccess())
        // {
        //     JsonData jsonData = bro.GetReturnValuetoJSON()["rows"];
        //     // Debug.Log(jsonData.ToJson());
        //     for (int i = 0; i<jsonData.Count; i++)
        //     {
        //         var id = jsonData[i]["id"][0];
        //         string cate = jsonData[i]["category"][0].ToString();
        //         string name = jsonData[i]["name"][0].ToString();
        //         var price = jsonData[i]["price"][0];

        //         Debug.Log("id : " + id + " category : " + cate + " name : " + name + " price : " + price); 
        //     }
        // }
        // else Debug.LogError(bro.GetErrorCode() + " " + bro.GetMessage());

        Backend.GameData.Get( /*tableName*/"fruit", where, 100, bro => 
        {
            Debug.Log("ASYNC");
            if (bro.IsSuccess())
            {
                JsonData jsonData = bro.GetReturnValuetoJSON()["rows"];
                // Debug.Log(jsonData.ToJson());
                for (int i = 0; i<jsonData.Count; i++)
                {
                    var id = jsonData[i]["id"][0];
                    string cate = jsonData[i]["category"][0].ToString();
                    string name = jsonData[i]["name"][0].ToString();
                    var price = jsonData[i]["price"][0];

                    Debug.Log("id : " + id + " category : " + cate + " name : " + name + " price : " + price); 
                }
            }
            else Debug.LogError(bro.GetErrorCode() + " " + bro.GetMessage());
        });

    }
}
