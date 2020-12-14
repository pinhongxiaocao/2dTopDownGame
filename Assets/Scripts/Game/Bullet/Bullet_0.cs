using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_0 : BaseBullet
{
    /// <summary>
    /// 子弹拥有的特效
    /// </summary>
    private const string effect = "Effect/Bullet_Impact_Effect";

    private float speed = 7.5f;
    private Rigidbody2D theRB;

    #region Unity生命周期函数 
    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        theRB.velocity = transform.right*speed;
    }
    #endregion

    #region Unity触发事件
    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolMgr.GetInstance().PushObj("Bullets/Bullet_0", this.gameObject);
    }
    #endregion

    #region 实现接口(对象池)
    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnspawn()
    {
        base.OnUnspawn();
        //在进去的时候 放一个特效
        PoolMgr.GetInstance().GetObj("Effect/Bullet_Impact_Effect", (effect) =>
         {
             effect.transform.position = this.transform.position;
         });
    }
    #endregion
}
