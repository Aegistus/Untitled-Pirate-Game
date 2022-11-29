using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICannon
{
    public bool IsLoaded { get; }

    void Shoot(float damageModifier);

    void Reload(float delayModifier);
}
