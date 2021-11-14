using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Vector3 dir;
    float speed = 3f;
    
    private void Update() 
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");    
    }

    private void FixedUpdate() 
    {
        transform.Translate(dir * Time.deltaTime * speed);    
    }
}
