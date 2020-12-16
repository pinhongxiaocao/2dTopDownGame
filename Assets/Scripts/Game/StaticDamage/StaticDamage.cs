using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamage : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    #region Unity事件触发
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.Tags.Player)) 
        {
            other.GetComponent<IDamage>().GetHurtrd(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(Consts.Tags.Player))
        {
            other.GetComponent<IDamage>().GetHurtrd(damage);
        }
    }
    #endregion
}
