using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjects : MonoBehaviour
{
    public static MapObjects Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }
}
