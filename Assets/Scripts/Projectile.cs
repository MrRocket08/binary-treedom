using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem ps;

    private int damage;
    private bool isPiercing;

    public void setFields(int _damage, bool _isPiercing)
    {
        damage = _damage;
        isPiercing = _isPiercing;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().subtractHealth(damage);

            if (!isPiercing)
            {
                Instantiate(ps, transform.position, Quaternion.identity);
                Destroy(this);
            }
        }
    }
}
