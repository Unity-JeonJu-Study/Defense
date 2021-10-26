using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance;

    [HideInInspector] public List<WayPoint> waypointList;
    private void Awake()
    {
        Instance = this;
        waypointList = GetComponentsInChildren<WayPoint>().ToList();
    }
}