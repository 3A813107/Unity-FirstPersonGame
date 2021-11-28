using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private EnemyStats stats =null;
    [SerializeField] private Transform mainBuilding;
    [SerializeField] private Transform BoomCarryPos;
    [SerializeField] private Transform player;
    public Transform BoomDrop;
    [SerializeField] private Vector3 currentTarget;

    [SerializeField]private bool alreadyAttacked;
    [SerializeField]private bool PlayerInDetectRange;
    [SerializeField]private bool PlayerInAttackRange;
    //private float LastAttackTime = 0;
    public Boom[] boomIv;
    [SerializeField] private float DetectRange;
    [SerializeField] private float AttackRange;
    [SerializeField] private LayerMask wahatIsPlayer;

    




    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
        boomIv = new Boom[1];
    }

    private void Update()
    {
        PlayerInDetectRange = Physics.CheckSphere(transform.position,DetectRange,wahatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position,AttackRange,wahatIsPlayer);
        if(!PlayerInDetectRange && !PlayerInAttackRange) MoveToMainBuilding();
        if(PlayerInDetectRange && !PlayerInAttackRange && GameManager.instance.isboomTaking) ChasePlayer();
        if(PlayerInDetectRange && PlayerInAttackRange && GameManager.instance.isboomTaking) AttackPlayer();
    }

    private void MoveToMainBuilding()
    {
        TargetCheak();
        agent.SetDestination(currentTarget);  
        //RotateToTarget();
    }

    private void RotateToTarget()
    {
        Vector3 direction = currentTarget - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction+new Vector3 (0,-direction.y,0),Vector3.up);
        transform.rotation = rotation;        
    }

    private void AttackPlayer(PlayerStats statsToDamage)
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
            Instantiate(boomIv[0].Prebab,BoomCarryPos);
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

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        if(!alreadyAttacked)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            AttackPlayer(playerStats);
            alreadyAttacked=true;
            Invoke("ResetAttack",stats.attackSpeed);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, DetectRange);
    }
}
