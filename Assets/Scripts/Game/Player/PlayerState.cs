using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerState : RoleState,IDamage
{
    [SerializeField]protected new int health=300;
    [SerializeField]protected new int maxHealth=300;

    private float damageInvincLength = 1f;//无敌时间
    private float invincCount = 1f;//无敌计时器
    private void Update()
    {
        if (invincCount > 0) 
        {
            invincCount -= Time.deltaTime;
            if (invincCount <= 0) 
            {
                //回复受伤效果
                transform.Find("PlayerBody").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            }
        }
        //不断的向各处更新玩家的生命
        EventCenter.GetInstance().EventTrigger<int>(Consts.EventName.PlayerHealth,health);
    }

    #region 接口实现
    public void GetHurtrd(int force)
    {
        if (invincCount <= 0f) 
        {
            health -= force;
            //重置无敌时间
            invincCount = damageInvincLength;

            //设置受伤效果
            transform.Find("PlayerBody").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

            //判断死亡
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
    #endregion

}
