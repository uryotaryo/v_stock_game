using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode]
public class StageManager : MonoBehaviour
{
    //ステージ生成用objの間隔
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
    //動作確認用二次配列のリスト
    private List<int[,]>Stage_Maps = new List<int[,]>();
    //ステージ生成に用いられるオブジェクトかくのう配列
    [SerializeField]
    private GameObject[] stageObj;

    //生成ステージの選択
    [SerializeField]
    private StageType StageSet;
    //　生成ステージ一覧
    private enum StageType{
        prot1 = 0,
        prot2 = 1,
    }
    //　ステージの大きさ(横幅,縦幅)
    public (int x,int y)StageSize;

#if UNITY_EDITOR
    /// <summary>
    /// エディタに変更があった際に処理を行う
    /// </summary>
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
        //ステージサイズを計算する
        StageSize = (Stage_Maps[(int)StageSet].GetLength(0),Stage_Maps[(int)StageSet].GetLength(1));
        //自身のゲームオブジェクトをゲームマネージャーに格納する
        GameManager.Set_Stage_Manager(this.gameObject);
    }
    /// <summary>
    /// リストにステージ配列を格納する
    /// </summary>
    private void List_Load(){
        Stage_Maps.Add(Design_map);
        Stage_Maps.Add(prot_map);
    }
    /// <summary>
    /// 子オブジェクトをすべて削除する
    /// </summary>
    /// <param name="parent">子を削除したいゲームオブジェクト</param>
    private static void DestoryChild(GameObject parent){
        //子オブジェクトの数を取得する
        int child_max = parent.transform.childCount;
        //子オブジェクトの数だけ一つ目の子オブジェクトを削除する
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
        //ゲームマネージャーにステージマネージャーが格納されていなければ格納する
        if(GameManager.Get_Stage_Manager() == null) GameManager.Set_Stage_Manager(this.gameObject);
    }
    private void set_stage_route_map(){
        route_map = new int[StageSize.x,StageSize.y];
        for (int y = 0; y < StageSize.y;y++){
            for(int x = 0;x < StageSize.x;x++){
                route_map[x,y] = 0;
            }
        }
    }
    /// <summary>
    /// ステージの位置からグローバル座標を返す
    /// </summary>
    /// <param name="x">横位置</param>
    /// <param name="y">縦位置</param>
    /// <returns>グローバル座標</returns>
    public Vector3 VectorReturn(int x,int y){
        Vector3 samon_pos = new Vector3((-(StageSize.x/2)+x)*stageBox_Interval,0,(-(StageSize.y/2)+y)*stageBox_Interval);
        Vector3 box_pos = this.transform.position;
        box_pos.x += samon_pos.x; 
        box_pos.y += samon_pos.y;
        box_pos.z += samon_pos.z;
        return samon_pos;
    }
    /// <summary>
    /// 現在位置から目的位置へ向かう次の座標を計算する
    /// </summary>
    /// <param name="n_x">現在位置</param>
    /// <param name="n_y">現在位置</param>
    /// <param name="g_x">目的位置</param>
    /// <param name="g_y">目的位置</param>
    /// <returns>次の座標位置</returns>
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
    /// <summary>
    /// 座標位置からの距離
    /// </summary>
    /// <param name="s"></param>
    /// <param name="g"></param>
    /// <returns>+距離</returns>
    private static int diff(int s,int g){
        return (s - g) * (int)Mathf.Sign(s - g);
    }
    /// <summary>
    /// 選択したプリセットを使用してステージを生成する
    /// </summary>
    /// <param name="g"></param>
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
    /// <summary>
    /// プレイヤーの目的座標を更新する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y)target"></param>
    public void DoTarget((int x,int y)target){
        GameObject.FindWithTag("Player").GetComponent<Player>().Set_target(target.x,target.y);
    }
    /// <summary>
    /// 座標を格納する
    /// </summary>
    /// <param name="g"></param>
    /// <param name="v"></param>
    private void repos(GameObject g, Vector3 v){
        g.transform.localPosition = v;
    }
    /// <summary>
    /// 親オブジェクトをしてしてオブジェクトを生成する
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="preobj">親オブジェクト</param>
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