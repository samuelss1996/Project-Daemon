using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Editor
    public ParticleSystem deathParticles;

    // Refs
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        sprite.enabled = false;
        deathParticles.Play();

        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}
