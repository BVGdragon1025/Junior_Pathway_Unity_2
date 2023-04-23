using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    Text _playerInput;
    [SerializeField]
    Text _bestScoreText;

    private void Start()
    {
        _bestScoreText.text = $"Best Score : {ScoreManager.Instance.highScorePlayer} : {ScoreManager.Instance.highScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        ScoreManager.Instance.playerName = _playerInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}
