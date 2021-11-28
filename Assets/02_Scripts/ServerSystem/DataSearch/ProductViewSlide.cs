using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductViewSlide : MonoBehaviour
{
    public Vector3 target;
    public Vector3 origin;
    public float speed = 3500;

    public void ViewOpen()
    {
        // Debug.Log("view open");
        // 활성화
        this.gameObject.SetActive(true);
        // 왼쪽에서 오른쪽으로 이동
        StartCoroutine(Move());
    } 

    IEnumerator Move()
    {
        while (Mathf.Abs(this.transform.localPosition.x - target.x) > 0f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void ViewClose()
    {
        transform.localPosition = origin;
        this.gameObject.SetActive(false);
    }
}
