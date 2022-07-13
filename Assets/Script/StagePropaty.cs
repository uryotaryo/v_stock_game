using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ステージ用オブジェクトのプロパティクラス
/// </summary>
public class StagePropaty : MonoBehaviour
{
    //自身の位置を格納する
    public int x;
    public int y;

    private GameObject _stageMane;
    //ステージマネージャーをセットする
    public void Set_Stage_Manager(GameObject SM){
        _stageMane = SM;
    }
    /// <summary>
    /// 自身のステージ位置を格納
    /// </summary>
    /// <param name="p_x"></param>
    /// <param name="p_y"></param>
    public void Set_Box_Pos(int p_x,int p_y){
        x = p_x;
        y = p_y;
    }
    /// <summary>
    /// raycastが当たった場合にステージマネージャーに当たったことを通知する
    /// </summary>
    public void Hit(){
        if(_stageMane == null) return;
        _stageMane.GetComponent<StageManeger>().DoTarget((x,y));
    }
    // Start is called before the first frame update
    void Start()
    {
        Set_Stage_Manager(this.transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
