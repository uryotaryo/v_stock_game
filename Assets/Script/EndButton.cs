using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //押されたらゲーム終了する関数
    public void Endgame()
    {
        //エディタ終了
        UnityEditor.EditorApplication.isPlaying = false;

        //スタンドアロン終了
        UnityEngine.Application.Quit();
    }
}
