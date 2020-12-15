using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour, IReusable
{
    public void OnSpawn()
    {
        Invoke("Destory", 2.5f);
    }

    public void OnUnspawn()
    {
        
    }

    void Destory() 
    {
        PoolMgr.GetInstance().PushObj("Splatter/Splatter01", this.gameObject);
    }
}
