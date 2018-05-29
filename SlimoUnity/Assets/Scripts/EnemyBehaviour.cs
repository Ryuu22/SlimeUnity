using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    private enum EnemyState {Idle, Patrol, Chase, Attack, Stun, Dead }
    [SerializeField] EnemyState state;

    [SerializeField] bool isStopped;

    [Header("Timers")]
    
    public float idleTime = 1;
    public float timeCounter = 1;

    [Header("Paths")]

    public Transform[] Path;
    public int PathIndex;

    private NavMeshAgent agent;
    [SerializeField] private Transform targetTransform;

    [Header("Paths")]

    public float chaseRange;
    public float attackRange;
    [SerializeField]private float distanceFromTarget = Mathf.Infinity;

    [Header("Stats")]
    
    public bool canAttack = false;
    public int hitDamage = 3;
    public float coolDownAttack = 1.0f;
    public float timeToLive;

    [Header("Animation")]

    public Animator anim;
    public bool walking;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        //targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateDistanceFromTarget();
        this.isStopped = agent.isStopped;
        

        switch(state)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.Chase:
                ChaseUpdate();
                break;
            case EnemyState.Attack:
                AttackUpdate();
                break;
            case EnemyState.Stun:
                StunUpdate();
                break;
            case EnemyState.Dead:
                DeadUpdate();
                break;
            default:
                break;
        }
        //anim.SetInteger("Life", life);


        //anim.SetBool("walking",walking);
    }
    #region updates
    void IdleUpdate()
    {
        timeCounter+=Time.deltaTime;
        if(timeCounter >= idleTime)
        {
            Debug.Log("change to patrol");
            SetPatrol();
        }
    }
    void PatrolUpdate()
    {
        if(distanceFromTarget < chaseRange)
        {
            SetChase();
            return;
        }
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            PathIndex++;
            if(PathIndex >= Path.Length) PathIndex = 0;
            SetPatrol();
        }
    }
    void ChaseUpdate()
    {
        agent.SetDestination(targetTransform.position);

        if(distanceFromTarget > chaseRange)
        {
            SetPatrol();
            return;
        }
        if(distanceFromTarget < attackRange)
        {

            SetAttack();
        }

    }
    void AttackUpdate()
    {
        agent.SetDestination(targetTransform.position);
        if(distanceFromTarget > attackRange)
        {
            SetChase();
            return;
        }
        if(canAttack)
        {
            agent.isStopped = false;
            anim.SetTrigger("Attack");
            targetTransform.GetComponent<PlayerBehaviour>().SetDamage(hitDamage);

            idleTime = coolDownAttack;
            SetIdle();
        }
    }
    void StunUpdate()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= idleTime)
        {
            idleTime = 0;
            SetIdle();
        }
    }
    void DeadUpdate()
    {
        timeToLive -= 1 * Time.deltaTime;
        if(timeToLive <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }
    #endregion

    #region states
    void SetIdle()
    {
        walking = false;
        timeCounter = 0;
        state = EnemyState.Idle;
    }
    void SetChase()
    {
        walking = true;
        if (agent.isStopped) agent.isStopped = false;
        state = EnemyState.Chase;
    }
    void SetPatrol()
    {
        walking = true;
        agent.isStopped = false;
        agent.SetDestination(Path[PathIndex].position);
        state = EnemyState.Patrol;
    }
    void SetAttack()
    {
        canAttack = true;
        state = EnemyState.Attack;
    }
    void SetStun()
    {
        canAttack = false;
        timeCounter = 0;
        state = EnemyState.Stun;
    }
    void SetDead()
    {
        canAttack = false;
        agent.isStopped = true;
        state = EnemyState.Dead;
    }

    #endregion
    #region Public Functions
    public void SetDamage()
    {
        anim.SetTrigger("GotDamage");
        SetDead();
        
    }

    #endregion
    void CalculateDistanceFromTarget()
    {
        distanceFromTarget = Vector3.Distance(transform.position, targetTransform.position);
    }
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Color newColor = Color.red;
        newColor.a = 0.2f;
        Gizmos.color = newColor;
        Gizmos.DrawSphere(transform.position, attackRange);
    }*/
    void OntriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canAttack = true;
        }
    }
    void OntriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canAttack = false;
        }

    }

}
