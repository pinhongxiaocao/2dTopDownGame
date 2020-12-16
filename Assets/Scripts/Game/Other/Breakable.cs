using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.Tags.Player)) 
        {
            //随机生成碎片个数
            int piecesToDrop = Random.Range(1, 6);


            //循环生成碎片
            for (int i = 0; i < piecesToDrop; ++i)
            {
                //随机生成碎片种类
                int randomPiece = Random.Range(1, 7);
                //先生成碎片 由于要销毁 所以同步加载
                GameObject obj = PoolMgr.GetInstance().GetObj(Consts.BreakableName.BrokenPiece + randomPiece);
                obj.transform.position = this.transform.position;
            }
            //TODO以后缓存池
            Destroy(this.gameObject);
        }
    }
}
