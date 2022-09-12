using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Real_Time_Cont : MonoBehaviour
{
    [SerializeField]
    private float Max_Time;
    [SerializeField]
    private Slider Timer_Bar;
    [SerializeField]
    private Text NPC_Ans_box;
    [SerializeField]
    private GameObject[] Select_objs;

    private NPC Traget_NPC;
    private Question now_Q;
    private Task now_T;
    private Reply _select_reply;
    private bool shuffle = false;
    
    public void Set_Target_NPC(NPC n){
        Traget_NPC = n;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        timer_set();
    }
    private void timer_set(){
        Timer_Bar.maxValue = Max_Time;
        Timer_Bar.value = Max_Time;

    }
    // Update is called once per frame
    void Update()
    {
        Timer_Bar.value -= Time.deltaTime;
    }
    private void init(){
        now_Q = null;
        now_T = null;
    }
    public void init_Set(string name,Question q){
        init();
        Set_Task(name);
        Set_Q(q);
    }
    public void Set_Task(string name){
        now_T = Conversation.All_Tasks[name];
    }
    public void Set_Q(Question q){
        //Traget_NPC.Get_Emort().Set_Emort(Parts_Point.emort.none);
        now_Q = q;
        now_Q.init();
        Set_Select_name(now_Q.Anss);
        if(now_Q.Anss.Count == 1){
            Click_Reply(now_Q.Anss[0]);
        }else if (now_Q.Anss.Count > 4){
            //now_Q.Anss = now_Q.Anss.OrderBy(a => Guid.NewGuid()).ToList();
        }
        else{
            NPC_Ans_box.text = "(" + now_Q.Question_Text + ")";
        }

    }
    private void Ans_btn_Active(bool Set){
        foreach(var s in Select_objs){
            s.gameObject.SetActive(Set);
        }
    }
    private void Set_Select_name(List<Reply> L_R){
        int count = L_R.Count-1;
        Ans_btn_Active(true);
        //TODO:ここでselect_objsのシャッフルを入れる
        foreach(var s in Select_objs){
            if(count < 0){
                s.GetComponent<Ans_Down>().Set_Replay(new Reply("ダミー","ダミー選択肢です",0));
                s.SetActive(false);
            }else {
                s.GetComponent<Ans_Down>().Set_Replay(L_R[count]);
            }
            count --;
        }
    }
    public void Click_Reply(Reply r){
        _select_reply = r;
        Ans_btn_Active(false);
        NPC_Ans_box.text = r.NPC_Ans;
    }
    public void To_Next_Reply(){
        string Talk_mes = now_Q.Get_Talk();
        if(Talk_mes != ""){
            NPC_Ans_box.text = Talk_mes;
        }else{
            if(now_Q.Next_Question != null){
                Set_Q(now_Q.Next_Question);
                return;
            }
            else{
                if(now_Q.Anss.Count <= 0){
                    GameManager.Get_Player_OBJ().GetComponent<Player>().Cam_Change();
                }
            }
            switch (_select_reply.Ans_Type)
            {
                case Reply.Reply_Type.Ans_Reply:
                    if(_select_reply.Next_Question == null){
                        GameManager.Get_Player_OBJ().GetComponent<Player>().Cam_Change();
                    }else{
                        Set_Q(_select_reply.Next_Question);
                    }
                    break;
                case Reply.Reply_Type.Complain_fluctuation:
                    int Add_Human = 0;

                    switch (_select_reply.Change_Complain){
                        case -1:
                            Add_Human = -1;
                            now_T.Add_ReWard(0);
                            break;
                        case 0:
                            now_T.Add_ReWard(1);
                            break;
                        case +1:
                            Add_Human = +1;
                            now_T.Add_ReWard(2);
                            break;
                        default:
                            break;
                    }
                    Debug.Log(now_T.Content_Num);
                    GameManager._TPS_UI.Human_level += Add_Human;
                    GameManager.Get_Player_OBJ().GetComponent<Player>().Cam_Change();
                    
                    break;
                default:
                    break;
            }
        }
    }
}
