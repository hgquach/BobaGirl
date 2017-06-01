using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RangeEnemy : MonoBehaviour {

    //Variable to navigate

     public Transform[] patrolPathway;
    public float timer;
    public float rateOfFire = 3f;

    public Transform chaseTarget;
    public GameObject bobapoolContainer;
    public BobaPool bobapool;
    // secret variables 
    [HideInInspector] public Dectection FOD;
    [HideInInspector]public GameObject objectFOD;
    [HideInInspector] public ShooterRange shootrange;
    [HideInInspector] public GameObject objectRange;
    [HideInInspector] public GameObject bulletspawn;
    [HideInInspector] public IEnemyState currentState; 
    [HideInInspector] public RPatrolState patrolState;
    [HideInInspector] public RChaseState chaseState;
    [HideInInspector] public RAttackState attackState;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    



    // Use this for initialization

    private void Awake()
    {
        chaseState = new RChaseState(this);
        attackState = new RAttackState(this);
        patrolState = new RPatrolState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();

        bobapool = bobapoolContainer.GetComponent<BobaPool>();

        objectFOD = this.gameObject.transform.GetChild(0).gameObject;
        objectRange = this.gameObject.transform.GetChild(1).gameObject;
        bulletspawn = this.gameObject.transform.GetChild(2).gameObject;
        FOD = objectFOD.GetComponent<Dectection>();
        shootrange = objectRange.GetComponent<ShooterRange>();
         
    }
    void Start ()
    {
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

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
