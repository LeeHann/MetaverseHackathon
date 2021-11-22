using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class TableMaker : MonoBehaviour
{
    Infos IM;
    public string tableName;

    private void Awake() 
    {
        IM = Infos.Instance;    
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InsertData();
        }
    }
    // Insert 는 '생성' 작업에 주로 사용된다. 
    public void InsertData()
    {
        foreach (var i in IM.dicData.Keys)
        {
            var item = IM.dicData[i];
            Debug.Log("Dicdata : " + item.name);
            // Param은 뒤끝 서버와 통신을 할 때 넘겨주는 파라미터 클래스 입니다. 
            Param param = new Param();
            // 값을 Dictionary 로 사용하기
            param.Add("id", item.id);
            param.Add("category", item.category);
            param.Add("name", item.name);   // key, value
            param.Add("price", item.price);
            param.Add("imgPath", item.imgPath);
            // param.Add("dic", item);

            BackendReturnObject BRO = Backend.GameData.Insert(tableName, param);

            if(BRO.IsSuccess())
            {
                Debug.Log("indate : " + BRO.GetInDate());
            }
            else if (BRO == null)
            {
                Debug.Log("It is null");
            }
            else
            {
                switch (BRO.GetStatusCode())
                {
                    case "404":
                        Debug.Log("존재하지 않는 tableName인 경우");
                        break;

                    case "412":
                        Debug.Log("비활성화 된 tableName인 경우");
                        break;

                    case "413":
                        Debug.Log("하나의 row( column들의 집합 )이 400KB를 넘는 경우");
                        break;

                    default:
                        Debug.Log("서버 공통 에러 발생: " + BRO.GetMessage());
                        break;
                }
            }
        }
    }
}