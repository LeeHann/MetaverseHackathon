using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wUp;
    bool xDown;
    bool cDown;
    bool isBed;
    bool isBad;
    Vector3 moveVec, upVec = new Vector3(0, 0.5f, 0);

    
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Bed();
        Bad();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wUp = Input.GetButton("Run");
        xDown = Input.GetButtonDown("XXX");
        cDown = Input.GetButtonDown("CCC");
    }
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (wUp)
            transform.position += moveVec * speed * 1.5f * Time.deltaTime;
        else
            transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);
        anim.SetBool("isRun", wUp);
    }
    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
    void Bed()
    {
        if (!isBed && xDown)
        {
            anim.SetTrigger("doBed");
            isBed = true;

            Invoke("BedOut", 0.5f);
        }
    }
    void BedOut()
    {
        isBed = false;
    }
    void Bad()
    {
        RaycastHit[] hit;

        if (!isBad && cDown)
        {
            anim.SetTrigger("doBad");
            isBad = true;
            Invoke("BadOut", 0.1f);
        }
        else if (isBad)
        {
            hit = Physics.RaycastAll(transform.position + upVec, transform.forward, 3.0f);

            Debug.DrawRay(transform.position + upVec, transform.forward * 10, Color.red);
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log(hit[i].collider.name);
                if (hit[i].collider.gameObject.layer == 6)
                {
                    switch (hit[i].collider.gameObject.tag)
                    {
                        case "MilkProducts":
                            UIManager.tableName = "milkProduct";
                            Loading.LoadSceneHandle("Section1");
                            break;
                        case "Fruits": 
                            UIManager.tableName = "fruit";
                            Loading.LoadSceneHandle("Section2");
                            break;
                        case "Meat":
                            UIManager.tableName = "meat";
                            Loading.LoadSceneHandle("Section3");
                            break;
                        case "Fish":
                            UIManager.tableName = "seafood";
                            Loading.LoadSceneHandle("Section4");
                            break;
                        case "Rice":
                            UIManager.tableName = "rice";
                            Loading.LoadSceneHandle("Section5");
                            break;
                        case "Baby":
                            UIManager.tableName = "babyProduct";
                            Loading.LoadSceneHandle("Section6");
                            break;
                        case "Clean":
                            UIManager.tableName = "cleaningProduct";
                            Loading.LoadSceneHandle("Section7");
                            break;
                        case "Daily":
                            UIManager.tableName = "dailySupplies";
                            Loading.LoadSceneHandle("Section8");
                            break;
                    }              
                }
                if (hit[i].collider.gameObject.layer == 7)
                {
                    if (hit[i].collider.gameObject.tag=="Fruits")
                        UIManager.tableName = "fruit";
                    if (hit[i].collider.gameObject.tag == "Vegetable")
                        UIManager.tableName = "vegetable";
                    UIManager.instance.UIPanel.SetActive(true);
                    UIManager.instance.SelectSection();
                }
            }
                
           
        }
    }
    void BadOut()
    {
        isBad = false;
    }
}
