using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D theRB;
    private float moveSpeed=3f;


    private Transform target;

    private float rangeToChasePlayer=7f;
    private Vector3 moveDirection;

    #region Unity事件监听
    private void Awake()
    {

        //找到目标玩家
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //挂组件
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, target.position) < rangeToChasePlayer) 
        {
            moveDirection = target.position - transform.position;
        }
        else
        {
            moveDirection = Vector2.zero;
        }
        moveDirection.Normalize();
        theRB.velocity = moveDirection * moveSpeed;

        //判断移动方向
        if (moveDirection != Vector3.zero) 
        {
            EventCenter.GetInstance().EventTrigger(Consts.EventName.EnemyMove);
        }
        else 
        {
            EventCenter.GetInstance().EventTrigger(Consts.EventName.EnemyIdle);
        }
    }
    #endregion
}
