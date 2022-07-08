using System.Collections;
using System.Collections.Generic;
using TheLastSymphony;
using UnityEngine;

public class TLS_SkeletonController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private int damage;
    #endregion

    #region private Field
    private Transform target;

    private float Speed;

    private bool isChasingPlayer;
    private bool isFacingRight;
    #endregion

    private void Awake()
    {
        isChasingPlayer = false;
        isFacingRight = false;
        Speed = Random.Range(minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        if (isChasingPlayer)
        {
            if (target.position.x < transform.position.x)
            {
                if (isFacingRight) Flip();
                transform.Translate(-Speed * Time.fixedDeltaTime, 0, 0, Space.World);
            }
            else
            {
                if (!isFacingRight) Flip();
                transform.Translate(Speed * Time.fixedDeltaTime, 0, 0, Space.World);
            }
        }
    }

    public void AssignTarget(Transform target)
    {
        this.target = target;

        if (target.position.x < transform.position.x)
        {
            if (isFacingRight) Flip();
        }
        else
        {
            if (!isFacingRight) Flip();
        }
    }

    public void ChaseTheTarget()
    {
        isChasingPlayer = true;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<TLS_Health>().Damage(damage);
            Destroy(this.gameObject);
        }
    }

    public void PlayDeathAnimation()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}
