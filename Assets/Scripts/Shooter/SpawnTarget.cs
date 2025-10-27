using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class SpawnTarget : MonoBehaviour
{
    public TargetPool targetPool;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 2f);
    }

    public void Spawn()
    {
        GameObject targetGO = targetPool.GetTarget();

        TargetBuilder builder = new FastTargetBuilder();
        TargetDirector director = new TargetDirector();
        director.SetBuilder(builder);
        Target builtTarget = director.Construct();

        TargetClass targetComponent = targetGO.GetComponent<TargetClass>();

        targetComponent.speed = builtTarget.speed;
        targetComponent.pointValue = builtTarget.pointValue;
        targetComponent.size = builtTarget.size;

        targetGO.transform.localScale = targetComponent.size;
        targetGO.transform.position = GetRandomSpawnPosition();
    }

    Vector2 GetRandomSpawnPosition()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        return new Vector2(x, y);
    }
}
