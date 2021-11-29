using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseEvent : MonoBehaviour
{
    bool isCursorOn = false;
    public GameObject Guide;
    bool guideOpen = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) | Input.GetKeyDown(KeyCode.RightAlt) |
        Input.GetKeyDown(KeyCode.LeftCommand) | Input.GetKeyDown(KeyCode.RightCommand))
        {
            isCursorOn = !isCursorOn;
            Cursor.visible = isCursorOn;
            if (isCursorOn == false) Cursor.lockState = CursorLockMode.Locked;
            else 
            {
                Debug.Log(isCursorOn);
                Cursor.lockState = CursorLockMode.None;          
            }  
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "mainMap")
            {
                OnClickQuit();
            }
            else
                Loading.LoadSceneHandle("mainMap");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            guideOpen = !Guide.activeSelf;
            Guide.SetActive(guideOpen);
        }
    }

    public void OnClickQuit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    
    #else
        Application.Quit(); // 어플리케이션 종료    
    #endif
    }
}
