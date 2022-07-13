using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー管理用クラス
/// </summary>
public class Player : MonoBehaviour
{
    //一時用位置座標
    private int _x,_y;
    private int _t_x,_t_y;
    private Vector3 meta_pos;
    private Vector3 target_vector3;
    //プレイヤーのビジュアルオブジェクト格納
    [SerializeField]
    private GameObject player_obj;
    //プレイヤーの移動速度
    [SerializeField]
    private float move_speed;
    private float lerp_Intbal_meta;
    private float meta_lerp_pos;
    /// <summary>
    /// ターゲット位置をセットする
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Set_target(int x, int y){
        _t_x = x;
        _t_y = y;
    }
    /// <summary>
    /// プレイヤーの現在位置を返す
    /// </summary>
    /// <returns>x,y</returns>
    public (int,int) Get_Point(){
        return (_x,_y);
    }
    //1人称と3人称カメラの格納
    [SerializeField]
    private GameObject FpsCam;
    [SerializeField]
    private GameObject TpsCam;
    /// <summary>
    /// 格子の現在座標とターゲットと座標の比較
    /// </summary>
    /// <returns>true:違うfalse:同じ
    /// </returns>
    private bool posCheck(){
        if(_x==_t_x &&_y == _t_y)return false;
        return true;
    }
    void Start()
    {
        //ステージの真ん中にプレイヤーを移動させる
        var stagesize = GameManager.Get_Stage_Manager().GetComponent<StageManeger>().StageSize;
        _x = stagesize.x/2;
        _y = stagesize.y/2;
        Set_target(_x,_y);
        this.transform.position = GameManager.Get_Stage_Manager().GetComponent<StageManeger>().VectorReturn(_x,_y);
        
        //変数初期化
        var pos = this.transform.position;
        target_vector3 = pos;
        pos.y = 1;
        this.transform.position = pos;
        meta_pos = pos;
        if(FpsCam == null || TpsCam == null)return;
        FpsCam.SetActive(false);
        TpsCam.SetActive(true);
    }
    void Update()
    {
        //線形保管を使いながら仮ターゲットへ移動する
        if(posCheck() || this.transform.position != target_vector3){
            meta_lerp_pos += Time.deltaTime;
            if(1/move_speed <= meta_lerp_pos){
                meta_lerp_pos = 0;
                lerp_Intbal_meta += 0.05f;
                var pos = Vector3.Lerp(meta_pos,target_vector3,lerp_Intbal_meta);
                XZMove(pos);
            }
        }
        //仮ターゲットへ到着したら仮ターゲットを更新する
        if(lerp_Intbal_meta >= 1){
            if(posCheck()){
                var repos = StageManeger.BoxPos_Move(_x,_y,_t_x,_t_y);
                _x = repos.Item1;
                _y = repos.Item2;
                target_vector3 = GameManager.Get_Stage_Manager().GetComponent<StageManeger>().VectorReturn(_x,_y);
                meta_pos = this.transform.position;
                lerp_Intbal_meta = 0;
                if(player_obj != null)player_obj.transform.LookAt(new Vector3( target_vector3.x,player_obj.transform.position.y, target_vector3.z));
                Quaternion quaternion = player_obj.transform.localRotation;
                FpsCam.transform.localRotation =  quaternion;
            }
        }
        //カメラを変える
        if (Input.GetKeyDown(KeyCode.V)){
            Cam_Change();
        }
    }
    /// <summary>
    /// 一人称カメラと3人称カメラの表示非表示を反転させる
    /// </summary>
    private void Cam_Change(){
        FpsCam.SetActive(!FpsCam.activeSelf);
        TpsCam.SetActive(!TpsCam.activeSelf);
        Debug.Log("カメラチェンジ");
    }
    private void Pos_Teleport(int x,int y){
        //TODO:即座にその位置に出現させる
    }
    /// <summary>
    /// Y位置を固定してプレイヤーを移動させる
    /// </summary>
    /// <param name="v"></param>
    private void XZMove(Vector3 v){
        this.transform.position = new Vector3(v.x,1,v.z);
    }
}
