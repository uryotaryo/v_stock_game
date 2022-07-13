using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode]
public class StageManager : MonoBehaviour
{
    [SerializeField]
    private float stageBox_Interval;
    [NonSerialized]
    public static int[,] route_map;
    private static int[,]prot_map = {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
    };
    private static int[,]Design_map = {
        {0,1,0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0,1,0}
    };
    private List<int[,]>Stage_Maps = new List<int[,]>();
    [SerializeField]
    private GameObject[] stageObj;

    [SerializeField]
    private StageType StageSet;
    private enum StageType{
        prot1 = 0,
        prot2 = 1,
    }
    public (int x,int y)StageSize;
    private (int x,int y)target_pos;

#if UNITY_EDITOR
    public void OnDate(){
        List_Load();
        StageSize = (Stage_Maps[(int)StageSet].GetLength(0),Stage_Maps[(int)StageSet].GetLength(1));
        var obj_name = PrefabUtility.GetCorrespondingObjectFromSource(this.gameObject);
        string PrefabPath = UnityEditor.AssetDatabase.GetAssetPath(obj_name);
        GameObject useObj;
        if(PrefabPath == "")useObj = this.gameObject;
        else useObj = PrefabUtility.LoadPrefabContents(PrefabPath);
        DestoryChild(useObj);
        test(useObj);
        if(PrefabPath == "")return;
        PrefabUtility.SaveAsPrefabAsset(useObj,PrefabPath);
        PrefabUtility.UnloadPrefabContents(useObj);
    }
#endif
    public void Awake(){
        List_Load();
        StageSize = (Stage_Maps[(int)StageSet].GetLength(0),Stage_Maps[(int)StageSet].GetLength(1));
        GameManager.Set_Stage_Manager(this.gameObject);
    }
    private void List_Load(){
        Stage_Maps.Add(Design_map);
        Stage_Maps.Add(prot_map);
    }
    private static void DestoryChild(GameObject parent){
        int child_max = parent.transform.childCount;
        for (int c = 0;c < child_max;c++){
#if UNITY_EDITOR
            DestroyImmediate(parent.transform.GetChild(0).gameObject);
#else
            Destroy(parent.transform.GetChild(0).gameObject);
#endif
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        set_stage_route_map();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Get_Stage_Maneger() == null) GameManager.Set_Stage_Manager(this.gameObject);
    }
    private void set_stage_route_map(){
        route_map = new int[StageSize.x,StageSize.y];
        for (int y = 0; y < StageSize.y;y++){
            for(int x = 0;x < StageSize.x;x++){
                route_map[x,y] = 0;
            }
        }
    }
    public Vector3 VectorReturn(int x,int y){
        Vector3 samon_pos = new Vector3((-(StageSize.x/2)+x)*stageBox_Interval,0,(-(StageSize.y/2)+y)*stageBox_Interval);
        Vector3 box_pos = this.transform.position;
        box_pos.x += samon_pos.x; 
        box_pos.y += samon_pos.y;
        box_pos.z += samon_pos.z;
        return samon_pos;
    }
    public static (int,int)BoxPos_Move(int n_x,int n_y,int g_x,int g_y){
        int x_diff = diff(n_x,g_x);
        int y_diff = diff(n_y,g_y);
        (int x,int y)re_tup = (0,0);
        (int m_x,int m_y)move = ((n_x > g_x)?-1:+1,(n_y > g_y)?-1:+1);

        if((y_diff > x_diff||x_diff == 0)){
            re_tup = (n_x,n_y + move.m_y);
        }else if((x_diff > y_diff||y_diff == 0||x_diff == y_diff)){
            re_tup = (n_x + move.m_x,n_y);
        }
        else re_tup = (n_x,n_y);
        return re_tup;
    }
    private static int diff(int s,int g){
        return (s - g) * (int)Mathf.Sign(s - g);
    }
    private void test(GameObject g){
        for (int x = 0;x < Stage_Maps[(int)StageSet].GetLength(0);x++){
            for(int y = 0;y < Stage_Maps[(int)StageSet].GetLength(1);y++){
                if(Stage_Maps[(int)StageSet][x,y]+1 > stageObj.Length){
                    Debug.Log("このステージセットは使えません：オブジェクトの数が少ないです");
                    return;
                }
                samon(stageObj[Stage_Maps[(int)StageSet][x,y]],x,y,g);
            }

        }
    }
    public void DoTarget((int x,int y)target){
        target_pos = target;
        GameObject.FindWithTag("Player").GetComponent<Player>().Set_target(target_pos.x,target_pos.y);
    }
    private void repos(GameObject g, Vector3 v){
        g.transform.localPosition = v;
    }
    private void samon(GameObject obj,int x,int y,GameObject preobj){
        Vector3 samon_pos = new Vector3((-(StageSize.x/2)+x)*stageBox_Interval,0,(-(StageSize.y/2)+y)*stageBox_Interval);
        Vector3 box_pos = this.transform.position;
        box_pos.x += samon_pos.x; 
        box_pos.y += samon_pos.y;
        box_pos.z += samon_pos.z;
        var game_obj = Instantiate(obj,Vector3.zero,Quaternion.identity);
        var ads = game_obj.AddComponent<StagePropaty>();
        game_obj.GetComponent<StagePropaty>().Set_Box_Pos(x,y);

        game_obj.transform.SetParent(preobj.transform);

        repos(game_obj,box_pos);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StageManager))]
public class StageManagerEditer:Editor{
    void OnEnable(){

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("作成")){
            Debug.Log("ステージを再作成します。");
            ((StageManager)target).OnDate();
        }
    }
}
#endif