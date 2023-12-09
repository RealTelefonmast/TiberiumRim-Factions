﻿using RimWorld;
using Verse;

namespace TR;

public class Designator_NodNukeTargeter: Designator_Target
{
    public Designator_NodNukeTargeter()
    {
        this.defaultLabel = "Nod Nuke";
        this.defaultDesc = "Cleanse.";
        this.icon = TRContent.NodNukeIcon;
        this.useMouseIcon = false;
        this.soundSucceeded = SoundDefOf.Click;


        targeterMat = TRContent.NodNukeTargeter;
        size = 16;
    }

    public override void Selected()
    {
        base.Selected();
        GameComponent_EVA.EVAComp().ReceiveSignal(EVASignal.SelectTarget, null);
    }

    public override AcceptanceReport CanDesignateCell(IntVec3 loc)
    {
        return true;
    }


    [TweakValue("IonBubbleScale", 1f, 20f)]
    public static float IonScale = 20;

    [TweakValue("IonBubbleRotRate", 0f, 5f)]
    public static float RotRate = 1.5f;

    public override void DesignateSingleCell(IntVec3 loc)
    {
        //TODO: Add some funny nuke stuff
        /*ActionComposition composition = new ActionComposition("Designator Bubble Test");
        Mote mote = (Mote)ThingMaker.MakeThing(ThingDef.Named("IonBubble"), null);
        Mote distortion = (Mote)ThingMaker.MakeThing(ThingDef.Named("IonDistortionBubble"));
        composition.AddPart(delegate (ActionPart part)
        {
            mote.exactPosition = loc.ToVector3Shifted();
            mote.Scale = 20;
            mote.rotationRate = 1.2f;
            mote.instanceColor = new ColorInt(70, 90, 175).ToColor;
            GenSpawn.Spawn(mote, loc, Map, WipeMode.Vanish);
            distortion.exactPosition = loc.ToVector3Shifted();
            float scaleVal = 20 * (part.CurrentTick / (float)part.Duration);
            distortion.Scale = scaleVal;
            distortion.rotationRate = RotRate;
            GenSpawn.Spawn(distortion, loc, Map);
        },0);
        composition.AddPart(delegate (ActionPart part)
        {
            float scaleVal = 20 * (part.CurrentTick / (float)part.Duration);
            distortion.Scale = scaleVal;
            mote.Scale = scaleVal * 8;
        }, 0, 20);
        composition.Init();*/
    }
}