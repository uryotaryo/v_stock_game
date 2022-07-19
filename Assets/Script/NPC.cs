using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public (int _x,int _y)pos;
    [SerializeField]
    private Parts_Point emort;
    public (int _t_x,int _t_y)target;
    private float lerp_Intbal_meta = 0;
    private float meta_lerp_pos = 0;
    private int move_speed = 1000;
    private static bool _move = false;
    private Vector3 target_vector3;
    private Vector3 meta_pos;
    private GameObject _npc_obj;

    private bool posCheck(){
        if(pos._x==target._t_x &&pos._y == target._t_y)return false;
        return true;
    }
    // Start is called before the first frame update
    public Parts_Point Get_Emort(){
        return emort;
    }
    void Start()
    {
        pos._x = 10;
        pos._y = 10;
        transform.position = GameManager.Get_Stage_Manager().GetComponent<StageManager>().VectorReturn(10,10);
        Vector3 v = transform.position;
        v.y = 1;
        transform.position = v;
        _npc_obj = transform.GetChild(0).gameObject;

        meta_pos = this.transform.position;
        target_vector3 = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        StageManager.route_map[pos._x,pos._y] = 1;
    }
    private void Move(){

        //線形保管を使いながら仮ターゲットへ移動する
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

                if(StageManager.route_map[repos.Item1,repos.Item2] == 1){
                    var v3 = GameManager.Get_Stage_Manager().GetComponent<StageManager>().VectorReturn(repos.Item1,repos.Item2);
                    if(_npc_obj != null)_npc_obj.transform.LookAt(new Vector3( v3.x,_npc_obj.transform.position.y, v3.z));

                    target = pos;

                }else{
                    pos = repos;
                    target_vector3 = GameManager.Get_Stage_Manager().GetComponent<StageManager>().VectorReturn(pos._x,pos._y);
                    meta_pos = this.transform.position;
                    lerp_Intbal_meta = 0;
                    if(_npc_obj != null)_npc_obj.transform.LookAt(new Vector3( target_vector3.x,_npc_obj.transform.position.y, target_vector3.z));
                }
            }
        }
    }
    public void Set_target(int x ,int y){
        target = (x,y);
    }
    /// <summary>
    /// Y位置を固定してプレイヤーを移動させる
    /// </summary>
    /// <param name="v"></param>
    private void XZMove(Vector3 v){
        this.transform.position = new Vector3(v.x,1,v.z);
    }
    public void Look(Vector3 v){
        this.transform.LookAt(v);
    }
}
