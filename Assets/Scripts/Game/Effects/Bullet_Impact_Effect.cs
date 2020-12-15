using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Impact_Effect : BaseEffect
{

    /// <summary>
    /// 在对象池初始化的时候 修改一下名即可
    /// </summary>
    public override void OnSpawn()
    {
        effectName = Consts.ParticleName.Bullet_Impact_Effect;
        base.OnSpawn();
    }

}
