using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ゲーム全体を管理するクラス
/// 各機能の管理オブジェクトを返す
/// </summary>
public class GameManager : MonoBehaviour
{
    //自身のクラスを格納する
    private static GameManager _my_Manager;
    //プレイヤーのオブジェクトを格納する
    private static GameObject _player_Obj;
    [SerializeField]
    private GameObject Exit_Pos;
    public static Vector3 exit_pos;
    public static TPS_UI_cont _TPS_UI;
    public static string Now_Task_Name;
    public static Game_Mode Now_Mode = Game_Mode.Before;
    public enum  Game_Mode
    {
        Before,
        After,
    }

    [SerializeField]
    private GameObject _Result;

    [SerializeField]
    private AudioClip[] BGMs;
    private AudioSource AS; 
    private Scenes _game_scenes = Scenes.Default;
    public Scenes Game_Scenes{
        get{
            return _game_scenes;
            }
        set{
            Audio_Change(value);
            _game_scenes = value;
        }
    }
    public enum Scenes{
        Default,
        Comyu,
        Result,
        Stop,

    }
    public static string Select_Task_Name = "";

    public static void Help_ReSet(){
        foreach(var g in GameObject.FindGameObjectsWithTag("NPC")){
            g.GetComponent<NPC>().Help_Flag = false;
        }
    }
    
    public static void Task_Execution_Set(Task t,int r_w,NPC npc_g){
        if(t == null)return;
        Debug.Log(t.Name);
        Debug.Log(r_w);
        if(t.Name == "共通1"||t.Name == "共通2"){
            Debug.Log(Select_Task_Name);
            if(Select_Task_Name == ""){
                Select_Task_Name = t.Name; 
                return;
            }
            if(!Conversation.All_Tasks[Select_Task_Name+"子"].Task_Clear())return;
            t.Add_ReWard(r_w);
            foreach(var ng in GameObject.FindGameObjectsWithTag("NPC")){
                Debug.Log(ng.GetComponent<NPC>().Get_NPC_String()+"::"+ng.GetComponent<NPC>().Help_Flag.ToString());
                if(ng.GetComponent<NPC>().Help_Flag)ng.GetComponent<NPC>().Set_Target_Point(exit_pos);
            }
            npc_g.Set_Target_Point(exit_pos);
            Select_Task_Name = "";
            Help_ReSet();
            return;
        }else if(t.Name == "共通1サブ"||t.Name == "共通2サブ"){
            npc_g.gameObject.GetComponent<NPC>().Help_Flag = true;
            t.Add_ReWard(r_w);
        }else{
            npc_g.Set_Target_Point(exit_pos);
            t.Add_ReWard(r_w);
        }
    }
    
    
    
    /// <summary>
    /// 格納した自身のクラスを返す
    /// </summary>
    /// <returns>GameManager</returns>
    public static GameManager Get_GameManager(){
        return _my_Manager;
    }
    /// <summary>
    /// 格納したプレイヤーオブジェクトを返す
    /// </summary>
    /// <returns>Player(GameObject)</returns>
    public static GameObject Get_Player_OBJ(){
        return _player_Obj;
    }


    /// <summary>
    /// FPS制限
    /// 自身やほかの管理オブジェクトの格納
    /// </summary>
    private void Awake(){
        //1秒60フレームに固定する
        Application.targetFrameRate = 60;
        _my_Manager = this.GetComponent<GameManager>();
        _player_Obj = GameObject.FindWithTag("Player");
        _TPS_UI = GameObject.FindWithTag("TPS_canvas").GetComponent<TPS_UI_cont>();
        AS = this.GetComponent<AudioSource>();
        exit_pos = Exit_Pos.transform.position;
    }
    
    public void To_Result(){
        Now_Mode = Game_Mode.After;
        _Result.SetActive(true);
    }
    void Start()
    {
        Game_Scenes = Scenes.Default;
        Conversation.Q_And_A_Load();
    }
    

    private void Audio_Change(Scenes S){
        switch(S){
            case Scenes.Default:
                AS.clip = BGMs[0];
                AS.Play();
                break;
            case Scenes.Comyu:
                AS.clip = BGMs[Random.Range(1,3)];
                AS.Play();
                break;
            case Scenes.Result:
                AS.clip = BGMs[3];
                AS.Play();
                break;
            case Scenes.Stop:
                AS.Stop();
                break;
            default:
                AS.Stop();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(AS == null)AS = this.GetComponent<AudioSource>();
    }
}
