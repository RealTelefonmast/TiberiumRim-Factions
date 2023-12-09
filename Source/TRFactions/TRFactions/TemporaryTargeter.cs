using UnityEngine;

namespace TR;

public class TemporaryTargeter : TRBuildingPrototype
{
    public Material mat;
    public float size;
    public override void Draw()
    {
        TRUtils.DrawTargeter(Position, mat, size);
        base.Draw();
    }
}