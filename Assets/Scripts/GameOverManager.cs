using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _hiScoreText;
    void Start()
    {
        _hiScoreText.text = "Player Hiscore: " + SaveManager.Instance.playerHiScore.ToString();
    }

    public void GotoMenu() {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene(0);
    }
}
