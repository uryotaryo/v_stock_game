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
    private Text[] Select_objs;

    private Question now_Q;
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
    }
    private void Set_Select_name(List<Reply> L_R){
        int count = L_R.Count-1;
        Debug.Log (count);
        //TODO:ここでselect_objsのシャッフルを入れる
        foreach(var s in Select_objs){
            if(count < 0)break;
            s.GetComponent<Text>().text = L_R[count].Select_string;
            count --;
        }
    }
    public Reply Get_Select_Reply(string s){
        foreach(var a in  now_Q.Anss){
            if(a.Select_string == s)return a;
        }
        return null;
    }
}
