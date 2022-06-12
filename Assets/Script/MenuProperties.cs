using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuProperties : MonoBehaviour
{
    [SerializeField]
    private GameObject Show_Menu_Obj;
    private GameObject Parent_Obj;
    private Vector3 _original_Position = Vector3.zero;
    private bool _mouse_down = false;
    // Start is called before the first frame update
    void Start()
    {
        _original_Position = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(_mouse_down){
            _mouse_down = false;
            return;
        }else{
            this.transform.localPosition = _original_Position;
        }
    }
public void Set_Parent_Obj(GameObject g){

}
    public bool Mouse_Down_Move(Vector3 pos){
        _mouse_down = true;
        /*
        var pos = this.transform.localPosition;
        Debug.Log(this.transform.parent.position);
        pos.x = v2.x + this.transform.parent.position.x;
        pos.z = 0;
        pos.z = v2.y + this.transform.parent.position.y;
        this.transform.localPosition = pos;
        */
        this.transform.position = pos;
        return false;
    }
    private void Select_Menu(){

    }
}
