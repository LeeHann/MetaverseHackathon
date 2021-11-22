using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

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
        Where where = new Where();
        where.Equal("category", category);

        var BRO = Backend.GameData.Get(tableName, where, 20);   // 인스턴스 모음
        
    }
}
