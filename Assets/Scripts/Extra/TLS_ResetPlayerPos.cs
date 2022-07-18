using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_ResetPlayerPos : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        GameObject.Find("Player").transform.position = this.transform.position;
    }
}
