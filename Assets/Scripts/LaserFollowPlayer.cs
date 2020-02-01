using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollowPlayer : MonoBehaviour
{
    // Editor
    public float speed;

    // Refs
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, speed * Time.deltaTime * Quaternion.Angle(transform.rotation, targetRot));
    }
}
