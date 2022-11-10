using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipParts : MonoBehaviour
{
    [SerializeField] GameObject mainMast;
    [SerializeField] GameObject foreMast;
    [SerializeField] GameObject mizzenMast;
    
    [SerializeField] Transform starboardBroadsideParent;
    [SerializeField] Transform portBroadsideParent;

    [SerializeField] Transform sternCannonsParent;
    [SerializeField] Transform prowCannonsParent;

    [SerializeField] Transform ramParent;

    public GameObject MainMast => mainMast;
    public GameObject ForeMast => foreMast;
    public GameObject MizzenMast => mizzenMast;

    Transform[] starboardBroadside;
    Transform[] portBroadside;

    Transform[] prowCannons;
    Transform[] sternCannons;

    void Awake()
    {
        starboardBroadside = starboardBroadsideParent.GetComponentsInChildren<Transform>();
        portBroadside = portBroadsideParent.GetComponentsInChildren<Transform>();

        prowCannons = prowCannonsParent.GetComponentsInChildren<Transform>();
        sternCannons = sternCannonsParent.GetComponentsInChildren<Transform>();
    }

}
