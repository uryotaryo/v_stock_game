using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //private bool random_move = true;
    private GameObject _npc_obj;

    [SerializeField]
    private Parts_Point emort;

    // Start is called before the first frame update
    public Parts_Point Get_Emort(){
        return emort;
    }
    void Start()
    {
        _npc_obj = transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {
    }
    public void Look(Vector3 v){
        _npc_obj.transform.LookAt(v);
    }
}
