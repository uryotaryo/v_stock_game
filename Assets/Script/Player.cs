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

    private Vector3 _target;
    private NavMeshAgent _this_agent;
    void Start()
    {
        _target = this.transform.position;
        _this_agent = this.GetComponent<NavMeshAgent>();
        if(FpsCam == null || TpsCam == null)return;
        FpsCam.SetActive(false);
        TpsCam.SetActive(true);
    }
    void Update()
    {
        //カメラを変える
        if (Input.GetKeyDown(KeyCode.V)){
            Cam_Change();
        }
        transform.parent.transform.position = new Vector3(transform.position.x,0,transform.position.z);
        transform.localPosition = new Vector3(0,0,0);
    }
    public void Set_Target(Vector3 t){
        _target = t;
        _this_agent.SetDestination(_target);
    }
    /// <summary>
    /// 一人称カメラと3人称カメラの表示非表示を反転させる
    /// </summary>
    public void Cam_Change(){
        
        FpsCam.SetActive(!FpsCam.activeSelf);
        TpsCam.SetActive(!TpsCam.activeSelf);
        Debug.Log("カメラチェンジ");
    }
    public GameObject Forward_NPC(){
        var obj = forward_ray();
        if (obj == null) return null;
        if(obj.transform.tag == "NPC")return obj.transform.gameObject;
        return null;
    }
    private GameObject forward_ray(){
        Vector3 point = transform.position;
        Vector3 trget =  player_obj.transform.forward;

        Ray ray = new Ray(point,trget);
        RaycastHit hit_info = new RaycastHit();
        float max_distance = 1f;

        bool is_hit = Physics.Raycast(ray, out hit_info, max_distance); 
        if(is_hit)return hit_info.transform.gameObject;
        else return null;
    }
}
