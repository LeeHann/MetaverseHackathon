using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    bool isCursorOn = false;
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
