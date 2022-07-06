using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 円状に広がるメニューを管理する
/// </summary>
public class MenuUi : MonoBehaviour
{
    //表示したい２Dメニュー格納
    [SerializeField]
    private GameObject[] Menus;
    //メニュー配置用の方向ベクトル
    private Vector2[] point = {
        new Vector2(0,1),//上
        new Vector2(1,1),//右上
        new Vector2(1,0),//右
        new Vector2(1,-1),//右下
        new Vector2(0,-1),//下
        new Vector2(-1,-1),//左下
        new Vector2(-1,0),//左
        new Vector2(-1,1),//左上
    };
    //メニュー配置順
    private int[][] pos_setting = {
        new int[1]{1},
        new int[2]{6,2},
        new int[3]{0,2,6},
        new int[4]{0,2,4,6},
        new int[5]{0,2,3,5,6},
        new int[6]{1,2,3,5,6,7},
        new int[7]{0,1,2,3,5,6,7},
        new int[8]{0,1,2,3,4,5,6,7},
    };
    //メインカメラの格納
    private GameObject MainCam;
    //プレイヤーのオブジェクト格納
    private GameObject _player;
#if UNITY_EDITOR
    /// <summary>
    /// エディタ上で変更があった場合に呼び出される
    /// </summary>
    public void OnDate(){
        //メニュー配列が多かったり少ない場合の例外処理
        if(Menus.Length < 1||Menus.Length > 8){
            Debug.Log("表示可能メニュー数を下回っているか数が多すぎます。");
            return;
        }
        //プレハブの中身を変更する
        var objName = PrefabUtility.GetCorrespondingObjectFromSource(this.gameObject);
        string PrefabPath = UnityEditor.AssetDatabase.GetAssetPath(objName);
        GameObject useObj;
        if(PrefabPath == "")useObj = this.gameObject;
        else useObj = PrefabUtility.LoadPrefabContents(PrefabPath);
        if(useObj.tag != "Menu")return;
        DestroyChild(useObj);
        Create_menu(useObj);
        if(PrefabPath == "")return;
        PrefabUtility.SaveAsPrefabAsset(useObj,PrefabPath);
        PrefabUtility.UnloadPrefabContents(useObj);
    }
#endif
    /// <summary>
    /// 親オブジェクトから子オブジェクトを全て削除する
    /// </summary>
    /// <param name="parent">親オブジェクト</param>
    private static void DestroyChild(GameObject parent){
        //TODO:ゲームマネージャーにステージの奴とまとめて書いてもいいかもしれない
        int childMax = parent.transform.childCount;
        for (int c = 0;c < childMax;c++){
#if UNITY_EDITOR
            DestroyImmediate(parent.transform.GetChild(0).gameObject);
#else
            Destroy(parent.transform.GetChild(0).gameObject);
#endif
        }
    }
    /// <summary>
    /// 円状に広がるメニューを生成する
    /// </summary>
    /// <param name="parent">親となるオブジェクト</param>
    private void Create_menu(GameObject parent){        
        int Menu_count = Menus.Length;
        int[] this_setting = pos_setting[Menu_count-1];
        var size = this.GetComponent<RectTransform>().sizeDelta;
        Debug.Log(size);
        for (int i = 0;i<Menu_count;i++){
            if(Menus[i] == null)break;
            Vector3 pos = new Vector3((size.x/6)*point[this_setting[i]].x*2,(size.y/6)*point[this_setting[i]].y*2,0);
            var game_obj = Instantiate(Menus[i],Vector3.zero,Quaternion.identity);
            game_obj.transform.SetParent(parent.transform);
            game_obj.GetComponent<RectTransform>().position = pos;
            game_obj.GetComponent<RectTransform>().sizeDelta = size/4;
            game_obj.AddComponent<MenuProperties>();
            game_obj.AddComponent<MenuMeta>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //3人称カメラとプレイヤーのゲームオブジェクトを取得する
        MainCam = GameObject.FindWithTag("Camera");
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //3人称カメラとプレイヤーのゲームオブジェクトがない場合を取得する
        if(MainCam == null){
            MainCam = GameObject.FindWithTag("Camera");
            return;
        }
        if(_player == null){
            _player = GameObject.FindWithTag("Player");
            return;
        }
        //プレイヤーの位置に円形メニューを表示する
        var ScreenPos = MainCam.GetComponent<Camera>().WorldToScreenPoint(_player.transform.position);
        this.GetComponent<RectTransform>().position = ScreenPos;
        //子オブジェクト全てをエリアに収める
        foreach (Transform c in this.transform){
            Fit_Within_Area(c.gameObject);
        }

    }
    /// <summary>
    /// 円形メニューのUIが一定エリアから出ないようにする
    /// </summary>
    /// <param name="g">エリアから出したくないオブジェクト</param>
    private void Fit_Within_Area(GameObject g){
        var r_tf = g.GetComponent<RectTransform>();
        if(r_tf == null)return;
        var r_pos = r_tf.localPosition;
        var t_size = this.GetComponent<RectTransform>().sizeDelta;
        if((t_size.x/2) < r_pos.x)r_pos.x = (t_size.x/2);
        else if(-(t_size.x/2) > r_pos.x)r_pos.x = -(t_size.x/2);

        if((t_size.y/2) < r_pos.y)r_pos.y = (t_size.y/2);
        else if(-(t_size.y/2) > r_pos.y)r_pos.y = -(t_size.y/2);

        g.GetComponent<RectTransform>().localPosition = r_pos;
    }

}


#if UNITY_EDITOR
[CustomEditor(typeof(MenuUi))]
/// <summary>
/// インスペクターに表示されるエディタ拡張
/// </summary>
public class MenuUi_Editor:Editor{
    void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("作成")){
            Debug.Log("コミュニケーションメニューを再作成します。");
            
            ((MenuUi)target).OnDate();
        }
    }
}
#endif
