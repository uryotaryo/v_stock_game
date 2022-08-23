using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Text : MonoBehaviour
{
    //資材の所持割合
    public int resource_percent;

    //資材の名前
    public string resouce_name;

    //表示するTextのオブジェクトをここに入れる
    public Text resouce_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //資材の名前：所持割合％で表示する
        resouce_text.text = string.Format("{0}:{1}%",resouce_name,resource_percent);
    }
}
