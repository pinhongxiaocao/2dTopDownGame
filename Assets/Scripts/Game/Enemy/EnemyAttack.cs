using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// 需要发射的预制体名字
    /// </summary>
    private string bulletName = Consts.BulletGame.Enemy_Bullet_0;

    private bool shouldShot;
    private float timeBetweenShots = 3f;//射击间隔时间
    private float shotCounter;//射击倒计时

    #region Unity生命周期函数
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<Vector3>(Consts.EventName.EnemyAttack, Shot);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<Vector3>(Consts.EventName.EnemyAttack, Shot);
    }
    #endregion

    void Shot(Vector3 dir)
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            shotCounter =timeBetweenShots;
            //生成一个子弹
            PoolMgr.GetInstance().GetObj(Consts.BulletGame.Enemy_Bullet_0, (bullet) =>
            {
                //设置他的位置
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                //设计他的方向
                bullet.transform.right = dir;
            });
        }
    }
}
