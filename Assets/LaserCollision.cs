using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    // Editor
    public float maxDistance;
    public GameObject particles;

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
        Vector3 hitPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        line.SetPosition(0, transform.position);

        if (hit.collider != null) {
            hitPosition = transform.position + hit.distance * transform.up;
        }
        else
        {
            hitPosition = transform.position + maxDistance * transform.up;
        }

        line.SetPosition(1, hitPosition);
        particles.transform.position = hitPosition;
    }
}
