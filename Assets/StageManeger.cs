using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class StageManeger : MonoBehaviour
{
    [SerializeField]
    float stagebox_interval;
    [NonSerialized]
    public int[,] Pathfindingmap = {
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0}
        };
    private int[,]Designmap = {
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0}
    };
    [SerializeField]
    private GameObject[] stageobj;
    [SerializeField]
    private bool create;
    [SerializeField]
    private bool childdestroy;
    private (int x,int y)StageSize;
    void OnValidate(){
        StageSize = (Designmap.GetLength(0),Designmap.GetLength(1));
        if(create){
            test();
            create = false;
        }

    }
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void test(){
        for (int x = 0;x < Designmap.GetLength(0);x++){
            for(int y = 0;y < Designmap.GetLength(1);y++){
                samon(stageobj[Designmap[x,y]],x,y);
                Debug.Log(Designmap[x,y]);
            }

        }
    }
    private void Repos(GameObject g, Vector3 v){
        g.transform.localPosition = v;
    }
    private void samon(GameObject obj,int x,int y){
        Vector3 samonpos = new Vector3((-(StageSize.x/2)+x)*stagebox_interval,0,(-(StageSize.y/2)+y)*stagebox_interval);
        Vector3 boxpos = this.transform.position;
        boxpos.x += samonpos.x; 
        boxpos.y += samonpos.y;
        boxpos.z += samonpos.z;
        var gameobj = Instantiate(obj,Vector3.zero,Quaternion.identity);
        EditorApplication.delayCall += () => gameobj.transform.SetParent(this.transform);
        Repos(gameobj,boxpos);
    }
}
