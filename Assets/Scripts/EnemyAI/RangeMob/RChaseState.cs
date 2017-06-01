using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RChaseState : IEnemyState
{
    private readonly RangeEnemy Enemy;
    public RChaseState(RangeEnemy rangeEnemy)
    {
        Enemy = rangeEnemy;
    }
    public void UpdateState()
    {
        Look();
        Chase();
    }

    public void toPatoralState()
    {
        Enemy.currentState = Enemy.patrolState;
    }

    public void toChaseState()
    {
        Debug.Log("should not be possible");
    }


    public void toAttackState()
    {
        Enemy.currentState = Enemy.attackState;
    }

    public void  OnTriggerEnter(Collider other)

    {
        toAttackState();
    }

    public void Look()
    {
        
        if (!Enemy.FOD.isDetected)
        {
            Debug.Log("back to patrol state");
            toPatoralState();
        }
        if (Enemy.shootrange.canShoot)
        {
            Debug.Log("to attack state");
            toAttackState();
        }

    }
    public void Chase()
    {
        Enemy.navMeshAgent.destination = Enemy.chaseTarget.position;
        Enemy.navMeshAgent.Resume();
    }
}