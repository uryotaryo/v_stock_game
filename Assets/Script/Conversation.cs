using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public static Dictionary<string, Question> Dict_Q;
    public static Dictionary<string, Task> All_Tasks;
    public static void Q_And_A_Load()
    {
        Question_Load();
        Reply_Load();
        Task_Load();
        Task_Set();
    }
    /// <summary>
    /// NPCが質問する内容(P)
    /// </summary>
    private static void Question_Load()
    {
        Dict_Q = new Dictionary<string, Question>();

        //お面屋
        Dict_Q.Add("お面:挨拶", new Question("お疲れ様です～"));

        //Dict_Q.Add("お面:共通", new Question("お疲れ様です～"));
        //Dict_Q.Add("お面:1-1", new Question("丁寧のプレイヤーの返し"));
        //Dict_Q.Add("お面:1-2", new Question("雑のプレイヤーの返し"));

        Dict_Q.Add("お面:1", new Question("プレイヤー行動選択肢"));

        Dict_Q.Add("お面:2", new Question("お面を作ってもらいたい"));
        Dict_Q.Add("お面:2-1", new Question("(もう一度頼もう)"));

        Dict_Q.Add("お面:3", new Question("世間話"));
        Dict_Q.Add("お面:3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("お面:3-2", new Question("嫌いなことの選択肢"));
        Dict_Q.Add("お面:3-3", new Question("何者なのかの選択肢"));

        Dict_Q.Add("お面:会話1", new Question("好きなこと"));
        Dict_Q.Add("お面:会話2", new Question("嫌いなこと"));
        Dict_Q.Add("お面:会話3", new Question("何者なのか"));
        Dict_Q.Add("お面:会話4", new Question("なぜお面を？"));
        Dict_Q.Add("お面:会話5", new Question("お祭りへの意気込み"));

    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load()
    {
        //お面屋//

        Dict_Q["お面:挨拶"].Anss.Add(new Reply("挨拶", "お疲れ様～", Dict_Q["お面:1"]));


        //共通タスクのやつ//
        //Dict_Q["お面:共通"].Anss.Add(new Reply("丁寧", "わかったわ～頑張るわね", Dict_Q["1-1"]));
        //Dict_Q["お面:共通"].Anss.Add(new Reply("雑", "OK～", Dict_Q["1-2"]));
        //Dict_Q["1-1"].Talks.Add("お願いします！");
        //Dict_Q["1-2"].Talks.Add("任せる。頼むね～");

        //タスク消化
        Dict_Q["お面:1"].Anss.Add(new Reply("要件", "何か御用かしら？", Dict_Q["お面:2"]));

        Dict_Q["お面:2"].Anss.Add(new Reply("丁寧", "わかったわ～任せて頂戴", -1));
        Dict_Q["お面:2"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["お面:2"].Anss.Add(new Reply("雑", "それはちょっと嫌ね", Dict_Q["お面:2-1"]));

        Dict_Q["お面:2-1"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["お面:2-1"].Anss.Add(new Reply("雑", "…まぁいいわよ", +1));

        //世間話の選択と世間話１
        Dict_Q["お面:1"].Anss.Add(new Reply("世間話", "お話？いいわよ", Dict_Q["お面:3"]));

        Dict_Q["お面:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["お面:会話1"]));

        Dict_Q["お面:会話1"].Talks.Add("読書かしらね、最近は漫画をよく読むのよ");
        Dict_Q["お面:会話1"].Next_Question = Dict_Q["お面:3-1"];

        Dict_Q["お面:3-1"].Anss.Add(new Reply("意外です", "あら、そう？最近は面白いものがたくさんあるから、読み飽きないし面白いわよ？", -2));
        Dict_Q["お面:3-1"].Anss.Add(new Reply("おすすめを聞く", "そうね…スポーツ系統の漫画はジャンルが多くておすすめね。", -2));

        //世間話２
        Dict_Q["お面:3"].Anss.Add(new Reply("Hate", "嫌いなこととかありますか？", Dict_Q["お面:会話2"]));

        Dict_Q["お面:会話2"].Talks.Add("お魚が少し苦手ね…なんかこう不気味な感じがするわ。");
        Dict_Q["お面:会話2"].Next_Question = Dict_Q["お面:3-2"];

        Dict_Q["お面:3-2"].Anss.Add(new Reply("金魚すくいは？", "正直少し苦手ね…祭りということで妥協しているけれど…少しあのおじさまには気を使ってもらっているから申し訳ないわね。", -2));
        Dict_Q["お面:3-2"].Anss.Add(new Reply("不気味な感じ？", "あのギョロっとした目つきが特にゾッとするわ…もうこの話は終わりにしましょ…", -2));

        //世間話３
        Dict_Q["お面:3"].Anss.Add(new Reply("Who", "あなたは一体何者ですか…？", Dict_Q["お面:会話3"]));

        Dict_Q["お面:会話3"].Talks.Add("不思議な質問ねｗこの仮面の下が気になるの？");
        Dict_Q["お面:会話3"].Next_Question = Dict_Q["お面:3-3"];

        Dict_Q["お面:3-3"].Anss.Add(new Reply("気になる", "ふふｗ見せたくないってわけではないけど、知らない方がいいわよ～後悔しちゃうから...", -2));
        Dict_Q["お面:3-3"].Anss.Add(new Reply("気にならない", "あらそう？でもあんまりほかの方にそういうこといわない方がいいわよ、かき氷のお兄さん優しいけど、まじめだからしっかりね", -2));
        Dict_Q["お面:3-3"].Talks.Add("(やはり少し気になるなぁ…)");

        //世間話４
        Dict_Q["お面:3"].Anss.Add(new Reply("Why", "なぜお面屋のボランティアを？", Dict_Q["お面:会話4"]));

        Dict_Q["お面:会話4"].Talks.Add("昔からお面が好きだったからかしら？子供の頃お祭りでよくつけていたのよね");
        Dict_Q["お面:会話4"].Talks.Add("今もつけてますもんね");
        Dict_Q["お面:会話4"].Talks.Add("そうなの！祭りが地元であるここでやるって聞いてやりたかったのよね～");
        Dict_Q["お面:会話4"].Talks.Add("なるほど…では好きなお面は付けているその狐のお面ですか？");
        Dict_Q["お面:会話4"].Talks.Add("そうね…他のもいいけれどやっぱり狐ね～一番しっくりくるのよ");

        //世間話５
        Dict_Q["お面:3"].Anss.Add(new Reply("Interview", "お祭りへの意気込みをお願いします！", Dict_Q["お面:会話5"]));

        Dict_Q["お面:会話5"].Talks.Add("そうね…やっぱりたくさんの方にお祭りを楽しんでもらいたいわ");
        Dict_Q["お面:会話5"].Talks.Add("なるほど…");
        Dict_Q["お面:会話5"].Talks.Add("私もお祭りは好きだからね～そのために頑張らないとね");

        //特になし
        Dict_Q["お面:1"].Anss.Add(new Reply("特になし", "あら、そう。", 0));

    }
    /// <summary>
    /// ゲーム内の全てのタスクをここで定義する 
    /// </summary>
    private static void Task_Load()
    {
        All_Tasks = new Dictionary<string, Task>();
        
        //例タスクはプログラム内で使う文字列同名だと上書きされる　最後はタスクの作業量
        All_Tasks["お面"] = new Task("お面", "お面を50個作ろう", 50);
    }
    /// <summary>
    /// 仮:)すべてのタスクから建物ごとに関係のあるタスクを振り分ける。
    /// </summary>
    private static void Task_Set()
    {

    }
}
/// <summary>
/// 質問クラス
/// </summary>
public class Question
{
    //質問->返答->会話
    public string Question_Text;
    public List<Reply> Anss;
    public List<string> Talks;
    private int Talk_num = 0;
    public Question Next_Question;
    public Question(string text)
    {
        Question_Text = text;
        Talks = new List<string>();
        Anss = new List<Reply>();
    }
    public string Get_Talk(){
        string Re_str = "";
        if(Talks.Count > Talk_num)Re_str = Talks[Talk_num];
        Talk_num ++;
        return Re_str;
    }
}
/// <summary>
/// 返答情報クラス
/// </summary>
public class Reply
{
    public string Select_string;
    public string NPC_Ans;
    public int Change_Complain;
    public Question Next_Question;

    public Reply_Type Ans_Type { get; }

    /// <summary>
    ///  返答タイプ
    /// </summary>
    public enum Reply_Type
    {
        Ans_Reply = 0,
        Complain_fluctuation = 1,
    }

    public Reply(string name, string info, int Complain)
    {
        Select_string = name;
        NPC_Ans = info;
        Change_Complain = Complain;
        Ans_Type = Reply_Type.Complain_fluctuation;
    }
    public Reply(string name, string info, Question next)
    {
        Select_string = name;
        NPC_Ans = info;
        Next_Question = next;
        Ans_Type = Reply_Type.Ans_Reply;
    }
}
public class Task
{
    public string Name { get; }
    public string Explanation { get; }
    public int Content_Num { get { return _Num; } }
    public int Content_Num_Max { get; }
    private int _Num;
    public Task(string name, string expl, int count)
    {
        Name = name;
        Explanation = expl;
        _Num = 0;
        Content_Num_Max = count;
    }
    public void Task_Stage_Clear()
    {
        if (Task_Clear()) return;
        _Num++;
    }
    public bool Task_Clear()
    {
        if (Content_Num >= Content_Num_Max) return true;
        return false;
    }
}