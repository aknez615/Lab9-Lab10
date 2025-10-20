using UnityEngine;

public class TargetDirector
{
    private TargetBuilder builder;

    public void SetBuilder(TargetBuilder builder)
    {
        this.builder = builder;
    }

    public Target Construct()
    {
        builder.SetSpeed();
        builder.SetPointValue();
        builder.SetSize();
        return builder.GetTarget();
    }
}
