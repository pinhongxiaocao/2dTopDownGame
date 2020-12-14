using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour, IReusable
{

    #region 接口实现
    public virtual void OnSpawn()
    {
        //打开时重新播放一次
        GetComponent<ParticleSystem>().Play();
    }

    public virtual void OnUnspawn()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    #endregion
}
