using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Sign : MonoBehaviour
{
    string ID;
    string PW;
    public InputField InputID;
    public InputField InputPW;
    public GameObject PanelWarning;
    public Text TextWarning;
    Coroutine m_coroutine;
    

    public bool SceneMode;
    public string SceneName;

    public bool TestMode;

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
        
        if (TestMode == true)
        {
            bro = Backend.BMember.CustomLogin( "hhhh", "0000" );
            if(bro.IsSuccess())
            {
                Debug.Log("로그인에 성공했습니다");
            } 
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
            if (SceneMode == true) Loading.LoadSceneHandle(SceneName);
        } else Error(bro.GetErrorCode());
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
            if (SceneMode == true) Loading.LoadSceneHandle(SceneName);
        } else Error(bro.GetErrorCode());
    }

    void Error(string errorCode)
    {
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine); 
        }
        switch (errorCode)
        {
            case "DuplicatedParameterException":
                m_coroutine = StartCoroutine(PrintWarning("중복된 사용자 아이디입니다."));
                break;
            case "BadUnauthorizedException" :
                m_coroutine = StartCoroutine(PrintWarning("잘못된 사용자 아이디 혹은 비밀번호입니다."));
                break;
            default:
                m_coroutine = StartCoroutine(PrintWarning("로그인에 실패했습니다."));
                break;
        }
    }

    IEnumerator PrintWarning(string errorMessage)
    {
        TextWarning.text = errorMessage;
        float time = 0f;
        Color color = new Color(1,1,1,0.8f);
        Color color2 = new Color();
        PanelWarning.SetActive(true);
        while (time < 1.5f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        while (time < 1f)
        {
            color.a = Mathf.MoveTowards(color.a, color.a / 1.5f, Time.deltaTime);
            color2.a = color.a;
            PanelWarning.GetComponent<Image>().color = color;
            TextWarning.color = color2;
            time += Time.deltaTime;
            yield return null;
        }
        PanelWarning.SetActive(false);
        color.a = 1f;
        PanelWarning.GetComponent<Image>().color = color;
        color2.a = 1f;
        TextWarning.color = color2;

        m_coroutine = null;
    }
}
