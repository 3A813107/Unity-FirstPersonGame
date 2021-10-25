using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    private EnemyStats stats =null;

    private bool hasStop = false;
    private float LastAttackTime = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
    }

    private void Update()
    {
        MoveToTaget();
    }

    private void MoveToTaget()
    {
        agent.SetDestination(target.position);
        RotateToTarget(); 
        float disToTarget = Vector3.Distance(target.position,transform.position);
        if(disToTarget <= agent.stoppingDistance)
        {

            if(!hasStop)
            {
                hasStop = true;
                LastAttackTime = Time.time;
            }

            if(Time.time >= LastAttackTime + stats.attackSpeed)
            {
                LastAttackTime = Time.time;            
                PlayerStats targetStats = target.GetComponent<PlayerStats>();
                AttackTaget(targetStats);
            }
        }
        else
        {
            if(hasStop)
            {
                hasStop = false;
            }
        }
           
    }

    private void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction+new Vector3 (0,-direction.y,0),Vector3.up);
        transform.rotation = rotation;        
    }

    private void AttackTaget(PlayerStats statsToDamage)
    {
        stats.DealDamage(statsToDamage);
    }
}
