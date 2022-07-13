using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prot_NPC_cont : MonoBehaviour
{
    public (int _x,int _y)pos;
    public (int _t_x,int _t_y)target;
    private float lerp_Intbal_meta = 0;
    private float meta_lerp_pos = 0;
    private int move_speed = 1000;
    private static bool _move = false;
    private Vector3 target_vector3;
    private Vector3 meta_pos;
    // Start is called before the first frame update
    void Start()
    {
        meta_pos = this.transform.position;
    }
    private bool posCheck(){
        if(pos._x==target._t_x &&pos._y == target._t_y)return false;
        return true;
    }
    public void Set_target(){
        var repos = StageManager.BoxPos_Move(pos._x,pos._y,target._t_x,target._t_y);
        pos._x = repos.Item1;
        pos._y = repos.Item2;
        target_vector3 = GameManager.Get_Stage_Maneger().GetComponent<StageManager>().VectorReturn(pos._x,pos._y);
        meta_pos = this.transform.position;
        lerp_Intbal_meta = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!_move)return;
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
                var repos = StageManager.BoxPos_Move(pos._x,pos._y,target._t_x,target._t_y);
                pos._x = repos.Item1;
                pos._y = repos.Item2;
                target_vector3 = GameManager.Get_Stage_Manager().GetComponent<StageManager>().VectorReturn(pos._x,pos._y);
                meta_pos = this.transform.position;
                lerp_Intbal_meta = 0;
            }
        }
    }
    public static void Move_Start(){
        _move = true;
    }
    public static void Move_Stop(){
        _move = false;
    }
    private void XZMove(Vector3 v){
        this.transform.position = new Vector3(v.x,1,v.z);
    }
}
