using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_0 : BaseBullet
{
    private float speed = 7.5f;
    private int force = 75;

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
        PoolMgr.GetInstance().PushObj(Consts.BulletGame.Bullet_0, this.gameObject);

        if (other.CompareTag(Consts.Tags.Enemy)) 
        {
            other.GetComponent<IDamage>().GetHurtrd(force);
        }
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
        //在进去的时候 拿一个特效
        PoolMgr.GetInstance().GetObj(Consts.ParticleName.Bullet_Impact_Effect, (effect) =>
         {
             effect.transform.position = this.transform.position;
         });
    }
    #endregion
}
