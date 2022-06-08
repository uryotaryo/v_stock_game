using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode]
public class StageManeger : MonoBehaviour
{
    [SerializeField]
    private float stageBox_Interval;
    [NonSerialized]
    public int[,] Path_finding_map = {
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0}
        };
    private int[,]Design_map = {
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,1,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,1,0,1,0,1,0,1,0,1},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0}
    };
    [SerializeField]
    private GameObject[] stageObj;
    private (int x,int y)StageSize;
    private (int x,int y)targetpos;

    public void OnDate(){
        StageSize = (Design_map.GetLength(0),Design_map.GetLength(1));
        foreach (Transform t in this.transform){
            EditorApplication.delayCall += () => Destroy(t.gameObject);
        }
        test();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Set_Stage_Maneger(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Get_Stage_Maneger() == null) GameManager.Set_Stage_Maneger(this.gameObject);

    }
    public Vector3 VectorReturn(int x,int y){
        Vector3 samon_pos = new Vector3((-(StageSize.x/2)+x)*stageBox_Interval,0,(-(StageSize.y/2)+y)*stageBox_Interval);
        Vector3 box_pos = this.transform.position;
        box_pos.x += samon_pos.x; 
        box_pos.y += samon_pos.y;
        box_pos.z += samon_pos.z;
        return box_pos;
    }
    public static (int,int)BoxPos_Move(int n_x,int n_y,int g_x,int g_y){
        int x_diff = diff(n_x,g_x);
        int y_diff = diff(n_y,g_y);
        if(x_diff == 0&& y_diff == 0)return(n_x,n_y);
        if(y_diff > x_diff||x_diff == 0)
        {
            return(n_x,n_y-1);
        }
        else return (n_x-1,n_y);
    }
    private static int diff(int s,int g){
        return (s - g) * (int)Mathf.Sign(s - g);
    }
    private void test(){
        for (int x = 0;x < Design_map.GetLength(0);x++){
            for(int y = 0;y < Design_map.GetLength(1);y++){
                samon(stageObj[Design_map[x,y]],x,y);
                Debug.Log(Design_map[x,y]);
            }

        }
    }
    public void DoTarget((int x,int y)target){
        targetpos = target;
        GameObject.FindWithTag("Player").GetComponent<Player>().Set_target(targetpos.x,targetpos.y);
        //Debug.Log(targetpos);
    }
    private void repos(GameObject g, Vector3 v){
        g.transform.localPosition = v;
    }
    private void samon(GameObject obj,int x,int y){
        Vector3 samon_pos = new Vector3((-(StageSize.x/2)+x)*stageBox_Interval,0,(-(StageSize.y/2)+y)*stageBox_Interval);
        Vector3 box_pos = this.transform.position;
        box_pos.x += samon_pos.x; 
        box_pos.y += samon_pos.y;
        box_pos.z += samon_pos.z;
        var game_obj = Instantiate(obj,Vector3.zero,Quaternion.identity);
        var ads = game_obj.AddComponent<StagePropaty>();
        game_obj.GetComponent<StagePropaty>().Set_Box_Pos(x,y);
        EditorApplication.delayCall += () => game_obj.transform.SetParent(this.transform);
        repos(game_obj,box_pos);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StageManeger))]
public class StageManegerEditer:Editor{
    void OnEnable(){

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("作成")){
            Debug.Log("ステージを再作成します。");
            ((StageManeger)target).OnDate();
        }
    }
}
#endif