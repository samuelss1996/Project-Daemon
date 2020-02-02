using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Editor
    public ParticleSystem deathParticles;

    // Refs
    private SpriteRenderer sprite;

    // State
    private bool alive = true;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        if(alive)
        {
            DieVisually();
            FindObjectOfType<LevelTransitioner>().RestartLevel();
        }
    }

    public void DieVisually()
    {
        if(alive)
        {
            sprite.enabled = false;
            deathParticles.Play();

            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<MovementBehaviour>().enabled = false;
            GetComponent<JumpBehaviour>().enabled = false;

            alive = false;
        }
    }
}
