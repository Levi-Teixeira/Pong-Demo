using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private int _speed;
    [SerializeField]
    private GameManager _gameManager;
    
    void Start()
    {
        ApplyVelocity();
    }

    void ApplyVelocity() {
        _rb.velocity = new Vector2(0.5f, 0.5f) * _speed;
    }

    void HandleCollision(Collision2D collision) {
        if (collision.collider.CompareTag("Wall")) {
            Vector2 newVelocity = _rb.velocity;
            newVelocity.y *= -1.0f;
            _rb.velocity = newVelocity;
        }

        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy")) {
            Vector2 newVelocity = _rb.velocity;
            newVelocity.x *= -1.0f;
            _rb.velocity = newVelocity;
        }

        if (collision.collider.CompareTag("EnemyGoal")) {
            _gameManager.AddPoint("player");
        }

        if (collision.collider.CompareTag("PlayerGoal")) {
            _gameManager.AddPoint("enemy");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        HandleCollision(collision);
    }
}
