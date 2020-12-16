using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups_health : MonoBehaviour
{
    [SerializeField]private int hp=50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.Tags.Player)) 
        {
            other.GetComponent<IRecover>().RecoverHealth(hp);
            //TODO 以后对象池
            Destroy(this.gameObject);
        }
    }
}
