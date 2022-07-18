using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_ResetEnemy : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject.Find("EnemySpawner").GetComponent<TLS_EnemySpawner>().deployHellHound();
        }
    }
}