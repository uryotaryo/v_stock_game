using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public (int _x,int _y)pos;
    [SerializeField]
    private Parts_Point emort;
    /*
    public (int _t_x,int _t_y)target;
    private float lerp_Intbal_meta = 0;
    private float meta_lerp_pos = 0;
    private int move_speed = 1000;
    private static bool _move = false;
    private Vector3 target_vector3;
    private Vector3 meta_pos;
    */
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
    }


    // Update is called once per frame
    void Update()
    {
        StageManager.route_map[pos._x,pos._y] = 1;
    }
    public void Look(Vector3 v){
        this.transform.LookAt(v);
    }
}
