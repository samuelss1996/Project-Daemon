using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraZone : MonoBehaviour
{
    // Editor
    public float moveTime;
    public Animator doorAnimator;

    // State
    private Vector3 initialPos;
    private float currentTime;
    private bool move;

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            Camera.main.gameObject.transform.position = Vector3.Slerp(initialPos, transform.position, currentTime / moveTime);

            if(currentTime / moveTime >= 1)
            { 
                gameObject.SetActive(false);
            }

            currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Camera.main.gameObject.GetComponent<DeadzoneCamera>().enabled = false;
            initialPos = Camera.main.gameObject.transform.position;
            move = true;
            doorAnimator.SetTrigger("Close");
            FindObjectOfType<RestartKeeper>().bossReached = true;
        }
    }
}
