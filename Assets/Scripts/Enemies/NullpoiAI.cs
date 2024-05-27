using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NullpoiAI : MonoBehaviour
{
    private Transform target;

    public float speed = 500f;
    public float nextWaypointDistance = 3f;
    public float projAccelSpeed = 30f;
    public float aggroDist = 25f;

    public Animator nAnim;

    private Path path;
    private int currentWaypoint = 0;
    bool reachedEndPath = false;
    bool attacking = false;
    private Vector2 targetDir;

    Seeker seeker;
    Rigidbody2D rb;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public void Attack(GameObject projectile)
    {
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            attacking = true;

            StartCoroutine(AttackSpawning(projectile));
        }
    }

    private IEnumerator AttackSpawning(GameObject projectile)
    {
        GameObject instProj;
        for(int i = 0; i < 2; i++)
        {
            instProj = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            instProj.GetComponent<NullpoiProjectile>().setAccelSpeed(projAccelSpeed);
            instProj.GetComponent<NullpoiProjectile>().setFields(3, false);

            yield return new WaitForSeconds(.5f);
        }

        instProj = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        instProj.GetComponent<NullpoiProjectile>().setAccelSpeed(projAccelSpeed);
        instProj.GetComponent<NullpoiProjectile>().setFields(3, false);

        attacking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;

        hit = Physics2D.Raycast((Vector2)transform.position + targetDir, targetDir, aggroDist);

        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndPath = true;
            return;
        }
        else
        {
            reachedEndPath = false;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        if (!attacking && hit.collider != null && hit.collider.CompareTag("Player"))
            rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (attacking)
        {
            //preferably make an attacking animation where the eye glows
            nAnim.ResetTrigger("Moving");
            nAnim.SetTrigger("Idle");
        }
        else if (force.x > 0.05f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

            nAnim.ResetTrigger("Idle");
            nAnim.SetTrigger("Moving");
        }
        else if (force.x < -0.05f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            nAnim.ResetTrigger("Idle");
            nAnim.SetTrigger("Moving");
        }
        else
        {
            nAnim.ResetTrigger("Moving");
            nAnim.SetTrigger("Idle");
        }
    }
}
