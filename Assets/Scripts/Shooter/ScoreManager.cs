using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreObserver
{
    private int score = 0;

    public int Score => score;

    public void OnTargetHit(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void SetScore(int value)
    {
        score = value;
        Debug.Log("Score restored: " + score);
    }
}
