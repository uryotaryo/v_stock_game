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
    private Reply SetReply;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set_Replay(Reply r){
        SetReply = r;
        text.text = SetReply.Select_string;
    }
    public void Point_check(){
        Debug.Log("選択された");//w
        R_T_C.Click_Reply(SetReply);
    }
}
