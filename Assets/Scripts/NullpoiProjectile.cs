using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullpoiProjectile : Projectile
{
    public GameObject player;

    private Rigidbody2D rb;
    private float accelSpeed;
    private Vector2 shootDir;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(5);

        Instantiate(ps, (Vector2)transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        shootDir = (player.transform.position - transform.position).normalized;

        rb.AddForce(shootDir * accelSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        transform.right = shootDir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().getHit(damage, new Vector2(0f, 0f));

            if (!isPiercing)
            {
                Instantiate(ps, (Vector2)transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(ps, (Vector2)transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void setAccelSpeed(float _accelSpeed)
    {
        accelSpeed = _accelSpeed;
    }
}
