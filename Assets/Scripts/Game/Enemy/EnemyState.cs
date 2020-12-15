using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : RoleState,IDamage
{
    protected new int health = 150;
    protected new int attachForce;

    public void GetHurtrd(int force)
    {
        health -= force;
        //释放受伤特效 由于下一帧可能销毁 所以还是要同步
        GameObject effect = PoolMgr.GetInstance().GetObj(Consts.ParticleName.Enemy_Hurted_Effect);
        effect.transform.position = this.transform.position;
        if (health <= 0) 
        {
            //生成死亡状态物 这里由于下一帧就要销毁只能同步
            GameObject splatter = PoolMgr.GetInstance().GetObj("Splatter/Splatter01");
            splatter.transform.position = this.transform.position;
            //TODO以后设置关卡再用对象池
            Destroy(this.gameObject);
        }
    }
}
