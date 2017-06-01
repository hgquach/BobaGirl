using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    //Variable to navigate

     public Transform[] patrolPathway;
    // secret variables 
    [HideInInspector] public Dectection FOD;
    [HideInInspector] public EnemyInjury IZ;
    [HideInInspector]public GameObject objectFOD;
    [HideInInspector] public GameObject objectIZ;

     public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState; 
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public MAttackState attackState;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;



    // Use this for initialization

    private void Awake()
    {
        chaseState = new ChaseState(this);
        attackState = new MAttackState(this);
        patrolState = new PatrolState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();

        objectFOD = this.gameObject.transform.GetChild(0).gameObject;
        objectIZ = this.gameObject.transform.GetChild(1).gameObject;

        FOD = objectFOD.GetComponent<Dectection>();
        IZ = objectIZ.GetComponent<EnemyInjury>();

    }
    void Start ()
    {
 
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentState.UpdateState();	
	}

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter( other);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Parent")
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), other.collider);
        }
    }
}
