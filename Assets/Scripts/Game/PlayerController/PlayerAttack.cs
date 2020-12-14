using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /// <summary>
    /// 需要发射的预制体名字
    /// </summary>
    private const string bulletName="Bullets/Bullet_0";

    private float timeBetweenShots=3f;//射击间隔时间
    private float shotCounter;//射击倒计时



    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            PoolMgr.GetInstance().GetObj(bulletName,(bullet)=> 
            {
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
            });
            shotCounter = timeBetweenShots;
        }

        if (Input.GetMouseButton(0)) 
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0f) 
            {
                PoolMgr.GetInstance().GetObj(bulletName, (bullet) =>
                {
                    bullet.transform.position = this.transform.position;
                    bullet.transform.rotation = this.transform.rotation;
                });

                shotCounter = timeBetweenShots;
            }
        }
    }
}
