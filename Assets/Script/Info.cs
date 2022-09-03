using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info
{
    public static string[] Characters = new string[]
    {
        "冷静",
        "わんぱく",
    };
    public static string[]Building_Name_Assist = new string[]{"木"};
    public enum Building_Name
    {
        tree,
    }
    
    public static string Character_Decision(NPC_Parameters NP){
        //TODO:パラメータによってNPCの性格を変える
        return "冷静";
    }
    public enum NPC_TYPE{
        YAKITORI,
        KAKIGORI,
        KINGYO,
        SYATEKI,
        OMEN,
        WATAAME,
        HANABI,
        INFURENSER,
        SONTYO,
        OKYAKU,
    }
}
