using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Impact_Effect : BaseEffect
{

    void Destroy()
    {
        PoolMgr.GetInstance().PushObj("Effect/Bullet_Impact_Effect", this.gameObject);
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        Invoke("Destroy", 0.25f);
    }

    public override void OnUnspawn()
    {
        base.OnUnspawn();
    }
}
