using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleCommunication : MonoBehaviour
{
    //Textたち。頭文字が大文字
    //NPCが喋るテキスト
    public Text NPCText;

    //Playerの選択肢のテキスト
    public Text Choices1;
    public Text Choices2;
    public Text Choices3;
    public Text Choices4;

    //Textのオブジェクト。頭文字が小文字
    //NPCのTextのオブジェクト
    public GameObject NPCtext;

    //Playerの選択肢のオブジェクト
    public GameObject choices1;
    public GameObject choices2;
    public GameObject choices3;
    public GameObject choices4;



    // Start is called before the first frame update
    void Start()
    {
        NPCtext.SetActive(false);
        choices1.SetActive(false);
        choices2.SetActive(false);
        choices3.SetActive(false);
        choices4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //サンプルで最初に呼び出す
    public void Communication()
    {
        //NPCのコメントを可視化して発言
        NPCtext.SetActive(true);
        NPCText.text = "どうしたの？";

        //NPCの発言後、間隔を空けて選択肢を可視化する
        Invoke("Choose0", 1.0f);
    }

    //選択肢一回目
    void Choose0 ()
    {
        //選択肢を可視化し、内容を書き換え
        choices1.SetActive(true);
        Choices1.text = "要件";

        choices2.SetActive(true);
        Choices2.text = "世間話";

        choices3.SetActive(true);
        Choices3.text = "特になし";
    }

}
