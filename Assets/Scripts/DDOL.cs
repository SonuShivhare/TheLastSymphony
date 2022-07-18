using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public GameObject[] DDOLObjs;

    private void Awake()
    {
        foreach (var item in DDOLObjs)
        {
            DontDestroyOnLoad(item);    
        }
    }
}
