using UnityEngine;

public class Target
{
    public float speed;
    public int pointValue;
    public Vector2 size;
}

public abstract class TargetBuilder
{
    protected Target target = new Target();

    public Target GetTarget() => target;

    public abstract void SetSpeed();
    public abstract void SetPointValue();
    public abstract void SetSize();
}

public class FastTargetBuilder : TargetBuilder
{
    public override void SetSpeed()
    {
        target.speed = 5f;
    }

    public override void SetPointValue()
    {
        target.pointValue = 10;
    }

    public override void SetSize()
    {
        target.size = new Vector2(1, 1);
    }
}
