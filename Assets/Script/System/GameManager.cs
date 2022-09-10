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
    //プレイヤーのオブジェクトを格納する
    private static GameObject _player_Obj;
    public static TPS_UI_cont _TPS_UI;
    public static string Now_Task_Name;

    [SerializeField]
    private GameObject _Result;

    /// <summary>
    /// 格納した自身のクラスを返す
    /// </summary>
    /// <returns>GameManager</returns>
    public static GameManager Get_GameManager(){
        return _my_Manager;
    }
    /// <summary>
    /// 格納したプレイヤーオブジェクトを返す
    /// </summary>
    /// <returns>Player(GameObject)</returns>
    public static GameObject Get_Player_OBJ(){
        return _player_Obj;
    }


    /// <summary>
    /// FPS制限
    /// 自身やほかの管理オブジェクトの格納
    /// </summary>
    private void Awake(){
        //1秒60フレームに固定する
        Application.targetFrameRate = 60;
        _my_Manager = this.GetComponent<GameManager>();
        _player_Obj = GameObject.FindWithTag("Player");
        _TPS_UI = GameObject.FindWithTag("TPS_canvas").GetComponent<TPS_UI_cont>();
    }
    
    public void To_Result(){
        _Result.SetActive(true);
    }
    void Start()
    {
        Conversation.Q_And_A_Load();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
