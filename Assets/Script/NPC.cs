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
    //オブジェクトの座標変更を停止する
    public bool Stop;
    //一フレーム前の座標
    private Vector3 _lastpos;
    //スタート時の回転
    private Quaternion _base_rotate;
    //プレイヤーオブジェクト
    private GameObject _player;
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
        else _agent.isStopped = false;
        _lastpos = transform.position;
        _base_rotate = _npc_obj.transform.rotation;
        Stop = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(_player == null)_player = GameManager.Get_Player_OBJ();
        
        //停止判定の際に前フレームの座標を代入する
        if(Stop)transform.position = _lastpos;
        else _lastpos = transform.position;

        //NPCオブジェクトの座標を親オブジェクトの座標へ変更する
        transform.position = new Vector3(_npc_obj.transform.position.x,0,_npc_obj.transform.position.z);
        
        //お面のNPCのみ位置座標を補完する
        switch(_Type){
            case Info.NPC_TYPE.OMEN:
                _npc_obj.transform.localPosition = new Vector3(0,-1.5f,0);
                break;
            default:
                _npc_obj.transform.localPosition = new Vector3(0,0,0);
                break;
        }
        
        //範囲内にプレイヤーが存在したらプレイヤーのほうを向く
        if(Vector3.Distance(this.transform.position,_player.transform.position) <= 2){
            Look(_player.transform.position);
        }else{
            _npc_obj.transform.rotation =_base_rotate;
        }
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
        _agent.SetDestination(v);
    }
}
