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

    #region Unity生命周期
    private void Awake()
    {
        //找到目标玩家
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //挂组件
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target == null)
        {
            theRB.velocity = Vector2.zero;
            return;
        }

        if (Vector3.Distance(this.transform.position, target.position) < rangeToChasePlayer) 
        {
            moveDirection = target.position - transform.position;
            //此时找到了玩家 触发攻击事件
            EventCenter.GetInstance().EventTrigger<Vector3>(Consts.EventName.EnemyAttack, moveDirection);
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
