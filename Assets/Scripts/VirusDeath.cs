using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusDeath : MonoBehaviour
{
    // Editor
    public ParticleSystem deathParticles;

    // Refs
    private MeshRenderer sprite;

    // State
    private bool alive = true;

    private void Awake()
    {
        sprite = GetComponent<MeshRenderer>();
    }

    public void Die()
    {
        if(alive)
        {
            sprite.enabled = false;
            deathParticles.Play();

            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

            alive = false;
        }
    }
}
