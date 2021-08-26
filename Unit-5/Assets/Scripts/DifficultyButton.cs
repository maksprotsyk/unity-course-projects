using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _difficultyButton;

    private GameManager _gameManager;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        _difficultyButton = GetComponent<Button>();
        _difficultyButton.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty()
    {
        Debug.Log(gameObject.name);
        _gameManager.StartGame(difficulty);
        

    }
}
