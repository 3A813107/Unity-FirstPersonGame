using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject explosionEffect;
    public float delay = 1f;

    public float explosionForce = 10f;
    public float radius = 20f;

    public LayerMask GroundMask;
    public LayerMask EnemyMask;

    public int damage=20;

    [SerializeField]private bool canExplode=false;
    void Update()
    {
       Cheak(); 
       if(canExplode)
       {
           Explode();
       }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            EnemyStats enemy = near.GetComponent<EnemyStats>();

            if(rig!=null)
            {
                rig.AddExplosionForce(explosionForce,transform.position,radius,1f,ForceMode.Impulse);
            }
            if(enemy!=null)
            {
                enemy.DamageCheak(damage);
            }
        }

        Instantiate(explosionEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void Cheak()
    {
        canExplode = (Physics.CheckSphere(transform.position,0.5f,GroundMask)||Physics.CheckSphere(transform.position,0.5f,EnemyMask));

    }
        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,5f);

    }
}
