using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICannon
{
    void Shoot(float damageModifier);

    void Reload();
}
