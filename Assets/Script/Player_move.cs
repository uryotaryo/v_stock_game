using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_move : MonoBehaviour
{
    private Vector3 _target;
    private NavMeshAgent _this_agent;
    // Start is called before the first frame update
    void Start()
    {
        _target = this.transform.position;
        _this_agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.transform.position = new Vector3(transform.position.x,0,transform.position.z);
        transform.localPosition = new Vector3(0,0,0);
    }
    public void Set_Target(Vector3 t){
        _target = t;
        _this_agent.SetDestination(_target);
    }
}
