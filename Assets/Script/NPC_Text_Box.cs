using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Text_Box : MonoBehaviour
{
    [SerializeField]
    private Real_Time_Cont R_T_C;
    public void mes_box_click(){
        R_T_C.To_Next_Reply();
    }
}
