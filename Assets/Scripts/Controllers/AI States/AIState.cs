using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIState : State
{
    protected AIController controller;

    public AIState(GameObject gameObject, AIController controller) : base(gameObject)
    {
        this.controller = controller;
    }
}
