using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _x,_y;
    private int _t_x,_t_y;
    private Vector3 meta_pos;
    private Vector3 target_vector3;
    [SerializeField]
    private GameObject player_obj;
    [SerializeField]
    private float move_speed;
    private float lerp_Intbal_meta;
    private float meta_lerp_pos;
    public void Set_target(int x, int y){
        _t_x = x;
        _t_y = y;
    }
    public (int,int) Get_Point(){
        return (_x,_y);
    }
    [SerializeField]
    private GameObject FpsCam;
    [SerializeField]
    private GameObject TpsCam;
    /// <summary>
    /// 格子の現在座標とターゲットと座標の比較
    /// </summary>
    /// <returns>true:違うfalse:同じ
    /// </returns>
    private bool posCheck(){
        if(_x==_t_x &&_y == _t_y)return false;
        return true;
    }
    void Start()
    {
        var stage_size = GameManager.Get_Stage_Maneger().GetComponent<StageManager>().StageSize;
        _x = stage_size.x/2;
        _y = stage_size.y/2;
        Set_target(_x,_y);
        this.transform.position = GameManager.Get_Stage_Maneger().GetComponent<StageManager>().VectorReturn(_x,_y);
        
        var pos = this.transform.position;
        target_vector3 = pos;
        pos.y = 1;
        this.transform.position = pos;
        meta_pos = pos;
        if(FpsCam == null || TpsCam == null)return;
        FpsCam.SetActive(false);
        TpsCam.SetActive(true);
    }
    void Update()
    {
        if(posCheck() || this.transform.position != target_vector3){
            meta_lerp_pos += Time.deltaTime;
            if(1/move_speed <= meta_lerp_pos){
                meta_lerp_pos = 0;
                lerp_Intbal_meta += 0.05f;
                var pos = Vector3.Lerp(meta_pos,target_vector3,lerp_Intbal_meta);
                XZMove(pos);
            }
        }

        if(lerp_Intbal_meta >= 1){
            if(posCheck()){
                var repos = StageManager.BoxPos_Move(_x,_y,_t_x,_t_y);

                if(StageManager.route_map[repos.Item1,repos.Item2] == 1){
                    var v3 = GameManager.Get_Stage_Maneger().GetComponent<StageManager>().VectorReturn(repos.Item1,repos.Item2);
                    if(player_obj != null)player_obj.transform.LookAt(new Vector3( v3.x,player_obj.transform.position.y, v3.z));
                    Quaternion quaternion = player_obj.transform.localRotation;
                    FpsCam.transform.localRotation =  quaternion;
                    _t_x = _x;
                    _t_y = _y;

                    GameObject hit_obj = forward_ray();
                    if(hit_obj != null){
                        hit_obj.GetComponent<NPC>().Look(this.transform.position);
                    }
                }else{
                    _x = repos.Item1;
                    _y = repos.Item2;
                    target_vector3 = GameManager.Get_Stage_Maneger().GetComponent<StageManager>().VectorReturn(_x,_y);
                    meta_pos = this.transform.position;
                    lerp_Intbal_meta = 0;
                    if(player_obj != null)player_obj.transform.LookAt(new Vector3( target_vector3.x,player_obj.transform.position.y, target_vector3.z));
                    Quaternion quaternion = player_obj.transform.localRotation;
                    FpsCam.transform.localRotation =  quaternion;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.V)){
            Cam_Change();
        }
    }
    private void Cam_Change(){
        FpsCam.SetActive(!FpsCam.activeSelf);
        TpsCam.SetActive(!TpsCam.activeSelf);
        Debug.Log("カメラチェンジ");
    }
    private void Pos_Teleport(int x,int y){

    }
    private GameObject forward_ray(){
        Vector3 point = transform.position;
        Vector3 trget =  player_obj.transform.forward;

        Ray ray = new Ray(point,trget);
        RaycastHit hit_info = new RaycastHit();
        float max_distance = 1f;

        bool is_hit = Physics.Raycast(ray, out hit_info, max_distance); 
        
        if (is_hit) {
            if(hit_info.transform.tag == "NPC")return hit_info.transform.gameObject;
        }
        return null;
    }
    private void XZMove(Vector3 v){
        this.transform.position = new Vector3(v.x,1,v.z);
    }
}
