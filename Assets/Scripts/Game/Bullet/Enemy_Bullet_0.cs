using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_0 : BaseBullet
{
    private float speed = 7.5f;
    private int force  = 75;
    private Rigidbody2D theRB;

    #region Unity生命周期
    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        theRB.velocity = transform.right * speed;
    }
    #endregion

    #region Unity触发事件
    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolMgr.GetInstance().PushObj(Consts.BulletGame.Enemy_Bullet_0, this.gameObject);

        if (other.CompareTag(Consts.Tags.Player))
        {
            other.GetComponentInParent<IDamage>().GetHurtrd(force);
        }
    }
    #endregion
}
