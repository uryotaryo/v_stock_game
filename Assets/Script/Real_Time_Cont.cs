using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
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

    private Question now_Q;
    private Reply _select_reply;
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
    public void Set_Q(Question q){
        now_Q = q;
        Set_Select_name(now_Q.Anss);
        NPC_Ans_box.text = "(" + now_Q.Question_Text + ")";

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
        Debug.Log(_select_reply.Ans_Type);
        switch (_select_reply.Ans_Type)
        {
            case Reply.Reply_Type.Ans_Reply:
                Debug.Log(_select_reply.Next_Question);
                Set_Q(_select_reply.Next_Question);
                break;
            case Reply.Reply_Type.Complain_fluctuation:
                GameManager.Get_Player().Cam_Change();
                GameObject.FindWithTag("TPS_canvas").GetComponent<TPS_UI_cont>().Human_level += _select_reply.Change_Complain;
                break;
            default:
                break;
        }
    }
}
