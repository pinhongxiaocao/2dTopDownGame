using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        EventCenter.GetInstance().AddEventListener(Consts.EventName.EnemyIdle,Idle);
        EventCenter.GetInstance().AddEventListener(Consts.EventName.EnemyMove,Move);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener(Consts.EventName.EnemyIdle, Idle);
        EventCenter.GetInstance().RemoveEventListener(Consts.EventName.EnemyMove, Move);
    }

    private void Idle() 
    {
        anim.SetBool(Consts.AnimParams.isMoving, false);
    }

    private void Move()
    {
        anim.SetBool(Consts.AnimParams.isMoving, true);
    }
}
