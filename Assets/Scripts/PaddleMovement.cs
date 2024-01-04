using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private TMP_Text _uiName;

    private void Awake() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = SaveManager.Instance.playerColor;
        _uiName.text = SaveManager.Instance.playerName;
    }
    void Update()
    {
        Move();
    }

    void Move() {
        float direction = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + (_moveSpeed * direction * Time.deltaTime * Vector3.up);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);
        transform.position = newPosition;
    }
}
