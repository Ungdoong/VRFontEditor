using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public BoxCollider text_box;
    public GameObject scale_box;
    public GameObject bavel_box;
    public GameObject hw_box;


    //private void Awake()
    //{
    //    scale_box.SetActive(false);
    //    bavel_box.SetActive(false);
    //    hw_box.SetActive(false);
    //}

    private void Update()
    {
#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.
        if (scale_box.active == true || bavel_box.active == true || hw_box.active == true)
#pragma warning restore CS0618 // 형식 또는 멤버는 사용되지 않습니다.
        {
            text_box.size = new Vector3(6.0f, 5.0f, 1);
        }
        else text_box.size = new Vector3(13.3f, 10.0f, 1);
    }
}
