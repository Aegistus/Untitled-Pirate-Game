using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipWeapons : MonoBehaviour
{
    [SerializeField] Transform starboardWeaponsParent;
    [SerializeField] Transform portWeaponsParent;
    [SerializeField] Transform prowWeaponsParent;
    [SerializeField] Transform sternWeaponsParent;

    public float ShipDamageModifier { get; private set; } = 1f;

    List<ICannon> starboardWeapons;
    List<ICannon> portWeapons;
    List<ICannon> prowWeapons;
    List<ICannon> sternWeapons;
    Dictionary<ShipDirection, List<ICannon>> directionToWeapons = new Dictionary<ShipDirection, List<ICannon>>();

    void Awake()
    {
        starboardWeapons = starboardWeaponsParent.GetComponentsInChildren<ICannon>().ToList();
        portWeapons = portWeaponsParent.GetComponentsInChildren<ICannon>().ToList();
        prowWeapons = prowWeaponsParent.GetComponentsInChildren<ICannon>().ToList();
        sternWeapons = sternWeaponsParent.GetComponentsInChildren<ICannon>().ToList();
        directionToWeapons.Add(ShipDirection.Starboard, starboardWeapons);
        directionToWeapons.Add(ShipDirection.Port, portWeapons);
        directionToWeapons.Add(ShipDirection.Prow, prowWeapons);
        directionToWeapons.Add(ShipDirection.Stern, sternWeapons);
    }

    public void FireWeaponsOnSide(ShipDirection side)
    {
        List<ICannon> weapons = directionToWeapons[side];
        if (weapons.Count > 0)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Shoot(ShipDamageModifier);
            }
        }
    }

    public void AddToDamageModifier(float amount)
    {
        ShipDamageModifier += amount;
    }
}
