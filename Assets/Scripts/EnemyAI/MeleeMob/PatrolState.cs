using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private readonly MeleeEnemy mEnemy;
    private int destPoint = 0;
    public PatrolState(MeleeEnemy meleeEnemy)
    {
        mEnemy = meleeEnemy;
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
        mEnemy.currentState = mEnemy.chaseState;
    }
       

    public void toAttackState()

    {
        mEnemy.currentState = mEnemy.attackState;
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
        if (mEnemy.patrolPathway.Length == 0)
            Debug.Log("No patrol Pathway");
        mEnemy.navMeshAgent.destination = mEnemy.patrolPathway[destPoint].position;
        mEnemy.navMeshAgent.Resume();
        if (mEnemy.navMeshAgent.remainingDistance <= mEnemy.navMeshAgent.stoppingDistance && !mEnemy.navMeshAgent.pathPending)
        {
            destPoint = (destPoint + 1) % mEnemy.patrolPathway.Length;
        }
    }
    
    public void look()
    {
        if(mEnemy.FOD.isDetected)
        {
            toChaseState();
        }
    }
 

}

