using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSlapper : Weapon
{

    public Transform currentTransform;
    public TreeSlapper(string nombre) : base(nombre, "TreeSlapper", 5, 3, 2, 20, 20) { currentTransform = transform; }

    // Update is called once per frame
    public void Hit()
    {
        if (Input.GetMouseButton(0))
        {
            // animation of sword swinging
            Collider2D[] hits = Physics2D.OverlapBoxAll(currentTransform.position, new Vector2(1, 1), currentTransform.rotation.eulerAngles.x);
            if (hits != null)
            {
                foreach (Collider2D Col in hits)
                {
                    if (Col.gameObject.CompareTag("Enemy"))
                    {
                        Col.gameObject.GetComponent<Enemy>().subtractHealth(Random.Range(damage - damageRange, damage + damageRange));
                        Debug.Log("Hit");
                    }
                }
            }
        }
    }

}
