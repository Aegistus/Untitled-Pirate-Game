using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : AIState
{
    float wanderDistance = 50f;
    float recalculateDestinationRange = 5f;

    public WanderState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {

    }

    public override void BeforeExecution()
    {
        SetRandomDestination();
    }

    public override void DuringExecution(float deltaTime)
    {
        if (Vector3.Distance(transform.position, controller.Destination) < recalculateDestinationRange)
        {
            SetRandomDestination();
        }
    }

    public override void AfterExecution()
    {
        controller.SetDestination(transform.position);
    }

    void SetRandomDestination()
    {
        float x = Random.Range(-wanderDistance, wanderDistance);
        float z = Random.Range(-wanderDistance, wanderDistance);
        Vector3 destination = new Vector3(x, 0, z);
        controller.SetDestination(destination);
    }
}
