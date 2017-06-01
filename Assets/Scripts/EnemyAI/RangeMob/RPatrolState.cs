using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPatrolState : IEnemyState
{
    private readonly RangeEnemy Enemy;
    private int destPoint = 0;
    public RPatrolState(RangeEnemy rangeEnemy)
    {
        Enemy = rangeEnemy;
    }
    public void UpdateState()
    {
        look();
        patrol();
    }

    public void toPatoralState()
    {
        Debug.Log("Not possible");

    }

    public void toChaseState()
    {
        Enemy.currentState = Enemy.chaseState;
    }
       

    public void toAttackState()

    {
        Enemy.currentState = Enemy.attackState;
    }

    public void  OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            toAttackState();
        }
    }

    public void patrol()
    {
        if (Enemy.patrolPathway.Length == 0)
            Debug.Log("No patrol Pathway");
        Enemy.navMeshAgent.destination = Enemy.patrolPathway[destPoint].position;
        Enemy.navMeshAgent.Resume();
        if (Enemy.navMeshAgent.remainingDistance <= Enemy.navMeshAgent.stoppingDistance && !Enemy.navMeshAgent.pathPending)
        {
            destPoint = (destPoint + 1) % Enemy.patrolPathway.Length;
        }
    }
    
    public void look()
    {
        if(Enemy.FOD.isDetected)
        {
            Debug.Log("to chase state");
            toChaseState();
        }

        if(Enemy.shootrange.canShoot)
        {
            Debug.Log("to attack state");
            toAttackState();
        }
    }
 

}

