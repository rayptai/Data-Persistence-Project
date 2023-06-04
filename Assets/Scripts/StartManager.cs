using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (StateManager.Instance.HighScores.scores.Count > 0)
        {
            Score score = StateManager.Instance.HighScores.scores[0];
            string highScoreText = "Best Score : " + score.name + " : " + score.score;
            highScore.text = highScoreText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Constants.SCENE_NAME_MAIN);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
