using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPiece : MonoBehaviour, IReusable
{
    [SerializeField] private int index;

    private float moveRange = 3f;
    private Vector3 moveDir;
    //减速的速度
    private float deceleration = 5f;

    private float lifeTime = 3f;
    private SpriteRenderer theSR;
    private float fadeSpeed = 2.5f;

    #region Unity生命周期

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //让碎片朝着不同方向飞起来
        this.transform.position += moveDir * Time.deltaTime;
        //不断的降低碎片飞的方向 让他停下来
        moveDir = Vector3.Lerp(moveDir, Vector3.zero, deceleration * Time.deltaTime);

        //不断计时检测是否销毁
        lifeTime -= Time.deltaTime;
        if (lifeTime<=0) 
        {
            theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,
                               Mathf.MoveTowards(theSR.color.a,0f,fadeSpeed*Time.deltaTime));

            if (theSR.color.a<0) 
            {
                //放入对象池
                PoolMgr.GetInstance().PushObj(Consts.BreakableName.BrokenPiece + index, this.gameObject);
            }
        }
    }
    #endregion

    #region 接口实现
    public void OnSpawn()
    {
        moveDir.x = Random.Range(-moveRange, moveRange);
        moveDir.y = Random.Range(-moveRange, moveRange);

        lifeTime = 3f;
    }

    public void OnUnspawn()
    {

    }
    #endregion
    void Destory()
    {
        
    }
}
