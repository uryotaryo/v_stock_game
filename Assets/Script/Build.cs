using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    (int x,int y) pos = (15,20);
    (int x,int y)[] Inviolable_points = {
        (0,0),
    };
    private void Start(){
        this.transform.position = GameManager.Get_Stage_Manager().GetComponent<StageManager>().VectorReturn(pos.x,pos.y);
    }
    private void Update(){
        Set_stage_route_map();

    }
    private void Set_stage_route_map(){
        StageManager.route_map[pos.x+Inviolable_points[0].x,pos.y+Inviolable_points[0].y] = 1;
    }
}
