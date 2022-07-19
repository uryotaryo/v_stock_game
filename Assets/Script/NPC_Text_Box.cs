using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Text_Box : MonoBehaviour
{
    [SerializeField]
    private Real_Time_Cont R_T_C;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mes_box_click(){
        R_T_C.To_Next_Reply();
    }
}
