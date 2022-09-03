using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private GameObject _npc_obj;
    [SerializeField]
    private Info.NPC_TYPE _Type;
    private NavMeshAgent _agent;
    public bool Stop;
    private Vector3 _lastpos;
/*
    [SerializeField]
    private Parts_Point emort;

    // Start is called before the first frame update
    public Parts_Point Get_Emort(){
        return emort;
    }
*/
    void Start()
    {
        _npc_obj = transform.GetChild(0).gameObject;
        _agent = _npc_obj.GetComponent<NavMeshAgent>();
        _agent.isStopped = false;
        Stop = true;
        _lastpos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(Stop)transform.position = _lastpos;
        _lastpos = transform.position;
        transform.position = new Vector3(_npc_obj.transform.position.x,0,_npc_obj.transform.position.z);
        switch(_Type){
            case Info.NPC_TYPE.OMEN:
                _npc_obj.transform.localPosition = new Vector3(0,-1.5f,0);
                break;
            default:
                _npc_obj.transform.localPosition = new Vector3(0,0,0);
                break;
        }
    }
    public void Look(Vector3 v){
        _npc_obj.transform.LookAt(v);
    }
    public void Set_Target_Point(Vector3 v)
    {
        if(_agent == null) return;
        _agent.SetDestination(v);
    }
}
