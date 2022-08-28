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

    /// <summary>
    /// 格納した自身のクラスを返す
    /// </summary>
    /// <returns>GameManager</returns>
    public static GameManager Get_GameManager(){
        return _my_Manager;
    }

    /// <summary>
    /// FPS制限
    /// 自身やほかの管理オブジェクトの格納
    /// </summary>
    private void Awake(){
        //1秒60フレームに固定する
        Application.targetFrameRate = 60;
        _my_Manager = this.GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Conversation.Q_And_A_Load();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
