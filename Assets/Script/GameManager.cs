using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ゲーム全体を管理するクラス
/// 各機能の管理オブジェクトを返す
/// </summary>
public class GameManager : MonoBehaviour
{
    //自身のクラスを格納する
    private static GameManager _my_Manager;
    private static GameObject _stage_Manager;
    private static Player _Player;

    /// <summary>
    /// 格納した自身のクラスを返す
    /// </summary>
    /// <returns>GameManager</returns>
    public static GameManager Get_GameManager(){
        return _my_Manager;
    }

    /// <summary>
    /// ステージ管理オブジェクトを格納する
    /// </summary>
    /// <param name="obj">stageManager</param>
    public static void Set_Stage_Manager(GameObject obj){
        _stage_Manager = obj;
    }

    /// <summary>
    /// ステージ管理オブジェクトを返す
    /// </summary>
    /// <returns>GameObject:stage_manager</returns>
    public static GameObject Get_Stage_Manager(){
        return _stage_Manager;
    }
    ///
    public static void Set_Player(Player p){
        _Player = p;
    }
    public static Player Get_Player(){
        return _Player;
    }


    /// <summary>
    /// FPS制限
    /// 自身やほかの管理オブジェクトの格納
    /// </summary>
    private void Awake(){
        //1秒60フレームに固定する
        Application.targetFrameRate = 60;
        _my_Manager = this.GetComponent<GameManager>();
        _stage_Manager = GameObject.FindWithTag("StageManager");
        Set_Player(GameObject.FindWithTag("Player").GetComponent<Player>());
    }
    // Start is called before the first frame update
    void Start()
    {
        Conversation.Q_And_A_Load();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの入力データを検出
        Player_Input.Input_Update();
    }
}
/// <summary>
/// プレイヤーの入力を管理するクラス
/// </summary>
public static class Player_Input{
    /// マウスのクリック間隔の調整(ミリ秒)
    private static float _mouse_Click_Interval = 500;
    //マウスのクリック間隔を測る用の変数
    private static float _mouse_Click_Interval_Meta;
    //マウスの左ボタンが押された
    public static bool Mouse_Left_Down = false;
    //マウスの左ボタンが上がった
    public static bool Mouse_Left_Up = false;
    //左クリック
    public static bool Mouse_Left_Click = false;
    //マウスの移動距離
    public static Vector2 Move_Difference = new Vector2(0,0);
    /// <summary>
    /// プレイヤーの入力を感知:処理する関数
    /// </summary>
    public static void Input_Update(){
        full_false();
        if(Mouse.current.leftButton.isPressed){
            Mouse_Left_Down = true;
            _mouse_Click_Interval_Meta -= Time.deltaTime*1000;
        }
        if(Mouse.current.leftButton.wasPressedThisFrame){
            if(_mouse_Click_Interval_Meta > 0)Mouse_Left_Click = true;
            _mouse_Click_Interval_Meta = _mouse_Click_Interval;
            Mouse_Left_Up = true;
        }
    }
    private static void mouse_Move(){
    }
    /// <summary>
    /// 一度全ての入力判定をなくす
    /// </summary>
    private static void full_false(){
        Mouse_Left_Down = false;
        Mouse_Left_Up = false;
        Mouse_Left_Click = false;
    }
}
