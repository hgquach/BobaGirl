using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private readonly MeleeEnemy mEnemy;
    public ChaseState(MeleeEnemy meleeEnemy)
    {
        mEnemy = meleeEnemy;
    }
    public void UpdateState()
    {
        Look();
        Chase();
    }

    public void toPatoralState()
    {
        mEnemy.currentState = mEnemy.patrolState;
    }

    public void toChaseState()
    {
        Debug.Log("should not be possible");
    }


    public void toAttackState()
    {
        mEnemy.currentState = mEnemy.attackState;
    }

    public void  OnTriggerEnter(Collider other)

    {
        toAttackState();
    }

    public void Look()
    {
        
        if (!mEnemy.FOD.isDetected)
        {
            Debug.Log("back to patrol state");
            toPatoralState();
        }
        if (mEnemy.IZ.canAttack)
        {
            Debug.Log("to attack stage");
            toAttackState();
        }
        
    }
    public void Chase()
    {
        mEnemy.navMeshAgent.destination = mEnemy.chaseTarget.position;
        mEnemy.navMeshAgent.Resume();
    }
}