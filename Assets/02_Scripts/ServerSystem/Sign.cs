using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Sign : MonoBehaviour
{
    public string ID;
    public string PW;
    public InputField InputID;
    public InputField InputPW;

    void Start()
    {
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())
        {
            // 초기화 성공 시 로직
            Debug.Log("초기화 성공!");
            // CustomSignUp();
        }
        else
        {
            // 초기화 실패 시 로직
            Debug.LogError("초기화 실패!");
        }
    }

    public void OnClickSignIn()
    {
        ID = InputID.text;
        PW = InputPW.text;
        Debug.Log("ID : " + ID + " PW : " + PW);

        if (ID.Length <= 0 || PW.Length <= 0) return;

        BackendReturnObject bro = Backend.BMember.CustomLogin( ID, PW );
        if(bro.IsSuccess())
        {
            Debug.Log("로그인에 성공했습니다");
        }
    }

    public void OnClickSignUp()
    {
        ID = InputID.text;
        PW = InputPW.text;
        Debug.Log("ID : " + ID + " PW : " + PW);
        
        if (ID.Length <= 0 || PW.Length <= 0) return;

        BackendReturnObject bro = Backend.BMember.CustomSignUp ( ID, PW );
        if(bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다");
        }
    }
}