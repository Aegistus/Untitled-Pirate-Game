using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;
using System;

public class WanderState : AIState
{
    float wanderDistance = 50f;
    float recalculateDestinationRange = 5f;

    public WanderState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {
        Transition playerSpotted = new Transition(typeof(ChaseState));
        fov.OnTargetFound += playerSpotted.ManuallyTrigger;
        transitionsTo.Add(playerSpotted);
    }

    public override void BeforeExecution()
    {
        Debug.Log("Wandering");
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
