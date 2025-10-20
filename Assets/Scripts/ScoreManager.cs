using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreObserver
{
    private int score = 0;

    public void OnTargetHit(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}
