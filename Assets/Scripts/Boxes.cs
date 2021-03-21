using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public static Boxes Instance { get; private set; }
    
    public bool IsMouseOnAnyBox()
    {
        foreach (Transform transform in transform)
        {
            if (transform.gameObject.GetComponent<Box>().IsMouseOnBox)
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        Instance = this;
    }
}
