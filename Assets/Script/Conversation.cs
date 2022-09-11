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
        //金魚すくい
        Dict_Q.Add("金魚すくい:挨拶", new Question("お疲れ様です～"));

        //Dict_Q.Add("金魚すくい:共通", new Question("お疲れ様です～"));
        //Dict_Q.Add("金魚すくい:1-1", new Question("丁寧のプレイヤーの返し"));
        //Dict_Q.Add("金魚すくい:1-2", new Question("雑のプレイヤーの返し"));

        Dict_Q.Add("金魚すくい:1", new Question("プレイヤー行動選択肢"));

        Dict_Q.Add("金魚すくい:2", new Question("お面を作ってもらいたい"));
        Dict_Q.Add("金魚すくい:2-1", new Question("(もう一度頼もう)"));

        Dict_Q.Add("金魚すくい:3", new Question("世間話"));
        Dict_Q.Add("金魚すくい:3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("金魚すくい:3-2", new Question("趣味の選択肢"));

        Dict_Q.Add("金魚すくい:会話1", new Question("好きなこと"));
        Dict_Q.Add("金魚すくい:会話2", new Question("嫌いなこと"));
        Dict_Q.Add("金魚すくい:会話3", new Question("趣味"));
        Dict_Q.Add("金魚すくい:会話4", new Question("金魚すくいのコツ"));
        Dict_Q.Add("金魚すくい:会話5", new Question("お祭りへの意気込み"));
    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load()
    {
        //金魚すくい//

        Dict_Q["金魚すくい:挨拶"].Anss.Add(new Reply("挨拶", "お疲れ～", Dict_Q["金魚すくい:1"]));


        //共通タスクのやつ//
        //Dict_Q["金魚すくい:共通"].Anss.Add(new Reply("丁寧", "大丈夫だよ～", Dict_Q["金魚すくい:1-1"]));
        //Dict_Q["金魚すくい:共通"].Anss.Add(new Reply("雑", "了解", Dict_Q["金魚すくい:1-2"]));
        //Dict_Q["金魚すくい:1-1"].Talks.Add("ありがとうございます！");
        //Dict_Q["金魚すくい:1-2"].Talks.Add("ありがとう！頼むね");

        //タスク消化
        Dict_Q["金魚すくい:1"].Anss.Add(new Reply("要件", "何か用かな？", Dict_Q["金魚すくい:2"]));

        Dict_Q["金魚すくい:2"].Anss.Add(new Reply("丁寧", "大丈夫だよ、任せてください", -1));
        Dict_Q["金魚すくい:2"].Anss.Add(new Reply("一般", "OKです。やってきますね", 0));
        Dict_Q["金魚すくい:2"].Anss.Add(new Reply("雑", "それはちょっと…", Dict_Q["金魚すくい:2-1"]));

        Dict_Q["金魚すくい:2-1"].Anss.Add(new Reply("一般", "OKです。やってきますね", 0));
        Dict_Q["金魚すくい:2-1"].Anss.Add(new Reply("雑", "うーん、まあいいですけど", +1));

        //世間話の選択と世間話１
        Dict_Q["金魚すくい:1"].Anss.Add(new Reply("世間話", "世間話ですか？いいですね", Dict_Q["金魚すくい:3"]));

        Dict_Q["金魚すくい:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["金魚すくい:会話1"]));

        Dict_Q["金魚すくい:会話1"].Talks.Add("動物を育てることかな");
        Dict_Q["金魚すくい:会話1"].Next_Question = Dict_Q["金魚すくい:3-1"];

        Dict_Q["金魚すくい:3-1"].Anss.Add(new Reply("いいですよね", "わかる～見てると癒されるんだよね", -2));
        Dict_Q["金魚すくい:3-1"].Anss.Add(new Reply("ほかの方はどうだろう？", "どうなんだろう？お面の方は狐が好きそうだね笑", -2));

        //世間話２
        Dict_Q["金魚すくい:3"].Anss.Add(new Reply("Hate", "嫌いなこととかありますか？", Dict_Q["金魚すくい:会話2"]));

        Dict_Q["金魚すくい:会話2"].Talks.Add("少し騒がしいところが苦手かな");
        Dict_Q["金魚すくい:会話2"].Talks.Add("なるほど…");
        Dict_Q["金魚すくい:会話2"].Talks.Add("祭りとかはいいんだけど、どうも気分が乗らなくてね");
        Dict_Q["金魚すくい:会話2"].Talks.Add("注意しておきます");
        Dict_Q["金魚すくい:会話2"].Talks.Add("頼みます。焼き鳥の人とか少し苦手…");

        //世間話３
        Dict_Q["金魚すくい:3"].Anss.Add(new Reply("hobby", "趣味はありますか", Dict_Q["金魚すくい:会話3"]));

        Dict_Q["金魚すくい:会話3"].Talks.Add("小説を読むのが好きだね。");
        Dict_Q["金魚すくい:会話3"].Talks.Add("どんなものが好き？");
        Dict_Q["金魚すくい:会話3"].Talks.Add("謎解き系を読むかな。少し難しいけど面白いですよ");
        Dict_Q["金魚すくい:会話3"].Next_Question = Dict_Q["金魚すくい:3-2"];

        Dict_Q["金魚すくい:3-2"].Anss.Add(new Reply("読んでみます", "ぜひ感想教えてね", -2));
        Dict_Q["金魚すくい:3-2"].Anss.Add(new Reply("活字苦手…", "そういえば、お面の方も読書をたしなむって聞きました。話しかけたら、何かおすすめの本を教えてくれるかも", -2));

        //世間話４
        Dict_Q["金魚すくい:3"].Anss.Add(new Reply("point", "金魚すくいのコツは？", Dict_Q["金魚すくい:会話4"]));

        Dict_Q["金魚すくい:会話4"].Talks.Add("あまり教えたくないのだけど…");
        Dict_Q["金魚すくい:会話4"].Talks.Add("少しだけ教えてください");
        Dict_Q["金魚すくい:会話4"].Talks.Add("しいて言えば壁際の水面近くの金魚なんかがねらい目だよ");
        Dict_Q["金魚すくい:会話4"].Talks.Add("なるほど…");
        Dict_Q["金魚すくい:会話4"].Talks.Add("あまり広めないでくださいね笑");

        //世間話５
        Dict_Q["金魚すくい:3"].Anss.Add(new Reply("Interview", "お祭りへの意気込みをお願いします！", Dict_Q["金魚すくい:会話5"]));

        Dict_Q["金魚すくい:会話5"].Talks.Add("やっぱりたくさんの人に楽しんでほしいね");
        Dict_Q["金魚すくい:会話5"].Talks.Add("そうですよね！");
        Dict_Q["金魚すくい:会話5"].Talks.Add("そのためにあなたも頑張ってくれているから、こちらも頑張らないと");
        Dict_Q["金魚すくい:会話5"].Talks.Add("ありがとうございます。絶対成功させましょう！");
        Dict_Q["金魚すくい:会話5"].Talks.Add("頑張ろうね");

        //特になし
        Dict_Q["金魚すくい:1"].Anss.Add(new Reply("特になし", "あ、そう？", 0));
    }
    /// <summary>
    /// ゲーム内の全てのタスクをここで定義する 
    /// </summary>
    private static void Task_Load()
    {
        All_Tasks = new Dictionary<string, Task>();
        
        //例タスクはプログラム内で使う文字列同名だと上書きされる　最後はタスクの作業量
        All_Tasks["金魚すくい"] = new Task("金魚すくい", "金魚を100匹発注しよう", 100);
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