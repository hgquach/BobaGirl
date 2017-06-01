using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAttackState : IEnemyState
{

    private readonly MeleeEnemy mEnemy;
    public MAttackState(MeleeEnemy meleeEnemy)
    {
        mEnemy = meleeEnemy;
    }
    public void UpdateState()
    {
        Look();
    }

    public void toPatoralState()
    {
        mEnemy.currentState = mEnemy.patrolState;
    }

    public void toChaseState()
    {
        mEnemy.currentState = mEnemy.chaseState;
    }


    public void toAttackState()

    {

    }

    public void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player" && mEnemy.IZ.canAttack)
        {
            other.GetComponent<PlayerHealth>().takeLive();
        }

    }

    public void Look()
    {

        if (!mEnemy.FOD.isDetected)
        {
            Debug.Log("back to patrol state");
            toPatoralState();
        }
        if (!mEnemy.IZ.canAttack)
        {
            toChaseState();
        }

    }
}