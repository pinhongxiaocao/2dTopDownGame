using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;

    #region 生命周期函数
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        EventCenter.GetInstance().AddEventListener(Consts.EventName.PlayerMove,Move);
        EventCenter.GetInstance().AddEventListener(Consts.EventName.PlayerIdle,Idle);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener(Consts.EventName.PlayerMove, Move);
        EventCenter.GetInstance().RemoveEventListener(Consts.EventName.PlayerIdle, Idle);
    }
    #endregion

    #region 事件监听方法
    private void Move() 
    {
        anim.SetBool(Consts.AnimParams.isMoving,true);
    }

    private void Idle()
    {
        anim.SetBool(Consts.AnimParams.isMoving, false);
    }
    #endregion
}
