using System.Collections.Generic;
using UnityEngine;

public class TargetClass : MonoBehaviour
{
    public float speed;
    public int pointValue = 10;
    public Vector2 size;

    private List<IScoreObserver> observers = new List<IScoreObserver>();

    public void RegisterObserver(IScoreObserver observer)
    {
        observers.Add(observer);
    }

    public void OnHit()
    {
        foreach (var observer in observers)
        {
            observer.OnTargetHit(this.pointValue);
        }
        gameObject.SetActive(false);
    }
}
