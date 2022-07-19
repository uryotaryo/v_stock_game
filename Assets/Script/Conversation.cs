using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public static Dictionary<string,Question> Dict_Q;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Q_And_A_Load(){
        Question_Load();
        Reply_Load();
    }
    private static void Question_Load(){
        Dict_Q = new Dictionary<string, Question>();
        Dict_Q.Add("2",new Question("何を話そう"));

        Dict_Q.Add("3-1",new Question("木を伐採してほしい"));
        Dict_Q.Add("3-2",new Question("世間話"));

        Dict_Q.Add("4-1",new Question("理由説明"));

        Dict_Q.Add("6-1",new Question("交渉"));
    }
    private static void Reply_Load(){  
        Dict_Q["2"].Anss.Add(new Reply("要件","何か用事があるんですか？",Dict_Q["3-1"]));
        Dict_Q["2"].Anss.Add(new Reply("世間話","世間話ですか？",Dict_Q["3-2"]));
        Dict_Q["2"].Anss.Add(new Reply("特になし","・・・",0));

        Dict_Q["3-1"].Anss.Add(new Reply("了解","了解した。",+5));
        Dict_Q["3-1"].Anss.Add(new Reply("疑問","なぜ？",Dict_Q["4-1"]));

        Dict_Q["3-2"].Anss.Add(new Reply("困っていることない？","あなたがこうして話しかけてきていることですかね？",6));
        Dict_Q["3-2"].Anss.Add(new Reply("趣味は？","読書ですかね落ち着きますよ",Dict_Q["6-1"]));

        Dict_Q["4-1"].Anss.Add(new Reply("木が不足している","それなら仕方がないですね",0));
        Dict_Q["4-1"].Anss.Add(new Reply("暇でしょ？","暇というわけではないですよ",Dict_Q["6-1"]));
        
        Dict_Q["6-1"].Anss.Add(new Reply("本を渡す","これはまだ読んだことがないことですねいいでしょう行きますよ。",0));
        Dict_Q["6-1"].Anss.Add(new Reply("強引に行かせる","ﾁｯ…仕方がありませんね",10));
    }
}
/// <summary>
/// 質問クラス
/// </summary>
public class Question{
    public string Question_Text;
    public List<Reply> Anss;
    public Question (string text){
        Question_Text = text;
        Anss = new List<Reply>();
    }
}
/// <summary>
/// 返答情報クラス
/// </summary>
public class Reply{
    public string Select_string;
    public string NPC_Ans;
    public int Change_Complain;
    public Question Next_Question;

    public Reply_Type Ans_Type{get;}

    /// <summary>
    ///  返答タイプ
    /// </summary>
    public enum Reply_Type{
        Ans_Reply = 0,
        Complain_fluctuation = 1,
    }

    public Reply(string name,string info,int Complain){
        Select_string = name;
        NPC_Ans = info;
        Ans_Type = Reply_Type.Complain_fluctuation;
    }
    public Reply(string name,string info,Question next){
        Select_string = name;
        NPC_Ans = info;
        Ans_Type = Reply_Type.Ans_Reply;
    } 
}