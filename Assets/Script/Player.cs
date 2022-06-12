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
        this.transform.position = GameManager.Get_Stage_Maneger().GetComponent<StageManeger>().VectorReturn(0,0);
        var pos = this.transform.position;
        target_vector3 = pos;
        pos.y = 1;
        this.transform.position = pos;
        meta_pos = pos;
    }
    void Update()
    {
        if(this.transform.position == target_vector3)
        {
            var repos = StageManeger.BoxPos_Move(_x,_y,_t_x,_t_y);
            _x = repos.Item1;
            _y = repos.Item2;
            target_vector3 = GameManager.Get_Stage_Maneger().GetComponent<StageManeger>().VectorReturn(_x,_y);
            meta_pos = this.transform.position;
            lerp_Intbal_meta = 0;
        }
        if(posCheck()){
            meta_lerp_pos += Time.deltaTime;
            if(1/move_speed <= meta_lerp_pos){
                meta_lerp_pos = 0;
                lerp_Intbal_meta += 0.01f;
                this.transform.position = Vector3.Lerp(meta_pos,target_vector3,lerp_Intbal_meta);
            }
        }
        if(lerp_Intbal_meta >= 1){
            if(!posCheck())return;
            var repos = StageManeger.BoxPos_Move(_x,_y,_t_x,_t_y);
            _x = repos.Item1;
            _y = repos.Item2;
            target_vector3 = GameManager.Get_Stage_Maneger().GetComponent<StageManeger>().VectorReturn(_x,_y);
            meta_pos = this.transform.position;
            lerp_Intbal_meta = 0;
            if(player_obj != null)player_obj.transform.LookAt(new Vector3( target_vector3.x,player_obj.transform.position.y, target_vector3.z));
        }
        var pos = this.transform.position;
        pos.y = 1;
        this.transform.position = pos;
    }
}
