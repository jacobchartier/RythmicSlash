using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int mouvementSpeed = 3;
    [SerializeField] private int maxJumps = 2, currentJumps = 0;
    [SerializeField] private float jumpForce = 12.5f;

    [SerializeField] private bool isPlayerOnGround = false;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        isPlayerOnGround = IsPlayerOnGround();
    }

    public void Move(int direction)
    {
        FlipSprite(direction);
        player.velocity = new Vector2((mouvementSpeed * direction), player.velocity.y);

        MovingParticle();
    }

    public void Jump()
    {
        player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void FlipSprite(int direction)
    {
        if (direction == 1)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direction == -1)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private bool IsPlayerOnGround()
    {
        if (player.velocity.y < -0.05 || player.velocity.y > 0.05)
            return true;
        else
            return false;
    }

    private void MovingParticle()
    {
        particles.Play();
    }
}
