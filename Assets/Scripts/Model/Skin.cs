using UnityEngine;
using UnityEngine.UI;

public enum SkinType
{
    //NotFunctional
        Brain,
        Golden,

    //Functional
        Brush,
        Jetpack,
        Cyber,
        Phone,

    //NotReleased
        //Astronaut,
        //GlassesMustache,
        //SheriffStar,
        //Student,
        //Medal,
        //Stone,
        //Pogo,
        //Pharaoh,
        //Broker,
        //KatanaNinja,
        //PriceTagsStickerPromo,
        //Noob,
        //Sabziro,
}


public enum SkinProcChance // После конкурса сделать нормально - вынести в SO
{
    noProcChance,

    ten,
        SheriffStar,

    fifteen,
        Brush,
        Medal,

    twentyfive,
        Noob,
}

public class Skin
{
    public SkinType skinType;

    public bool IsProc()
    {
        int chance;
        SkinProcChance procChance = SkinProcChance.noProcChance;
        foreach (SkinType sk1 in SkinType.GetValues(typeof(SkinType)))
            foreach (SkinProcChance sk2 in SkinProcChance.GetValues(typeof(SkinProcChance)))
                if (sk1.ToString() == sk2.ToString())
                {
                    procChance = sk2;
                    break;
                }

        chance = procChance > SkinProcChance.twentyfive ? 25 :
                    procChance > SkinProcChance.fifteen ? 15 :
                    procChance > SkinProcChance.ten ? 10 
                    : -1;

        if (-1 == chance) Debug.LogError("Incorrect proc skin!");

        return Random.Range(0, 101) < chance;
    }
}