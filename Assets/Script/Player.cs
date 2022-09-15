using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// プレイヤー管理用クラス
/// </summary>
public class Player : MonoBehaviour
{
    //プレイヤーのビジュアルオブジェクト格納
    [SerializeField]
    private GameObject player_obj;
    //1人称と3人称カメラの格納
    [SerializeField]
    private GameObject FpsCam;
    [SerializeField]
    private GameObject TpsCam;
    [SerializeField,Range(0.1f,2.0f)]
    private float to_NPC_Distance;
    private Vector3 _target;
    private NavMeshAgent _pobj_agent;
    private bool _stop = false;
    void Start()
    {
        _target = this.transform.position;
        _pobj_agent = player_obj.GetComponent<NavMeshAgent>();
        if(FpsCam == null || TpsCam == null)return;
        FpsCam.SetActive(false);
        TpsCam.SetActive(true);
    }
    void Update()
    {
        if(GameManager.Now_Mode == GameManager.Game_Mode.After){
            this.gameObject.SetActive(false);
        }
        //カメラを変える
        if (Input.GetKeyDown(KeyCode.V)){
            Cam_Change();
        }
        if(_stop){
            _pobj_agent.SetDestination(this.transform.position);
            player_obj.transform.localPosition = Vector3.zero;
        }
        this.transform.position = new Vector3(player_obj.transform.position.x,0,player_obj.transform.position.z);
        player_obj.transform.localPosition = new Vector3(0,0,0);
        FpsCam.transform.rotation = player_obj.transform.rotation;
        if(Input.GetKey(KeyCode.C)&&Input.GetKey(KeyCode.K)){
            GameManager.Get_GameManager().To_Result();
        }
        if(Input.GetKeyDown(KeyCode.T)){
            foreach(var v in Conversation.All_Tasks){
                Debug.Log(v.Key + ":" +v.Value.Task_Clear().ToString());
            }
        }
    }
    public void Set_Target(Vector3 t){
        _target = t;
        _pobj_agent.SetDestination(_target);
    }
    /// <summary>
    /// 一人称カメラと3人称カメラの表示非表示を反転させる
    /// </summary>
    public void Cam_Change(){
        
        FpsCam.SetActive(!FpsCam.activeSelf);
        TpsCam.SetActive(!TpsCam.activeSelf);
        Move(FpsCam.activeSelf);
        if(FpsCam.activeSelf){
            GameManager.Get_GameManager().Game_Scenes = GameManager.Scenes.Comyu;
        }else{
            GameManager.Get_GameManager().Game_Scenes = GameManager.Scenes.Default;
        }
        Debug.Log("カメラチェンジ");
    }
    public void Move(bool b){
        _pobj_agent.isStopped = b;
        _stop = b;
    }
    public void NPC_Click(GameObject Click_OBJ){
        if(Vector2.Distance(new Vector2(player_obj.transform.position.x,player_obj.transform.position.z),new Vector2(Click_OBJ.transform.position.x,Click_OBJ.transform.position.z))
        >= 1f)return;
        player_obj.transform.LookAt(Click_OBJ.transform.position);
        to_back();
        var g_npc = Click_OBJ.GetComponent<NPC>();
        g_npc.Look(this.transform.position);
        
        Real_Time_Cont RTC = FpsCam.transform.GetChild(0).GetComponent<Real_Time_Cont>();

        string Click_NPC_name = g_npc.Get_NPC_String();
        string Question_name = "";
        if(Click_NPC_name == "花火師"){
            if(g_npc.Talk_num == 0)Question_name = "挨拶";
            else Question_name = "1";
        }else if (Click_NPC_name == "町長"){
            if(GameManager.Select_Task_Name == ""){
                Question_name = "挨拶";
                Click_NPC_name = "共通1";
                if(Conversation.All_Tasks["共通1"].Task_Clear()){
                    Click_NPC_name = "共通2";
                }
            }else{
                if(Conversation.All_Tasks[GameManager.Select_Task_Name+"子"].Task_Clear()){
                    Click_NPC_name = GameManager.Select_Task_Name;
                    Question_name = "その後";
                }else{
                    Question_name = "虚無";
                }
            }
        }
        else {
            if(GameManager.Select_Task_Name == "共通1"||GameManager.Select_Task_Name == "共通2"){
                if(g_npc.Help_Flag || Conversation.All_Tasks[GameManager.Select_Task_Name+"子"].Task_Clear()){
                    Question_name = "虚無";
                }else{
                    Click_NPC_name = GameManager.Select_Task_Name + "子";
                    Question_name = "共通1";
                }
            }else{
                Question_name = "挨拶";
            }
        }
        RTC.init_Set(Click_NPC_name,g_npc.Get_Question(Question_name),g_npc);
        Cam_Change();
    }
    private void to_back(){
        Vector3 point = transform.position;
        point.y = 0.8f;
        Vector3 trget = -player_obj.transform.forward;
        Ray ray = new Ray(point,trget);
        RaycastHit hit_info = new RaycastHit();
        bool is_hit = Physics.Raycast(ray, out hit_info, to_NPC_Distance);
        if(is_hit) this.transform.position = hit_info.point;
        else this.transform.position += (-player_obj.transform.forward) * to_NPC_Distance; 
    }
}
