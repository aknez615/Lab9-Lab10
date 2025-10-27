using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{
    public GameObject targetPrefab;
    public int poolSize = 10;

    private List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>();

        for (int i =0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(targetPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetTarget()
    {
        foreach (GameObject target in pool)
        {
            if (!target.activeInHierarchy)
            {
                target.SetActive(true);
                return target;
            }
        }
        return null;
    }

    public void ReturnTarget(GameObject target)
    {
        target.SetActive(false);
    }
}
