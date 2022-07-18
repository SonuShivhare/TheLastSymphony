using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_PlayerDetector : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<TLS_Health>().Damage(damage);
            }
        }
    }
}