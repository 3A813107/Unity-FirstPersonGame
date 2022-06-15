using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_big : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private EnemyStats stats =null;
    [SerializeField] private Transform mainBuilding;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 currentTarget;

    [SerializeField]private bool alreadyAttacked;
    [SerializeField]private bool PlayerInDetectRange;
    [SerializeField]private bool PlayerInAttackRange;
    //private float LastAttackTime = 0;
    [SerializeField] private float DetectRange;
    [SerializeField] private float AttackRange;
    [SerializeField] private LayerMask wahatIsPlayer;



    private Animator anim = null;

    private void Start()
    {
        player = PlayerMovement.instance;
        mainBuilding = MainBuileding.instance;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerInDetectRange = Physics.CheckSphere(transform.position,DetectRange,wahatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position,AttackRange,wahatIsPlayer);
        if(!GameManager.instance.PlayerDie)
        {
            if(!PlayerInDetectRange && !PlayerInAttackRange) MoveToMainBuilding();
            if(PlayerInDetectRange && !PlayerInAttackRange) ChasePlayer();
            if(PlayerInDetectRange && PlayerInAttackRange) AttackPlayer();
        }
        else
        {
            MoveToMainBuilding();
        }

    }

    private void MoveToMainBuilding()
    {
        TargetCheak();
        agent.SetDestination(currentTarget);  
        anim.SetFloat("Speed",1f, 0.3f,Time.deltaTime);
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
        anim.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }


    private void TargetCheak()
    {
        currentTarget = mainBuilding.transform.position;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetFloat("Speed",1f, 0.3f,Time.deltaTime);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
            AttackPlayer(playerStats);    
            playerMove.velocity.y=Mathf.Sqrt(40f * -2f *-9.18f);
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
