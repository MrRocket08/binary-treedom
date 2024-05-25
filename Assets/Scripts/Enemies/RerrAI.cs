using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RerrAI : MonoBehaviour
{
    private Transform target;

    public float speed = 500f;
    public float nextWaypointDistance = 3f;
    public float aggroDist = 20f;

    public Transform RerrGFX;
    public Animator rAnim;

    private Path path;
    private int currentWaypoint = 0;
    bool reachedEndPath = false;

    Seeker seeker;
    Rigidbody2D rb;
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

    // Update is called once per frame
    void FixedUpdate()
    {
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

        if (Vector2.Distance(transform.position, target.position) <= aggroDist)
            rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x > 0.05f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

            rAnim.ResetTrigger("Idle");
            rAnim.SetTrigger("Moving");
        }
        else if (force.x < -0.05f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rAnim.ResetTrigger("Idle");
            rAnim.SetTrigger("Moving");
        }
        else
        {
            rAnim.ResetTrigger("Moving");
            rAnim.SetTrigger("Idle");
        }
    }
}
