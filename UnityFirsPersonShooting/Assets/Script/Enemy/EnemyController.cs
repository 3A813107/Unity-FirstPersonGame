using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField] private Transform mainBuilding;
    //[SerializeField] private Transform Boom;
    [SerializeField] private Vector3 currentTarget;
    private EnemyStats stats =null;

    [SerializeField] GameObject BoomObject;

    private bool hasStop = false;
    private float LastAttackTime = 0;

    public Transform BoomDrop;

    public Boom[] boomIv;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
        boomIv = new Boom[1];
    }

    private void Update()
    {
        MoveToTaget();
        if(Input.GetKeyDown(KeyCode.U))
        {
            stats.Die();
        }
    }

    private void MoveToTaget()
    {
        TargetCheak();
        agent.SetDestination(currentTarget);  
        RotateToTarget();

        float disToTarget = Vector3.Distance(currentTarget,transform.position);
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
                //PlayerStats targetStats = target.GetComponent<PlayerStats>();
                //AttackTaget(targetStats);
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
        Vector3 direction = currentTarget - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction+new Vector3 (0,-direction.y,0),Vector3.up);
        transform.rotation = rotation;        
    }

    private void AttackTaget(PlayerStats statsToDamage)
    {
        stats.DealDamage(statsToDamage);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Boom")
        {
            GameManager.instance.isboomTaking = true;
            Debug.Log("boom pick up");
            Boom newboom = collider.transform.GetComponent<ItemObject>().item as Boom;
            boomIv[0] = newboom;
            Destroy(collider.gameObject);
        }
    }

    private void TargetCheak()
    {
        if(!GameManager.instance.isboomTaking)
        {
            currentTarget = GameManager.instance.currentBoomPos;
        }
        else
        {
            currentTarget = mainBuilding.transform.position;
        }
    }

}
