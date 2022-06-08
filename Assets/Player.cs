using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _x,_y;
    private int _t_x,_t_y;
    private float frame_meta = 0;
    private float frame_intaval = 1000;
    public void Set_target(int x, int y){
        _t_x = x;
        _t_y = y;
    }
    private bool posCheck(){
        if(_x==_t_x ||_y == _t_y)return false;
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = StageManeger.VectorReturn(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!posCheck())return;
        frame_meta += Time.deltaTime * 1000;
        if(frame_intaval < frame_meta){
            frame_meta = 0;
            var repos = StageManeger.BoxPos_Move(_x,_y,_t_x,_t_y);
            _x = repos.Item1;
            _y = repos.Item2;
        }
    }
}
