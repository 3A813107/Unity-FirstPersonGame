using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    private float timer=0;
    void Update()
    {
        if(timer > 2f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer+=Time.deltaTime;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStats>().DamegCheaak(damage);
            Destroy(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
}
