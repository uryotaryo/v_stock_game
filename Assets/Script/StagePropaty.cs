using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePropaty : MonoBehaviour
{
    public int x;
    public int y;

    private GameObject _stageMane;
    public void Set_Stage_Maneger(GameObject SM){
        _stageMane = SM;
    }
    public void Set_Box_Pos(int p_x,int p_y){
        x = p_x;
        y = p_y;
    }
    public void Hit(){
        if(_stageMane == null) return;
        _stageMane.GetComponent<StageManager>().DoTarget((x,y));
    }
    // Start is called before the first frame update
    void Start()
    {
        Set_Stage_Maneger(this.transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
