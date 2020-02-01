using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    // Editor
    public float maxDistance;

    // Refs
    private LineRenderer line;

    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        line.SetPosition(0, transform.position);

        if (hit.collider != null) {
            line.SetPosition(1, transform.position + hit.distance * transform.up);
        }
        else
        {
            line.SetPosition(1, transform.position + maxDistance * transform.up);
        }
    }
}
