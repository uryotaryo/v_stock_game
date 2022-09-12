using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ans_Down : MonoBehaviour
{
    [SerializeField]
    private Real_Time_Cont R_T_C;
    [SerializeField]
    private Text text;
    public Reply SetReply;
    public void Set_Replay(Reply r){
        SetReply = r;
        Set_TextBox(SetReply.Select_string);
    }
    public void Point_check(){
        R_T_C.Click_Reply(SetReply);
    }
    public void Set_TextBox(string s){
        text.text = s;
    }
}
