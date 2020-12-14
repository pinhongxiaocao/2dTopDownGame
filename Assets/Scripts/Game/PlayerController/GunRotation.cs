using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Camera theCamera;

    private void Start()
    {
        theCamera = Camera.main;
    }

    private void Update()
    {
        //获得鼠标坐标
        Vector3 mousePos = Input.mousePosition;
        //获得枪所在的屏幕坐标
        Vector3 screenPoint = theCamera.WorldToScreenPoint(transform.localPosition);

        //玩家偏移
        if (mousePos.x < screenPoint.x) 
        {
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
            this.transform.localScale= new Vector3(-1f, -1f, 1f);
        }
        else 
        {
            transform.parent.transform.localScale = Vector3.one;
            this.transform.localScale = Vector3.one;
        }



        //获得鼠标和枪的偏移距离
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        //计算一个偏移角
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //旋转
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
