using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuProperties : MonoBehaviour
{
    [SerializeField]
    private GameObject Show_Menu_Obj;    
    private GameObject Parent_Obj;
    [SerializeField]
    private Type thistype;
    public enum Type{
        akt = 0,
        speek = 1,
    }
    public Type Get_Type(){
        return thistype;
    }
    // Start is called before the first frame update
    void Start()
    {
        Parent_Obj = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool Select_Check(){
        if(Parent_Obj == null)return false;
        var t_pos = this.GetComponent<RectTransform>().localPosition;
        var select_size = Parent_Obj.GetComponent<RectTransform>().sizeDelta;
        if(Vector2.Distance(new Vector2(t_pos.x,t_pos.y),Vector2.zero) <= select_size.x /3)return true;
        else return false;
    }
}
