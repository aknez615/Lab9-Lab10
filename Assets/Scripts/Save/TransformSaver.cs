using UnityEngine;

[System.Serializable]
public class TransformData
{
    public float x;
    public float y;
    public float z;
}

public class TransformSaver : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        return new TransformData
        {
            x = transform.position.x,
            y = transform.position.y,
            z = transform.position.z
        };
    }

    public void RestoreState(object state)
    {
        var transformData = (TransformData)state;
        transform.position = new Vector3(transformData.x, transformData.y, transformData.z);
    }
}
