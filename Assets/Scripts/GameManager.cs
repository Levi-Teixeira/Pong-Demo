using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPaddle;
    [SerializeField]
    private GameObject _enemyPaddle;
    [SerializeField]
    private GameObject _ball;
    public int _playerPoints;
    public int _enemyPoints;
    [SerializeField]
    private TextMeshProUGUI _playerPointsText;
    [SerializeField]
    private TextMeshProUGUI _enemyPointsText;

    void Start()
    {
        ResetPaddlesPositon();
        ResetBallPosition();
    }

    private void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            ResetGame();
        }
    }

    private void ResetPaddlesPositon() {
        _playerPaddle.transform.position = new Vector3(-8.7f, 0, 0);
        _enemyPaddle.transform.position = new Vector3(8.7f, 0, 0);
    }

    private void ResetBallPosition() {
        _ball.transform.position = Vector3.zero;
    }

    void ResetGame() {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene(0);
    }

    void GameOver() {
        SceneManager.LoadScene(2);
    }

    void CheckForHiscore(int currentPoints) {
        if(currentPoints > SaveManager.Instance.playerHiScore) {
            SaveManager.Instance.playerHiScore = currentPoints;
        }
    }

    public void AddPoint(string player) {
        if (player == "player") {
            _playerPoints++;
            _playerPointsText.text = _playerPoints.ToString();
            CheckForHiscore(_playerPoints);
        } else if (player == "enemy") {
            _enemyPoints++;
            _enemyPointsText.text = _enemyPoints.ToString();
        }

        if(_playerPoints == 5 || _enemyPoints == 5) {
            GameOver();
        }

        ResetBallPosition();
    }
}
