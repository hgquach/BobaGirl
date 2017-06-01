using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{

    void UpdateState();

    void toPatoralState();

    void toChaseState();

    void toAttackState();

    void OnTriggerEnter(Collider other);
       
    

}
