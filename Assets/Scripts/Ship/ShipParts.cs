using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipParts : MonoBehaviour
{
    [SerializeField] GameObject foreMast;
    [SerializeField] GameObject foreFurled;
    [SerializeField] GameObject mainMast;
    [SerializeField] GameObject mainFurled;
    [SerializeField] GameObject mizzenMast;
    [SerializeField] GameObject mizzenFurled;

    [SerializeField] Transform starboardBroadsideParent;
    [SerializeField] Transform portBroadsideParent;

    [SerializeField] Transform sternCannonsParent;
    [SerializeField] Transform prowCannonsParent;

    [SerializeField] Transform ramParent;

    public GameObject ForeMast => foreMast;
    public GameObject ForeFurled => foreFurled;
    public GameObject MainMast => mainMast;
    public GameObject MainFurled => mainFurled;
    public GameObject MizzenMast => mizzenMast;
    public GameObject MizzenFurled => mizzenFurled;

    Transform[] starboardBroadside;
    Transform[] portBroadside;

    Transform[] prowCannons;
    Transform[] sternCannons;

    void Awake()
    {
        starboardBroadside = starboardBroadsideParent.GetComponentsInChildren<Transform>();
        portBroadside = portBroadsideParent.GetComponentsInChildren<Transform>();

        if (prowCannons != null)
        {
            prowCannons = prowCannonsParent.GetComponentsInChildren<Transform>();
        }
        if (sternCannons != null)
        {
            sternCannons = sternCannonsParent.GetComponentsInChildren<Transform>();
        }
    }

}
