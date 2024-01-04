using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Color playerColor = Color.white;
    public Color enemyColor = Color.white;
    public string playerName = "";
    public string enemyName = "";
    public int playerHiScore = 0;
    private static SaveManager _instance;

    public static SaveManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<SaveManager>();

                if (_instance == null ) {
                    GameObject singletonObject = new GameObject(typeof(SaveManager).Name);
                    _instance = singletonObject.AddComponent<SaveManager>();
                }
            }
            return _instance;
        }
    }

    public void SavePlayerName(string name) {
        playerName = name;
    }

    public void SaveEnemyName(string name) { 
        enemyName = name;
    }

    public void SavePlayerColor(Color color) {
        playerColor = color;
    }

    public void SaveEnemyColor(Color color) {  
        enemyColor = color;
    }

    public void ResetSave() {
        playerColor = Color.white;
        enemyColor = Color.white;
        playerName = "";
        enemyName = "";
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
