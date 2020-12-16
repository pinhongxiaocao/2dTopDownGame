using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed=5f;
    [SerializeField] private float dashSpeed=8f;
    private float activeMoveSpeed;
    private Vector2 moveDir;
    private Rigidbody2D theRB;

    private float dashLength = 0.5f;
    private float dashCoolDown = 1f;
    private float dashInvinvibility = 0.5f;
    private float dashCounter ;
    private float dashCoolCounter;

    #region Unity生命周期函数
    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        theRB.velocity = moveDir * activeMoveSpeed;

        //检查状态 如果方向不为0 证明正在跑
        if (moveDir != Vector2.zero) 
        {
            //触发移动事件
            EventCenter.GetInstance().EventTrigger(Consts.EventName.PlayerMove);
        }
        else 
        {
            //触发站立事件
            EventCenter.GetInstance().EventTrigger(Consts.EventName.PlayerIdle);
        }

        Update_Dash();
    }
    #endregion

    void Update_Dash() 
    {
        //按下空格开始dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //判断冷却是否过去了,是否停止了dash
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                //给动画层发送消息要Trgger
                EventCenter.GetInstance().EventTrigger(Consts.EventName.PlayerDash);
            }

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
