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
    Vector3 moveVec;

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
        if (!isBad && cDown)
        {
            anim.SetTrigger("doBad");
            isBad = true;

            Invoke("BadOut", 0.1f);
        }
    }
    void BadOut()
    {
        isBad = false;
    }
}
