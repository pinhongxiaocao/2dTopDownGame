using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed=5f;
    private Vector2 moveDir;

    private Rigidbody2D theRB;
    #region Unity生命周期函数
    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        theRB.velocity = moveDir * moveSpeed;

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

        
    }
    #endregion

}
