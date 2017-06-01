using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAttackState : IEnemyState
{
    public float bulletSpeed = 1000.0f;
    private readonly RangeEnemy Enemy;
    public RAttackState(RangeEnemy rangeEnemy)
    {
        Enemy = rangeEnemy;
    }
    public void UpdateState()
    {
        Enemy.navMeshAgent.Stop();

        Fire();
        Look();
    }

    public void toPatoralState()
    {
        Enemy.navMeshAgent.Resume();

        Enemy.currentState = Enemy.patrolState;
    }

    public void toChaseState()
    {
        Enemy.navMeshAgent.Resume();

        Enemy.currentState = Enemy.chaseState;
    }


    public void toAttackState()

    {

    }

    public void OnTriggerEnter(Collider other)

    {

    }

    public void Look()
    {
        if (!Enemy.FOD.isDetected)
        {
            toPatoralState();
        }

        if (!Enemy.shootrange && Enemy.FOD.isDetected)
        {
            toChaseState();
        }
    }

    public void Fire()
    {
        Vector3 TargetPosition = new Vector3(Enemy.chaseTarget.position.x, Enemy.transform.position.y, Enemy.chaseTarget.position.z);
        Enemy.GetComponent<Transform>().LookAt(TargetPosition);

        if (Enemy.timer > Enemy.rateOfFire)
        {
            for (int i = 0; i < Enemy.bobapool.bobaPool.Count; ++i)
            {
                if(!Enemy.bobapool.bobaPool[i].activeInHierarchy)
                {
                    Enemy.bobapool.bobaPool[i].transform.position = Enemy.bulletspawn.GetComponent<Transform>().position;
                    Enemy.bobapool.bobaPool[i].transform.rotation = Enemy.bulletspawn.GetComponent<Transform>().rotation;
                    Enemy.bobapool.bobaPool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Enemy.bobapool.bobaPool[i].SetActive(true);
                    Debug.Log("something: " +Enemy.bulletspawn.transform);
                    Enemy.bobapool.bobaPool[i].GetComponent<Rigidbody>().AddForce(Enemy.transform.forward* bulletSpeed);
                    break;
                }
            }

            Enemy.timer = 0;

        }

    }

}