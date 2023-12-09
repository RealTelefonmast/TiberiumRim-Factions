using System.Linq;
using RimWorld;
using TR.Satellites;
using Verse;

namespace TR;

public class Designator_IonCannonTargeter : Designator_Target
{
    public Designator_IonCannonTargeter()
    {
        this.defaultLabel = "Ion Cannon";
        this.defaultDesc = "Obliterate it all.";
        this.icon = TRContent.IonCannonIcon;
        this.useMouseIcon = false;
        this.soundSucceeded = SoundDefOf.Click;


        targeterMat = TRContent.IonCannonTargeter;
        size = IonCannon_Strike.radius * 2;
    }

    public override void Selected()
    {
        base.Selected();
        GameComponent_EVA.EVAComp().ReceiveSignal(EVASignal.SelectTarget, null);
    }

    public override AcceptanceReport CanDesignateCell(IntVec3 loc)
    {
        return base.CanDesignateCell(loc).Accepted;
    }

    public override void DesignateSingleCell(IntVec3 c)
    {
        //base.DesignateSingleCell(c);
        var sat = NearestSatellite(Map);
        if (sat != null)
        {
            sat.SetAttackDest(Map, c);
            sat.SetDestination(Map.Tile);
            GameComponent_EVA.EVAComp().ReceiveSignal(EVASignal.IonCannonActivated, null);
        }
        Find.DesignatorManager.Deselect();
    }

    private AttackSatellite_Ion NearestSatellite(Map fromMap = null, int fromTile = -1)
    {
        AttackSatellite_Ion sat = null;
        if (fromMap != null)
        {
            var map = Find.CurrentMap;
            fromTile = map.Tile;
        }

        var sats = TRUtils.Tiberium().GetWorldInfo<SatelliteInfo>().AttackSatelliteNetwork.ASatsIon;
        sat = fromTile >= 0 ? sats.MinBy(s => Find.WorldGrid.ApproxDistanceInTiles(fromTile, s.Tile)) : sats.FirstOrDefault();
        return sat;
    }

    public override bool Visible
    {
        get { return true; } 
    }
}