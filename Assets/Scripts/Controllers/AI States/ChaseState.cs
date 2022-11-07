using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{


    public ChaseState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {
        transitionsTo.Add(new Transition(typeof(WanderState), () => fov.visibleTargets.Count == 0));
    }

    public override void BeforeExecution()
    {
        Debug.Log("Chase state!");
    }

    public override void DuringExecution(float deltaTime)
    {
        if (fov.visibleTargets.Count > 0)
        {
            controller.SetDestination(fov.visibleTargets[0].position);
        }
    }

    public override void AfterExecution()
    {
        
    }
}
