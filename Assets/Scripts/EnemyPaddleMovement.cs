using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyPaddleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private TMP_Text _uiName;

    private void Awake() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = SaveManager.Instance.enemyColor;
        _uiName.text = SaveManager.Instance.enemyName;
    }

    void Update()
    {
        Move();
    }

    void Move() {
        float targetY = Mathf.Clamp(_ball.transform.position.y, -4f, 4f);
        Vector2 targetPosition = new Vector2(transform.position.x, targetY);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
    }
}
