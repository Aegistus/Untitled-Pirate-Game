using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AIController : MonoBehaviour
{
    public Vector3 Destination => navAgent.destination;

    public FieldOfView starboardSensor;
    public FieldOfView portSensor;

    StateMachine stateMachine = new StateMachine();
    NavMeshAgent navAgent;
    ShipMovement movement;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        movement = GetComponent<ShipMovement>();
        Dictionary<Type, State> states = new Dictionary<Type, State>()
        {
            { typeof(WanderState), new WanderState(gameObject, this) },
            { typeof(ChaseState), new ChaseState(gameObject, this) },
            { typeof(AttackState), new AttackState(gameObject, this) },
        };
        stateMachine.SetStates(states, typeof(WanderState));
    }

    public void SetDestination(Vector3 position)
    {
        navAgent.destination = position;
        if (movement.CurrentSailState == ShipMovement.SailState.ANCHORED)
        {
            movement.IncreaseSpeed();
        }
    }

    public void Anchor()
    {
        navAgent.SetDestination(transform.position);
        // done twice in case the ship is full sail.
        movement.DecreaseSpeed();
        movement.DecreaseSpeed();
    }

    void Update()
    {
        stateMachine.ExecuteState(Time.deltaTime);
    }

    // points ship towards next point on navAgent's path
    public void TurnTowardsPath()
    {
        if (navAgent.hasPath && navAgent.path.corners.Length > 1)
        {
            float angleDirection = AngleDirection(-transform.forward, transform.position - navAgent.path.corners[1], Vector3.up);
            movement.Turn(angleDirection);
        }
    }

    public void TurnTowards(Vector3 target, Vector3 forward)
    {
        float angleDirection = AngleDirection(-forward, transform.position - target, Vector3.up);
        movement.Turn(angleDirection);
    }

    // returns -1 for left, 1 for right, and 0 if already looking
    public float AngleDirection(Vector3 forward, Vector3 targetDirection, Vector3 upVector)
    {
        Vector3 perpendicular = Vector3.Cross(forward, targetDirection);
        float direction = Vector3.Dot(perpendicular, upVector);

        if (direction > 0f)
        {
            return 1f;
        }
        else if (direction < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
	}

    void OnDrawGizmos()
    {
        if (navAgent != null && navAgent.hasPath)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < navAgent.path.corners.Length; i++)
            {
                Gizmos.DrawSphere(navAgent.path.corners[i], 1f);
            }
        }
    }
}
