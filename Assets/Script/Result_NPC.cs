using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Result_NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject[] NPCs;
    private NavMeshAgent _Agent;
    [SerializeField]
    private float ReTarget;
    private float ReTarget_meta_time;
    // Start is called before the first frame update
    void Start()
    {
        if(NPCs.Length <= 0)return;
        var g = Instantiate(NPCs[Random.Range(0,NPCs.Length-1)],this.transform.position,new Quaternion());
        g.transform.localScale = new Vector3 (0.2f,0.2f,0.2f);
        
        _Agent = g.transform.GetChild(0).gameObject.AddComponent<NavMeshAgent>();
        _Agent.height = _Agent.height/2;
        _Agent.baseOffset = 0;
        _Agent.speed = 2;
        g.transform.SetParent(this.transform);
        _Agent.SetDestination(this.transform.Find("Targets").GetChild(Random.Range(0,this.transform.Find("Targets").childCount-1)).position);

    }

    // Update is called once per frame
    void Update()
    {
        ReTarget_meta_time += Time.deltaTime;
        Debug.Log(ReTarget_meta_time);
        if(ReTarget <= ReTarget_meta_time){
            ReTarget_meta_time = 0;
            _Agent.SetDestination(this.transform.Find("Targets").GetChild(Random.Range(0,this.transform.Find("Targets").childCount-1)).position);

        }
    }
}
