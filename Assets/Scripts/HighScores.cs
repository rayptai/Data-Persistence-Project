using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Score
{
    public Score(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public string name;
    public int score;
}

/**
 * Sorted list of high scores.
 */
[System.Serializable]
public class HighScores
{
    public List<Score> scores = new List<Score>();

    public void AddScore(Score newScore)
    {
        scores.Add(newScore);
        scores.Sort(delegate(Score x, Score y)
        {
            if (x.score != y.score)
            {
                return y.score.CompareTo(x.score);
            } 
            else
            {
                return x.name.CompareTo(y.name);
            }
        });        
    }

}
