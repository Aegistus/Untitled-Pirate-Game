using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    float broadsideDistance = 50f;
    ShipWeapons weapons;
    float minimumTime = 5f;
    float timer = 0f;

    public ChaseState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {
        transitionsTo.Add(new Transition(typeof(WanderState), () => fov.visibleTargets.Count == 0 && timer >= minimumTime));
        transitionsTo.Add(new Transition(typeof(AttackState), () => controller.starboardSensor.HasTarget || controller.portSensor.HasTarget));
        weapons = gameObject.GetComponent<ShipWeapons>();
    }

    public override void BeforeExecution()
    {
        Debug.Log("Chasing");
        timer = 0f;
    }

    public override void DuringExecution(float deltaTime)
    {
        if (fov.visibleTargets.Count > 0)
        {
            controller.SetDestination(PickTargetSide(fov.visibleTargets[0]));
        }
        controller.TurnTowardsPath();
        timer += deltaTime;
    }

    public override void AfterExecution()
    {
        
    }

    Vector3[] sides = new Vector3[4];
    float[] sideDistances = new float[4];
    // finds which side of the target is closer in order to choose a direction of attack.
    Vector3 PickTargetSide(Transform target)
    {
        sides[0] = target.position + target.TransformVector(Vector3.left * broadsideDistance); // left
        sides[1] = target.position + target.TransformVector(Vector3.right *  broadsideDistance); // right
        sides[2] = target.position + target.TransformVector(Vector3.forward * broadsideDistance); // front
        sides[3] = target.position + target.TransformVector(Vector3.back * broadsideDistance); // back
        sideDistances[0] = (transform.position - sides[0]).sqrMagnitude;
        sideDistances[1] = (transform.position - sides[1]).sqrMagnitude;
        sideDistances[2] = (transform.position - sides[2]).sqrMagnitude;
        sideDistances[3] = (transform.position - sides[3]).sqrMagnitude;
        float shortestDistance = float.MaxValue;

        int shortestIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            if (sideDistances[i] < shortestDistance)
            {
                shortestDistance = sideDistances[i];
                shortestIndex = i;
            }
        }
        return sides[shortestIndex];
    }
}
