using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour, IReusable
{
    protected  string effectName="123";
    protected  float delayTime=0.25f;
    #region 接口实现
    public virtual void OnSpawn()
    {
        //打开时重新播放一次
        GetComponent<ParticleSystem>().Play();
        //触发回收回调
        Invoke("Destroy", delayTime);
    }

    public virtual void OnUnspawn()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    #endregion

    void Destroy()
    {
        PoolMgr.GetInstance().PushObj(effectName, this.gameObject);
    }
}
