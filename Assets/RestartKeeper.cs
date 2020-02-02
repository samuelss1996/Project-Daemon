using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartKeeper : MonoBehaviour
{
    [HideInInspector]
    public bool dialogShown;
    [HideInInspector]
    public bool bossReached;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
