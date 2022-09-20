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
    private NPC now_npc;
    private Reply _select_reply;
    private bool shuffle = false;
    
    public void Set_Target_NPC(NPC n){
        Traget_NPC = n;
    }
    // Start is called before the first frame update
    
    void Start()
    {
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
        now_npc = null;
        _select_reply = null;
    }
    public void init_Set(string name,Question q,NPC npc_date){
        init();
        Set_Task(name);
        Set_Q(q);
        now_npc = npc_date;
        timer_set();
    }
    //タスク名がするなら代入
    public void Set_Task(string name){
        if(Conversation.All_Tasks.ContainsKey(name)){
            now_T = Conversation.All_Tasks[name];
        }
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
    //メッセージボックスがクリックされた際に処理
    public void To_Next_Reply(){
        //質問に紐づいている会話リストを取得
        string Talk_mes = now_Q.Get_Talk();
        //会話が存在しないする場合にその文をメッセージボックスへ格納する
        if(Talk_mes != ""){
            NPC_Ans_box.text = Talk_mes;
            return;
        }else{
            //会話が存在せず次の質問がある場合
            if(now_Q.Next_Question != null){
                //次の質問をセットし処理を終わる
                Set_Q(now_Q.Next_Question);
                return;
            }else{
                //質問に紐づいている選択肢が0以下の場合
                if(now_Q.Anss.Count <= 0){
                    //カメラをTPSに戻し処理を終わる
                    Exit_Question(0);
                    return;
                }
            }
            //何も選択肢が選ばれていない状態でメッセージボックスをクリックした場合処理を終わる
            if(_select_reply == null)return;
            //選択肢の処理分岐 分岐先で処理を終える
            switch (_select_reply.Ans_Type)
            {
                //選択肢に続きの質問がある
                case Reply.Reply_Type.Ans_Reply:
                    //選択肢に次の質問がない場合
                    if(_select_reply.Next_Question == null){
                    Exit_Question(0);
                    }else{
                        Set_Q(_select_reply.Next_Question);
                    }
                    return;
                //選択肢に不満度の上下：タスクの進捗度の変化情報がある
                case Reply.Reply_Type.Complain_fluctuation:
                    //不満度変化用数値
                    int Add_Human = 0;
                    int Reward_num = 0;
                    //変化情報の数値の分岐処理
                    switch (_select_reply.Change_Complain){
                        //不満度が下がりタスクが大きく進捗する
                        case -1:
                            Add_Human = -1;
                            Reward_num = 0;
                            break;
                        //不満度が変動せずタスクがほどほどに進捗する
                        case 0:
                            Reward_num = 1;
                            break;
                        //不満度が上がりタスクがほとんど進捗しない
                        case +1:
                            Add_Human = +1;
                            Reward_num = 2;
                            break;
                        //番外数値処理
                        default:
                            Exit_Question(Add_Human);
                            return;
                    }
                    GameManager.Task_Execution_Set(now_T,Reward_num,now_npc);
                    Exit_Question(Add_Human);
                    return;
                default:
                    return;
            }
        }
    }
    public void Exit_Question(int Human){
        int Add_Value = Human;
        if(Timer_Bar.value <= 0)Add_Value ++;
        GameManager._TPS_UI.Human_level += Add_Value;

        //処理が終わったのでTPS視点に戻す
        GameManager.Get_Player_OBJ().GetComponent<Player>().Cam_Change();
    }
}
