using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hurted_Effect : BaseEffect
{
    public override void OnSpawn()
    {
        effectName = Consts.ParticleName.Enemy_Hurted_Effect;
        delayTime = 1.5f;
        base.OnSpawn();
    }
}
