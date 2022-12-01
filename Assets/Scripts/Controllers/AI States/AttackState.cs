using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    ShipWeapons weapons;
    float timer;
    float attackDelay = .5f;

    public AttackState(GameObject gameObject, AIController controller) : base(gameObject, controller)
    {
        transitionsTo.Add(new Transition(typeof(ChaseState), () => !controller.starboardSensor.HasTarget && !controller.portSensor.HasTarget));
        weapons = gameObject.GetComponent<ShipWeapons>();
    }

    public override void BeforeExecution()
    {
        Debug.Log("Attacking");
        timer = 0;
    }

    public override void DuringExecution(float deltaTime)
    {
        if (timer >= attackDelay)
        {
            if (controller.portSensor.HasTarget)
            {
                weapons.FireWeaponsOnSide(ShipDirection.Port);
            }
            if (controller.starboardSensor.HasTarget)
            {
                weapons.FireWeaponsOnSide(ShipDirection.Starboard);
            }
            timer = 0;
        }
        timer += deltaTime;

        controller.SetDestination(transform.forward);
    }

    public override void AfterExecution()
    {
        
    }
}
