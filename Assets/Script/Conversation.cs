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

        Dict_Q.Add("1", new Question("プレイヤー行動選択肢"));

        Dict_Q.Add("2", new Question("お面を作ってもらいたい"));
        Dict_Q.Add("2-4", new Question("(もう一度頼もう)"));

        Dict_Q.Add("3", new Question("世間話"));
        Dict_Q.Add("3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("3-2", new Question("嫌いなことの選択肢"));
        Dict_Q.Add("3-3", new Question("何者なのかの選択肢"));

        Dict_Q.Add("会話1", new Question("好きなこと"));
        Dict_Q.Add("会話2", new Question("嫌いなこと"));
        Dict_Q.Add("会話3", new Question("何者なのか"));
        Dict_Q.Add("会話4", new Question("なぜお面を？"));
        Dict_Q.Add("会話5", new Question("お祭りへの意気込み"));
        //綿あめ屋
        Dict_Q.Add("綿あめ:挨拶", new Question("こんにちは"));

        Dict_Q.Add("綿あめ:1", new Question("会話選択肢"));

        Dict_Q.Add("綿あめ:2", new Question("ザラメを集めてほしい"));
        Dict_Q.Add("綿あめ:2-1", new Question("綿あめ返答1"));
        Dict_Q.Add("綿あめ:2-2", new Question("綿あめ返答2"));
        Dict_Q.Add("綿あめ:2-3", new Question("綿あめ返答3"));
        Dict_Q.Add("綿あめ:2-4", new Question("(もう一度頼もう)"));
        Dict_Q.Add("綿あめ:2-5", new Question("綿あめ返答4"));
        Dict_Q.Add("綿あめ:2-6", new Question("綿あめ返答5"));

        Dict_Q.Add("綿あめ:3", new Question("世間話"));
        Dict_Q.Add("綿あめ:3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("綿あめ:3-2", new Question("綿あめ返答6"));
        Dict_Q.Add("綿あめ:3-3", new Question("綿あめ返答7"));
        Dict_Q.Add("綿あめ:3-4", new Question("嫌いなことの選択肢"));
        Dict_Q.Add("綿あめ:3-5", new Question("綿あめ返答8"));
        Dict_Q.Add("綿あめ:3-6", new Question("綿あめ返答9"));

        Dict_Q.Add("綿あめ会話:1", new Question("好きなこと"));
        Dict_Q.Add("綿あめ会話:2", new Question("嫌いなこと"));
        Dict_Q.Add("綿あめ会話:3", new Question("趣味"));
        Dict_Q.Add("綿あめ会話:4", new Question("焼き鳥屋店主について"));
        Dict_Q.Add("綿あめ会話:5", new Question("悩み"));
    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load()
    {
        //お面屋
        Dict_Q["お面:挨拶"].Talks.Add("お疲れ様～");
        Dict_Q["お面:挨拶"].Next_Question = Dict_Q["1"];

        Dict_Q["1"].Anss.Add(new Reply("要件", "何か御用かしら？", Dict_Q["2"]));
        Dict_Q["1"].Anss.Add(new Reply("世間話", "お話？いいわよ", Dict_Q["3"]));
        Dict_Q["1"].Anss.Add(new Reply("特になし", "あら、何もないの？さみしいわ", 0));

        Dict_Q["2"].Anss.Add(new Reply("丁寧", "わかったわ～任せて頂戴", -1));
        Dict_Q["2"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["2"].Anss.Add(new Reply("雑", "それはちょっと嫌ね", Dict_Q["2-4"]));

        Dict_Q["2-4"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["2-4"].Anss.Add(new Reply("丁寧", "…まぁいいわよ", +1));

        Dict_Q["3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["会話1"]));
        
        Dict_Q["3"].Anss.Add(new Reply("Hate", "嫌いなこととかありますか？", Dict_Q["会話2"]));
        Dict_Q["3"].Anss.Add(new Reply("Who", "あなたは一体何者ですか…？", Dict_Q["会話3"]));
        Dict_Q["3"].Anss.Add(new Reply("Why", "なぜお面屋のボランティアを？", Dict_Q["会話4"]));
        Dict_Q["3"].Anss.Add(new Reply("Interview", "お祭りへの意気込みをお願いします！", Dict_Q["会話5"]));

        Dict_Q["3-1"].Anss.Add(new Reply("漫画ですか！？少し意外です", "あら、そう？最近は面白いものがたくさんあるから、読み飽きないし面白いわよ？",-2));
        Dict_Q["3-1"].Anss.Add(new Reply("おすすめとかあります？", "そうね…スポーツ系統の漫画はジャンルが多くておすすめね。",-2));

        Dict_Q["3-2"].Anss.Add(new Reply("あれ？金魚すくいありますけど…", "正直少し苦手ね…祭りということで妥協しているけれど…少しあのおじさまには気を使ってもらっているから申し訳ないわね。",-2));
        Dict_Q["3-2"].Anss.Add(new Reply("不気味な感じというと？", "あのギョロっとした目つきが特にゾッとするわ…もうこの話は終わりにしましょｗ", -2));

        Dict_Q["3-3"].Anss.Add(new Reply("気になります！", "ふふｗ見せたくないってわけではないけど、知らない方がいいわよ～後悔しちゃうから...",-2));
        Dict_Q["3-3"].Anss.Add(new Reply("そんなに気にならないかも", "あらそう？でもあんまりほかの方にそういうこといわない方がいいわよ、かき氷のお兄さん優しいけど、まじめだからしっかりね",-2));
        Dict_Q["3-3"].Talks.Add("(やっぱり少し気になるなぁ…)");

        Dict_Q["会話1"].Talks.Add("読書かしらね、最近は漫画をよく読むのよ");
        Dict_Q["会話1"].Talks.Add("漫画ですか！？少し意外です");
        Dict_Q["会話1"].Next_Question = Dict_Q["3-1"];

        Dict_Q["会話2"].Talks.Add("お魚が少し苦手ね…なんかこう不気味な感じがするわ。");
        Dict_Q["会話2"].Next_Question = Dict_Q["3-2"];

        Dict_Q["会話3"].Talks.Add("不思議な質問ねｗこの仮面の下が気になるの？");
        Dict_Q["会話3"].Next_Question = Dict_Q["3-3"];

        Dict_Q["会話4"].Talks.Add("昔からお面が好きだったからかしら？子供の頃お祭りでよくつけていたのよね");
        Dict_Q["会話4"].Talks.Add("今もつけてますもんね");
        Dict_Q["会話4"].Talks.Add("そうなの！祭りが地元であるここでやるって聞いてやりたかったのよね～");
        Dict_Q["会話4"].Talks.Add("なるほど…では好きなお面は付けているその狐のお面ですか？");
        Dict_Q["会話4"].Talks.Add("そうね…他のもいいけれどやっぱり狐ね～一番しっくりくるのよ");

        Dict_Q["会話5"].Talks.Add("そうね…やっぱりたくさんの方にお祭りを楽しんでもらいたいわ");
        Dict_Q["会話5"].Talks.Add("なるほど…");
        Dict_Q["会話5"].Talks.Add("私もお祭りは好きだからね～そのために頑張らないとね");
        Dict_Q["会話5"].Talks.Add("一緒に頑張りましょう！");
        Dict_Q["会話5"].Talks.Add("もちろん～頑張りましょ～");

        //綿あめ屋
        Dict_Q["綿あめ:挨拶"].Anss.Add(new Reply("挨拶", "どうも。お疲れ様です。", Dict_Q["綿あめ:1"]));

        Dict_Q["綿あめ:1"].Anss.Add(new Reply("要件", "何か用事があるんですか？", Dict_Q["綿あめ:2"]));
        Dict_Q["綿あめ:1"].Anss.Add(new Reply("世間話", "世間話ですか？", Dict_Q["綿あめ:3"]));
        Dict_Q["綿あめ:1"].Anss.Add(new Reply("特になし", "わかりました。", 0));

        Dict_Q["綿あめ:2"].Anss.Add(new Reply("雑", "頼みたいことがあるんだけどいい！？", Dict_Q["綿あめ:2-1"]));
        Dict_Q["綿あめ:2"].Anss.Add(new Reply("一般", "お願いがあるんです！聞いてくれませんか！？", Dict_Q["綿あめ:2-2"]));
        Dict_Q["綿あめ:2"].Anss.Add(new Reply("丁寧", "恐縮ながら頼みたい事がありまして...", Dict_Q["綿あめ:2-3"]));

        Dict_Q["綿あめ:2-1"].Anss.Add(new Reply("", "いいですよ。喜んでやりましょう！",+1));
        Dict_Q["綿あめ:2-2"].Anss.Add(new Reply("", "分かりました。手伝います。", 0));
        Dict_Q["綿あめ:2-3"].Anss.Add(new Reply("", "うーーん...", Dict_Q["綿あめ:2-4"]));

        Dict_Q["綿あめ:2-4"].Anss.Add(new Reply("一般", "聞いてもらえませんか...？", Dict_Q["綿あめ:2-5"]));
        Dict_Q["綿あめ:2-4"].Anss.Add(new Reply("丁寧", "お忙しい中大変だと思うのですが...", Dict_Q["綿あめ:2-6"]));

        Dict_Q["綿あめ:2-5"].Anss.Add(new Reply("", "分かりました", 0));
        Dict_Q["綿あめ:2-6"].Anss.Add(new Reply("", "まぁできなくもないです。", -1));

        Dict_Q["綿あめ:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["綿あめ会話:1"]));
        Dict_Q["綿あめ:3"].Anss.Add(new Reply("Hate", "嫌いなことは？", Dict_Q["綿あめ会話:2"]));
        Dict_Q["綿あめ:3"].Anss.Add(new Reply("Hobby", "趣味は？", Dict_Q["綿あめ会話:3"]));
        Dict_Q["綿あめ:3"].Anss.Add(new Reply("Friends", "焼き鳥屋店主と仲が良いんですか？", Dict_Q["綿あめ会話:4"]));
        Dict_Q["綿あめ:3"].Anss.Add(new Reply("Worries", "悩みはありますか？", Dict_Q["綿あめ会話:5"]));

        Dict_Q["綿あめ:3-1"].Anss.Add(new Reply("敬語", "今後も遠慮なく話しかけさせてもらいます", Dict_Q["綿あめ:3-2"]));
        Dict_Q["綿あめ:3-1"].Anss.Add(new Reply("一般", "これからはラフな感じで話しかけるよ", Dict_Q["綿あめ:3-3"]));

        Dict_Q["綿あめ:3-2"].Anss.Add(new Reply("", "ああ、敬語でなくて結構ですよ...", -2));
        Dict_Q["綿あめ:3-3"].Anss.Add(new Reply("", "やはり敬語でない方が親しみやすくていいですね", -2));

        Dict_Q["綿あめ:3-4"].Anss.Add(new Reply("一般", "これからは僕が積極的に話しかけるよ！", Dict_Q["綿あめ:3-5"]));
        Dict_Q["綿あめ:3-4"].Anss.Add(new Reply("敬語", "会話って難しいですよね。同感です。", Dict_Q["綿あめ:3-6"]));

        Dict_Q["綿あめ:3-5"].Anss.Add(new Reply("", "本当ですか？正直助かります", -2));
        Dict_Q["綿あめ:3-6"].Anss.Add(new Reply("", "そうですね。相手から積極的に距離を詰めてもらえると楽でいいのですが。", -2));

        Dict_Q["綿あめ会話:1"].Talks.Add("案外会話は好きですね");
        Dict_Q["綿あめ会話:1"].Talks.Add("意外ですね！");
        Dict_Q["綿あめ会話:1"].Talks.Add("気兼ねなく話しかけて下さい");
        Dict_Q["綿あめ会話:1"].Next_Question = Dict_Q["綿あめ:3-1"];

        Dict_Q["綿あめ会話:2"].Talks.Add("嫌いというか、苦手なものはあります。");
        Dict_Q["綿あめ会話:2"].Talks.Add("何が苦手なんですか？");
        Dict_Q["綿あめ会話:2"].Talks.Add("人との距離を縮めるのが苦手で...。会話は好きなのですが。");
        Dict_Q["綿あめ会話:2"].Next_Question = Dict_Q["綿あめ:3-4"];

        Dict_Q["綿あめ会話:3"].Talks.Add("お菓子作りが好きですね");
        Dict_Q["綿あめ会話:3"].Talks.Add("なるほど。お菓子が好きなんですか？");
        Dict_Q["綿あめ会話:3"].Talks.Add("好きですね。お祭りの綿あめとか好きです");

        Dict_Q["綿あめ会話:4"].Talks.Add("結構仲は良いですね...！");
        Dict_Q["綿あめ会話:4"].Talks.Add("相性が良いのかもしれないですね");
        Dict_Q["綿あめ会話:4"].Talks.Add("敬語は距離を感じるので苦手なんです。敬語を使わない彼の遠慮のなさが逆に良いですね。");

        Dict_Q["綿あめ会話:5"].Talks.Add("縁日で屋台の手伝いをお願いしたいのですが...");
        Dict_Q["綿あめ会話:5"].Talks.Add("大歓迎です！どんな手伝いがしたいんですか？");
        Dict_Q["綿あめ会話:5"].Talks.Add("甘い物を作る屋台などがあれば、手伝いたいですね。");
    }
    /// <summary>
    /// ゲーム内の全てのタスクをここで定義する 
    /// </summary>
    private static void Task_Load()
    {
        All_Tasks = new Dictionary<string, Task>();
        
        //例タスクはプログラム内で使う文字列同名だと上書きされる　最後はタスクの作業量
        All_Tasks["お面"] = new Task("お面", "お面を50個作ろう", 50);
        All_Tasks["綿あめ"] = new Task("綿あめ","ザラメを2000g用意しよう",2000);

        
        All_Tasks["お面"].Add_ReWard(new int[]{10,25,50});
        All_Tasks["綿あめ"].Add_ReWard(new int[]{500,1000,2000});
        All_Tasks["金魚"].Add_ReWard(new int[]{25,50,100});
        All_Tasks["射的"].Add_ReWard(new int[]{2,5,10});
        All_Tasks["かき氷"].Add_ReWard(new int[]{25,50,100});
        All_Tasks["焼き鳥"].Add_ReWard(new int[]{25,50,100});
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
    private int[] ReWards;
    public Task(string name, string expl, int count)
    {
        Name = name;
        Explanation = expl;
        _Num = 0;
        Content_Num_Max = count;
    }
    public void Add_ReWard(int[] i_s){
        ReWards = i_s;
    }
    public void Add_ReWard(int i){
        if(Task_Clear())return;
        if(ReWards.Length <= 0&&ReWards.Length <= i)return;
        _Num += ReWards[i];
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