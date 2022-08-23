using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public static Dictionary<string,Question> Dict_Q;
    public static Dictionary<string,Task>All_Tasks;
    public static void Q_And_A_Load(){
        Question_Load();
        Reply_Load();
        Task_Load();
        Task_Set();
    }
    /// <summary>
    /// NPCが質問する内容
    /// </summary>
    private static void Question_Load(){
        Dict_Q = new Dictionary<string, Question>();
        Dict_Q.Add("2",new Question("何を話そう"));

        Dict_Q.Add("3-1",new Question("木を伐採してほしい"));
        Dict_Q.Add("3-2",new Question("世間話"));

        Dict_Q.Add("4-1",new Question("理由説明"));

        Dict_Q.Add("6-1",new Question("交渉"));
    }
    /// <summary>
    /// 質問に紐づけされる解答一覧
    /// </summary>
    private static void Reply_Load(){  
        Dict_Q["2"].Anss.Add(new Reply("要件","何か用事があるんですか？",Dict_Q["3-1"]));
        Dict_Q["2"].Anss.Add(new Reply("世間話","世間話ですか？",Dict_Q["3-2"]));
        Dict_Q["2"].Anss.Add(new Reply("特になし","・・・",1));

        Dict_Q["3-1"].Anss.Add(new Reply("了解","了解した。",0));
        Dict_Q["3-1"].Anss.Add(new Reply("疑問","なぜ？",Dict_Q["4-1"]));

        Dict_Q["3-2"].Anss.Add(new Reply("困っていることない？","あなたがこうして話しかけてきていることですかね？",1));
        Dict_Q["3-2"].Anss.Add(new Reply("趣味は？","読書ですかね落ち着きますよ",Dict_Q["6-1"]));

        Dict_Q["4-1"].Anss.Add(new Reply("木が不足している","それなら仕方がないですね",0));
        Dict_Q["4-1"].Anss.Add(new Reply("暇でしょ？","暇というわけではないですよ",Dict_Q["6-1"]));
        
        Dict_Q["6-1"].Anss.Add(new Reply("本を渡す","これはまだ読んだことがないことですねいいでしょう行きますよ。",0));
        Dict_Q["6-1"].Anss.Add(new Reply("強引に行かせる","ﾁｯ…仕方がありませんね",1));

    }
    /// <summary>
    /// ゲーム内の全てのタスクをここで定義する 
    /// </summary>
    private static void Task_Load(){
        All_Tasks = new Dictionary<string, Task>();
        All_Tasks["例タスク"] = new Task("タスクの名前","タスクの詳細説明",10);//例タスクはプログラム内で使う文字列同名だと上書きされる　最後はタスクの作業量

    }
    /// <summary>
    /// 仮:)すべてのタスクから建物ごとに関係のあるタスクを振り分ける。
    /// </summary>
    private static void Task_Set(){

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
        Change_Complain = Complain;
        Ans_Type = Reply_Type.Complain_fluctuation;
    }
    public Reply(string name,string info,Question next){
        Select_string = name;
        NPC_Ans = info;
        Next_Question = next;
        Ans_Type = Reply_Type.Ans_Reply;
    } 
}
public class Task{
    public string Name{get;}
    public string Explanation{get;}
    public int Content_Num{get{return _Num;}}
    public int Content_Num_Max{get;}
    private int _Num;
    public Task(string name ,string expl,int count){
        Name = name;
        Explanation = expl;
        _Num = 0;
        Content_Num_Max = count;
    }
    public void Task_Stage_Clear(){
        if(Task_Clear())return;
        _Num++;
    }
    public bool Task_Clear(){
        if(Content_Num >= Content_Num_Max)return true;
        return false;
    }
}