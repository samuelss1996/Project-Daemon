using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawn : MonoBehaviour
{
    void Awake()
    {
        if(FindObjectOfType<RestartKeeper>().bossReached)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }
    }
}
