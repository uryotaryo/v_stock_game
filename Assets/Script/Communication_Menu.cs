using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Communication_Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ShowMenu;
    [SerializeField]
    private float Menu_distance;
    private Camera cam;
    
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
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(cam.transform);
    }
    public void OnDate(){
        if(ShowMenu.Length < 1||ShowMenu.Length > 8){
            Debug.Log("表示可能メニュー数を下回っているか数が多すぎます。");
            return;
        }
        var objname = PrefabUtility.GetCorrespondingObjectFromSource(this.gameObject);
        string PrefabPath = UnityEditor.AssetDatabase.GetAssetPath(objname);
        GameObject useObj;
        if(PrefabPath == "")useObj = this.gameObject;
        else useObj = PrefabUtility.LoadPrefabContents(PrefabPath);
        DestoryChild(useObj);
        Create_menu(useObj);
        if(PrefabPath == "")return;
        PrefabUtility.SaveAsPrefabAsset(useObj,PrefabPath);
        PrefabUtility.UnloadPrefabContents(useObj);
    }
    private static void DestoryChild(GameObject parent){
        int childmax = parent.transform.childCount;
        for (int c = 0;c < childmax;c++){
#if UNITY_EDITOR
            DestroyImmediate(parent.transform.GetChild(0).gameObject);
#else
            Destroy(parent.transform.GetChild(0).gameObject);
#endif
        }
    }
    private void Create_menu(GameObject parent){        
        int Menu_count = ShowMenu.Length;
        int[] this_setting = pos_setting[Menu_count-1];
        for (int i = 0;i<Menu_count;i++){
            if(ShowMenu[i] == null)break;
            Vector3 pos = new Vector3(point[this_setting[i]].x,point[this_setting[i]].y,0);
            var game_obj = Instantiate(ShowMenu[i],pos.normalized*Menu_distance,Quaternion.identity);
            game_obj.transform.localEulerAngles = new Vector3(90f,0,0);
            game_obj.transform.SetParent(parent.transform);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Communication_Menu))]
public class Communication_Menu_Editor:Editor{
    void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("作成")){
            Debug.Log("コミュニケーションメニューを再作成します。");
            
            ((Communication_Menu)target).OnDate();
        }
    }
}
#endif