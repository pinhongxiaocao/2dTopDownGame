using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家的角色面板 用于展示玩家的血量等
/// </summary>
public class PlayerPanel : BasePanel
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<int>(Consts.EventName.PlayerHealth, UpdateHealth);
    }
    #region 显隐
    public override void HideMe()
    {
        base.HideMe();
        EventCenter.GetInstance().RemoveEventListener<int>(Consts.EventName.PlayerHealth, UpdateHealth);
    }
    #endregion

    #region 事件监听方法
    private void UpdateHealth(int health) 
    {
        GetControl<Text>("txtHealth").text = health.ToString()+"/"+"600";
    }
    #endregion
}
