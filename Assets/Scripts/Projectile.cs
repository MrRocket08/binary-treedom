using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ps;

    protected int damage;
    protected bool isPiercing;

    public void setFields(int _damage, bool _isPiercing)
    {
        damage = _damage;
        isPiercing = _isPiercing;
    }
    private void Start()
    {
        StartCoroutine(DelayDestroy());   
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().subtractHealth(damage);

            if (!isPiercing)
            {
                //Instantiate(ps, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity);
                Destroy(this.gameObject);
            }
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
