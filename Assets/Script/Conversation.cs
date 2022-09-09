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
    /// NPCが質問する内容(P)
    /// </summary>
    private static void Question_Load(){
        Dict_Q = new Dictionary<string, Question>();
        Dict_Q.Add("1",new Question("どうも。お疲れ様です。"));

        Dict_Q.Add("2",new Question("ザラメを集めてほしい"));
        Dict_Q.Add("2-4", new Question("(もう一度頼もう)"));

        Dict_Q.Add("3",new Question("世間話"));
        Dict_Q.Add("3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("3-2", new Question("嫌いなことの選択肢"));

        Dict_Q.Add("会話1", new Question("好きなこと"));
        Dict_Q.Add("会話2", new Question("嫌いなこと"));
        Dict_Q.Add("会話3", new Question("趣味"));
        Dict_Q.Add("会話4", new Question("焼き鳥屋店主について"));
        Dict_Q.Add("会話5", new Question("悩み"));
    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load(){  
        Dict_Q["1"].Anss.Add(new Reply("要件","何か用事があるんですか？",Dict_Q["2"]));
        Dict_Q["1"].Anss.Add(new Reply("世間話","世間話ですか？",Dict_Q["3"]));
        Dict_Q["1"].Anss.Add(new Reply("特になし","わかりました。",0));

        Dict_Q["2"].Anss.Add(new Reply("雑","いいですよ。喜んでやりましょう！",  -1));
        Dict_Q["2"].Anss.Add(new Reply("一般", "分かりました。手伝います。", 0));
        Dict_Q["2"].Anss.Add(new Reply("丁寧", "うーーん...", Dict_Q["2-4"]));

        Dict_Q["2-4"].Anss.Add(new Reply("一般", "分かりました", 0));
        Dict_Q["2-4"].Anss.Add(new Reply("丁寧", "まぁできなくもないです。", +1));

        Dict_Q["3"].Anss.Add(new Reply("Like","好きなことは何ですか？",Dict_Q["会話1"]));
        Dict_Q["3"].Anss.Add(new Reply("Hate","嫌いなことは？", Dict_Q["会話2"]));
        Dict_Q["3"].Anss.Add(new Reply("Hobby","趣味は？", Dict_Q["会話3"]));
        Dict_Q["3"].Anss.Add(new Reply("Friends","焼き鳥屋店主と仲が良いんですか？", Dict_Q["会話4"]));
        Dict_Q["3"].Anss.Add(new Reply("Worries","悩みはありますか？", Dict_Q["会話5"]));

        Dict_Q["3-1"].Anss.Add(new Reply("これからはラフな感じで話しかけるよ", "やはり敬語でない方が親しみやすくていいですね", 0));
        Dict_Q["3-1"].Anss.Add(new Reply("今後も遠慮なく話しかけさせてもらいます", "ああ、敬語でなくて結構ですよ...", 0));

        Dict_Q["3-2"].Anss.Add(new Reply("これからは僕が積極的に話しかけるよ！", "本当ですか？正直助かります", 0));
        Dict_Q["3-2"].Anss.Add(new Reply("会話って難しいですよね。同感です。", "そうですね。相手から積極的に距離を詰めてもらえると楽でいいのですが。", 0));

        Dict_Q["会話1"].Talks.Add("案外会話は好きですね");
        Dict_Q["会話1"].Talks.Add("意外ですね！");
        Dict_Q["会話1"].Talks.Add("気兼ねなく話しかけて下さい");
        Dict_Q["会話1"].Next_Question = Dict_Q["3-1"];

        Dict_Q["会話2"].Talks.Add("嫌いというか、苦手なものはあります。");
        Dict_Q["会話2"].Talks.Add("何が苦手なんですか？");
        Dict_Q["会話2"].Talks.Add("人との距離を縮めるのが苦手で...。会話は好きなのですが。");
        Dict_Q["会話2"].Next_Question = Dict_Q["3-2"];

        Dict_Q["会話3"].Talks.Add("お菓子作りが好きですね");
        Dict_Q["会話3"].Talks.Add("なるほど。お菓子が好きなんですか？");
        Dict_Q["会話3"].Talks.Add("好きですね。お祭りの綿あめとか好きです");

        Dict_Q["会話4"].Talks.Add("結構仲は良いですね...！");
        Dict_Q["会話4"].Talks.Add("相性が良いのかもしれないですね");
        Dict_Q["会話4"].Talks.Add("敬語は距離を感じるので苦手なんです。敬語を使わない彼の遠慮のなさが逆に良いですね。");

        Dict_Q["会話5"].Talks.Add("縁日で屋台の手伝いをお願いしたいのですが...");
        Dict_Q["会話5"].Talks.Add("大歓迎です！どんな手伝いがしたいんですか？");
        Dict_Q["会話5"].Talks.Add("甘い物を作る屋台などがあれば、手伝いたいですね。");

    }
    /// <summary>
    /// ゲーム内の全てのタスクをここで定義する 
    /// </summary>
    private static void Task_Load(){
        All_Tasks = new Dictionary<string, Task>();
        All_Tasks["綿あめ"] = new Task("綿あめ","ザラメを2000g用意しよう",2000);//例タスクはプログラム内で使う文字列同名だと上書きされる　最後はタスクの作業量

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
    public List<string> Talks;
    public Question Next_Question;
    public Question (string text){
        Question_Text = text;
        Talks = new List<string>();
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