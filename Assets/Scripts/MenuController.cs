using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPaddle;
    [SerializeField]
    private GameObject _enemyPaddle;
    [SerializeField]
    private TMP_InputField _playerInput;
    [SerializeField]
    private TMP_InputField _enemyInput;

    public void SetPlayerPaddleColor(Button button) {
        _playerPaddle.GetComponent<SpriteRenderer>().color = button.colors.normalColor;
        SaveManager.Instance.SavePlayerColor(button.colors.normalColor);
    }

    public void SetEnemyPaddleColor(Button button) {
        _enemyPaddle.GetComponent<SpriteRenderer>().color = button.colors.normalColor;
        SaveManager.Instance.SaveEnemyColor(button.colors.normalColor);
    }

    public void SetPlayerName() {
        SaveManager.Instance.SavePlayerName(_playerInput.text);
    }

    public void SetEnemyName() {
        SaveManager.Instance.SaveEnemyName(_enemyInput.text);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }
}
