using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prot_cont : MonoBehaviour
{
    public static(int x,int y)tree_pos = (10,10);
    public static(int x,int y)NPC_pos = (3,9);
    [SerializeField]
    private GameObject prot_npc;
    [SerializeField]
    private GameObject prot_tree;
    private bool returnbool = false;
    private float sleep = 10;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;
        prot_npc.transform.position = GameManager.Get_Stage_Maneger().GetComponent<StageManeger>().VectorReturn(NPC_pos.x,NPC_pos.y);
        pos = prot_npc.transform.position;
        pos.y = 1;
        prot_npc.transform.position= pos;
        prot_tree.transform.position = GameManager.Get_Stage_Maneger().GetComponent<StageManeger>().VectorReturn(tree_pos.x,tree_pos.y);
        pos = prot_tree.transform.position;
        pos.y = 1;
        prot_tree.transform.position= pos;
        prot_npc.GetComponent<prot_NPC_cont>().pos = NPC_pos;
        prot_npc.GetComponent<prot_NPC_cont>().target = tree_pos;
        prot_npc.GetComponent<prot_NPC_cont>().Set_target();
    }

    // Update is called once per frame
    void Update()
    {
        if(prot_npc.transform.position == prot_tree.transform.position)returnbool = true;
        if(!returnbool)return;
        sleep -= Time.deltaTime;
        if(sleep > 0)return;
        prot_npc.GetComponent<prot_NPC_cont>().target = NPC_pos;
    }
    private void XZMove(Vector3 v){
        this.transform.position = new Vector3(v.x,1,v.z);
    }
}
