using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    ShipWeapons weapons;

    public AttackState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {
        transitionsTo.Add(new Transition(typeof(ChaseState), () => !controller.starboardSensor.HasTarget && !controller.portSensor.HasTarget));
        weapons = gameObject.GetComponent<ShipWeapons>();
    }

    public override void BeforeExecution()
    {
        Debug.Log("Attacking");
    }

    public override void DuringExecution(float deltaTime)
    {
        if (controller.portSensor.HasTarget)
        {
            weapons.FireWeaponsOnSide(ShipDirection.Port);
        }
        if (controller.starboardSensor.HasTarget)
        {
            weapons.FireWeaponsOnSide(ShipDirection.Starboard);
        }
        controller.SetDestination(transform.forward);
    }

    public override void AfterExecution()
    {
        
    }
}
