using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class XMLParser: MonoBehaviour
{
    // xml 파싱 -> 딕셔너리로 정리 -> 딕셔너리 foreach로 돌면서 디비 쿼리 insert
    Infos IM;
    public string m_File = "";       // 파싱 할 xml 파일명
    
    void Start()
    {
        IM = Infos.Instance;
        // 파싱 시작
        StartCoroutine(Process(m_File));
    }

    IEnumerator Process(string fileName)
    {
        string strPath = string.Empty;

        // 플랫폼 별로 다르게!!
#if ( UNITY_EDITOR || UNITY_STANDALONE_WIN )
        strPath += ("file:///");
        strPath += (Application.streamingAssetsPath + "/" + fileName);

#elif UNITY_ANDROID
        strPath =  "jar:file://" + Application.dataPath + "!/assets/" + fileName;

#endif

        WWW www = new WWW(strPath);
        yield return www;

        Debug.Log("Read Content : " + www.text);
        Interpret(www.text, fileName);
    }

    private void Interpret(string _strSource, string fileName)
    {
        // 인코딩 문제 예외처리.
        // 읽은 데이터의 앞 2바이트 제거(BOM제거)

        StringReader stringReader = new StringReader(_strSource);
        stringReader.Read();    // BOM 제거 한 데이터로 파싱해요.

        XmlNodeList xmlNodeList = null;
        XmlDocument xmlDoc = new XmlDocument();

        try
        {
            // XML 로드하고.
            xmlDoc.LoadXml(stringReader.ReadToEnd());
        }        
        catch(Exception e)
        {
            xmlDoc.LoadXml(_strSource);
        }

        // 최 상위 노드 선택.
        xmlNodeList = xmlDoc.SelectNodes("Items");

        // 만들어 놓은 아이템 매니저에 넣기        
        foreach (XmlNode node in xmlNodeList)
        {   
            if (node.Name.Equals("Items") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (fileName == m_File)
                    {
                        int id = int.Parse(child.Attributes.GetNamedItem("id").Value);
                        string name = child.Attributes.GetNamedItem("name").Value;
                        int price = int.Parse(child.Attributes.GetNamedItem("id").Value);
                        string imgPath = child.Attributes.GetNamedItem("imgPath").Value;
                        
                        ItemInfo item = new ItemInfo(id, name, price, imgPath);
                        // 다 만들어졌다면 이제 매니저에 넣어줍시다.
                        IM.AddItem(item);
                    }
                }
            }            
        }
    }
}