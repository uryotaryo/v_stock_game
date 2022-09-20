using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    //NPCのビジュアル表示オブジェクト
    private GameObject _npc_obj;
    //NPCの役割
    [SerializeField]
    private Info.NPC_TYPE _Type;
    //子オブジェクトのナビメッシュ管理
    private NavMeshAgent _agent;
    private BoxCollider _this_collider;
    private Vector3 S_point;
    //一フレーム前の座標
    private Vector3 _lastpos;
    //スタート時の回転
    private Quaternion _base_rotate;
    //プレイヤーオブジェクト
    private GameObject _player;
    private int _talk_num = 0;
    public int Talk_num{get {return _talk_num;}}
    public bool Help_Flag;
    private float _task_time;
    private Vector3 _target;
    private NPC_Modes _now_mode;
    private enum NPC_Modes{
        Talk_Standby = 0,
        Move = 1,
        Task_Execution = 2,
        Result = 3,
        None = 4,
    }

/*
    [SerializeField]
    private Parts_Point emort;

    // Start is called before the first frame update
    public Parts_Point Get_Emort(){
        return emort;
    }
*/
    void Start()
    {
        init();
    }
    /// <summary>
    /// 初期化関数
    /// </summary>
    private void init(){
        if(_npc_obj == null) _npc_obj = transform.GetChild(0).gameObject;
        if(_player == null) _player = GameManager.Get_Player_OBJ();
        if(_agent == null)_agent = _npc_obj.GetComponent<NavMeshAgent>();
        if(_this_collider == null) _this_collider = this.GetComponent<BoxCollider>();
        else _agent.isStopped = false;
        _lastpos = transform.position;
        _base_rotate = _npc_obj.transform.rotation;
        S_point = transform.position;
        _now_mode = NPC_Modes.Talk_Standby;

        Help_Flag = false;

        //タイプごとの特殊処理
        switch(_Type){
            case Info.NPC_TYPE.OMEN:
                //お面のNPCのみ位置座標を補完する
                _npc_obj.transform.localPosition = new Vector3(0,-1.5f,0);
                break;
            case Info.NPC_TYPE.HANABI:
                //時間によって表示されないようにする
                _npc_obj.SetActive(false);
                this.transform.position = GameManager.exit_pos;
                _now_mode = NPC_Modes.None;
                _npc_obj.transform.localPosition = new Vector3(0,0,0);

                break;
            default:
                _npc_obj.transform.localPosition = new Vector3(0,0,0);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(_player == null)_player = GameManager.Get_Player_OBJ();
        
        switch(_now_mode){
            case NPC_Modes.Talk_Standby:
                Talk_Standby_Update();
                break;
            case NPC_Modes.Move:
                Move_Update();
                break;
            case NPC_Modes.Task_Execution:
                Task_Execution_Update();
                break;
            case NPC_Modes.Result:
                Result_Update();
                break;
            case NPC_Modes.None:
                //120秒以上で180秒以下なら存在する
                if(TimerCount.Get_NowTime() >= 120&&TimerCount.Get_NowTime() <= 180){
                    _npc_obj.SetActive(true);
                    Set_Target_Point(S_point);
                }   
                break;
            default:
                break;
        }
        //タイプごとの特殊処理
        switch(_Type){
            case Info.NPC_TYPE.OMEN:
                //お面のNPCのみ位置座標を補完する
                _npc_obj.transform.localPosition = new Vector3(0,-1.5f,0);
                break;
            case Info.NPC_TYPE.HANABI:
                if(Conversation.All_Tasks["花火師"].Task_Clear()&&_now_mode == NPC_Modes.Task_Execution)_now_mode = NPC_Modes.Result;
                //120秒以下なら帰る
                if(TimerCount.Get_NowTime() < 120){
                    if(Vector3.Distance(_npc_obj.transform.position,GameManager.exit_pos) <= 0.1f)_now_mode = NPC_Modes.Result;
                    else Set_Target_Point(GameManager.exit_pos);   
                }
                _npc_obj.transform.localPosition = new Vector3(0,0,0);
                break;
            default:
                _npc_obj.transform.localPosition = new Vector3(0,0,0);
                break;
        }
    }

    public void Set_Mode_Result(){
        _now_mode = NPC_Modes.Result;
    }

    private void Talk_Standby_Update(){
        transform.position = _lastpos;
        //範囲内にプレイヤーが存在したらプレイヤーのほうを向く
        if(Vector3.Distance(this.transform.position,_player.transform.position) <= 2){
            Look(_player.transform.position);
        }else{
            _npc_obj.transform.rotation =_base_rotate;
        }

        _this_collider.enabled = true;
        _npc_obj.SetActive(true);
    }
    private void Move_Update(){
        //NPCオブジェクトの座標を親オブジェクトの座標へ変更する
        transform.position = new Vector3(_npc_obj.transform.position.x,0,_npc_obj.transform.position.z);
        _lastpos = transform.position;

        if(Vector3.Distance(_target,transform.position) <= 0.1f)arrival_target();
        _this_collider.enabled = false;
        _npc_obj.SetActive(true);
    }
    private void Task_Execution_Update(){
        _this_collider.enabled = false;
        _npc_obj.SetActive(false);
        if(_task_time <= 0){
            _npc_obj.SetActive(true);
            Set_Target_Point(S_point);
        }
        _task_time -= Time.deltaTime;
    }
    private void Result_Update(){
        this.gameObject.SetActive(false);
    }
    private void arrival_target(){
        if(Vector3.Distance(transform.position,S_point) <= 0.1f){
            transform.position = S_point;
            _now_mode = NPC_Modes.Talk_Standby;
        }else{
            _now_mode = NPC_Modes.Task_Execution;
        }
    }
    public void Set_Task_Move(Vector3 t,float Time){
        _task_time = Time;
        Set_Target_Point(t);
    }
    public Question Get_Question(string s){
        _talk_num++;
        string name = "";
        name += Get_NPC_String();
        name += ":";
        name += s;
        if(s=="虚無"){
            name = "虚無";
        }
        return Conversation.Dict_Q[name];
    }
    public string Get_NPC_String(){
        string name = "";
        switch (_Type){
            case Info.NPC_TYPE.KAKIGORI:
                name = "かき氷";
                break;
            case Info.NPC_TYPE.KINGYO:
                name = "金魚";
                break;
            case Info.NPC_TYPE.OMEN:
                name = "お面";
                break;
            case Info.NPC_TYPE.SYATEKI:
                name = "射的";
                break;
            case Info.NPC_TYPE.WATAAME:
                name = "綿あめ";
                GameManager.Now_Task_Name = "綿あめ";
                break;
            case Info.NPC_TYPE.YAKITORI:
                name = "焼き鳥";
                break;
            case Info.NPC_TYPE.HANABI:
                name = "花火師";
                break;
            case Info.NPC_TYPE.SONTYO:
                name = "町長";
                break;
            default:
                name = "";
                break;
        }
        return name;
    }
    /// <summary>
    /// NPCオブジェクトを指定座標へ向けさせる
    /// </summary>
    /// <param name="v">指定座標</param>
    public void Look(Vector3 v){
        v.y = _npc_obj.transform.localPosition.y;
        _npc_obj.transform.LookAt(v);
    }
    /// <summary>
    /// 指定した座標へ動く:AIナビ
    /// </summary>
    /// <param name="v">指定座標</param>
    public void Set_Target_Point(Vector3 v)
    {
        if(_agent == null) return;
        _target = v;
        _agent.SetDestination(v);
        _now_mode = NPC_Modes.Move;
    }
}
