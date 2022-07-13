using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 3人称カメラの移動や動作を管理する
/// </summary>
public class CameraMove : MonoBehaviour
{
    //自身のカメラコンポーネント
    private Camera myCamera;
    // カメラの移動速度
    [SerializeField]
    private float speed;

    private StageManager _S_Mana;
    // Start is called before the first frame update
    void Start()
    {
        //自身のカメラコンポーネントを格納する
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //UI上にポインタがないときに処理を行う
        if(!EventSystem.current.IsPointerOverGameObject()){
            GameObject hit_obj;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 100f;
            bool is_hit = Physics.Raycast(ray, out hit_info, max_distance); 
            //何かしらのオブジェクトに触れたら処理を行う
            if (is_hit) {
                //触れているときに左クリックしたとき
                if(Player_Input.Mouse_Left_Click){ 
                    if(hit_info.transform.tag == "Stage_Box"){
                        //触れたステージからステージ管理者へ位置座標を飛ばす
                        hit_info.transform.GetComponent<StagePropaty>().Hit();
                    }else if(hit_info.transform.tag == "NPC"){
                        if(_S_Mana == null) _S_Mana = GameManager.Get_Stage_Maneger().GetComponent<StageManager>();
                        _S_Mana.DoTarget(hit_info.transform.GetComponent<NPC>().pos);
                    } else{
                        hit_obj = hit_info.transform.gameObject;
                        Debug.Log(hit_obj);
                    }
                }
            }
        }
        //マウスホイールがスクロールされたときにカメラを前後に動かす
        var mous = Input.mouseScrollDelta;
        var pos = this.transform.position;
        pos += this.transform.forward * mous.y * speed;
        if(pos.y <= 5)return;
        this.transform.position = pos;
    }
}
