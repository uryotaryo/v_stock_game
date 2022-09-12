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
        Dict_Q.Add("綿あめ:1",new Question("どうも。お疲れ様です。"));

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

        //射的屋
        Dict_Q.Add("射的:挨拶", new Question("こんにちは"));

        Dict_Q.Add("射的:1", new Question("景品を集めてほしい"));

        Dict_Q.Add("射的:2", new Question("プレイヤー行動選択肢"));
        Dict_Q.Add("射的:2-1", new Question("射的返答1"));
        Dict_Q.Add("射的:2-2", new Question("射的返答2"));
        Dict_Q.Add("射的:2-3", new Question("射的返答3"));
        Dict_Q.Add("射的:2-4", new Question("(もう一度頼もう)"));
        Dict_Q.Add("射的:2-5", new Question("射的返答4"));
        Dict_Q.Add("射的:2-6", new Question("射的返答5"));

        Dict_Q.Add("射的:3", new Question("世間話"));
        Dict_Q.Add("射的:3-1", new Question("嫌いなことの選択肢"));
        Dict_Q.Add("射的:3-2", new Question("射的返答5"));
        Dict_Q.Add("射的:3-2", new Question("射的返答6"));

        Dict_Q.Add("射的:会話1", new Question("好きなこと"));
        Dict_Q.Add("射的:会話2", new Question("嫌いなこと"));
        Dict_Q.Add("射的:会話3", new Question("目標"));
        Dict_Q.Add("射的:会話4", new Question("お面屋店主について"));
        Dict_Q.Add("射的:会話5", new Question("旅行に行くなら"));

    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load()
    {
        //お面屋
        Dict_Q["挨拶"].Talks.Add("お疲れ様～");
        Dict_Q["挨拶"].Next_Question = Dict_Q["1"];

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

        Dict_Q["3-1"].Anss.Add(new Reply("これからはラフな感じで話しかけるよ", "やはり敬語でない方が親しみやすくていいですね", -2));
        Dict_Q["3-1"].Anss.Add(new Reply("今後も遠慮なく話しかけさせてもらいます", "ああ、敬語でなくて結構ですよ...", -2));

        Dict_Q["3-2"].Anss.Add(new Reply("これからは僕が積極的に話しかけるよ！", "本当ですか？正直助かります", -2));
        Dict_Q["3-2"].Anss.Add(new Reply("会話って難しいですよね。同感です。", "そうですね。相手から積極的に距離を詰めてもらえると楽でいいのですが。", -2));

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

        Dict_Q["会話4"].Talks.Add("結構仲は良いですね...!");
        Dict_Q["会話4"].Talks.Add("相性が良いのかもしれないですね");
        Dict_Q["会話4"].Talks.Add("敬語は距離を感じるので苦手なんです。敬語を使わない彼の遠慮のなさが逆に良いですね。");

        Dict_Q["会話5"].Talks.Add("縁日で屋台の手伝いをお願いしたいのですが...");
        Dict_Q["会話5"].Talks.Add("大歓迎です！どんな手伝いがしたいんですか？");
        Dict_Q["会話5"].Talks.Add("甘い物を作る屋台などがあれば、手伝いたいですね。");

        //射的屋
        Dict_Q["射的:挨拶"].Anss.Add(new Reply("挨拶", "こんにちは！何の用事ですか？", Dict_Q["射的:1"]));

        Dict_Q["射的:1"].Anss.Add(new Reply("要件", "何か用事があるんですか？", Dict_Q["射的:2"]));
        Dict_Q["射的:1"].Anss.Add(new Reply("世間話", "何か用事があるんですか？", Dict_Q["射的:3"]));
        Dict_Q["射的:1"].Anss.Add(new Reply("特になし", "了解です！", -2));

        Dict_Q["射的:2"].Anss.Add(new Reply("丁寧", "今お時間大丈夫ですか？", Dict_Q["射的:2-1"]));
        Dict_Q["射的:2"].Anss.Add(new Reply("一般", "頼みたいことがあります！", Dict_Q["射的:2-2"]));
        Dict_Q["射的:2"].Anss.Add(new Reply("雑", "今暇？ちょっといい？？", Dict_Q["射的:2-3"]));

        Dict_Q["射的:2-1"].Anss.Add(new Reply("", "大丈夫です！やりますよ", -1));
        Dict_Q["射的:2-2"].Anss.Add(new Reply("", "わかりました！", 0));
        Dict_Q["射的:2-3"].Anss.Add(new Reply("", "いいよー", Dict_Q["射的:2-4"]));

        Dict_Q["射的:2-4"].Anss.Add(new Reply("一般", "頼みたいことがあるんですよね", Dict_Q["射的:2-5"]));
        Dict_Q["射的:2-4"].Anss.Add(new Reply("雑", "ありがと！これやってもらえる？", Dict_Q["射的:2-6"]));

        Dict_Q["射的:2-5"].Anss.Add(new Reply("", "おっけー！", 0));
        Dict_Q["射的:2-6"].Anss.Add(new Reply("", "やっておくよ。", +1));

        Dict_Q["射的:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["射的:会話1"]));
        Dict_Q["射的:3"].Anss.Add(new Reply("Hate", "嫌いなことは何ですか？", Dict_Q["射的:会話2"]));
        Dict_Q["射的:3"].Anss.Add(new Reply("target", "目標はありますか？", Dict_Q["射的:会話3"]));
        Dict_Q["射的:3"].Anss.Add(new Reply("Friends", "お面屋店主ってミステリアスですよね？", Dict_Q["射的:会話4"]));
        Dict_Q["射的:3"].Anss.Add(new Reply("trip", "旅行に行きたい場所とかありますか？", Dict_Q["会話5"]));

        Dict_Q["射的:3-1"].Anss.Add(new Reply("丁寧", "承知しました", Dict_Q["射的:会話3-2"]));
        Dict_Q["射的:3-1"].Anss.Add(new Reply("一般", "これからは丁寧な言葉遣いを心がけていくよ", Dict_Q["射的:会話3-3"]));

        Dict_Q["射的:3-2"].Anss.Add(new Reply("", "別に今は大丈夫だよw\n仕事や作業中は丁寧な言葉遣いを心がけてほしいかも！", -2));
        Dict_Q["射的:3-3"].Anss.Add(new Reply("", "うん！それだとありがたいかも！", -2));

        Dict_Q["射的:会話1"].Talks.Add("楽しいこと、盛り上がることは好きですね！");
        Dict_Q["射的:会話1"].Talks.Add("じゃあお祭りも好きそうですね");
        Dict_Q["射的:会話1"].Talks.Add("結構好きです！楽しみです！");

        Dict_Q["射的:会話2"].Talks.Add("プライベートと仕事の切替が下手な人は苦手だったりするなぁ");
        Dict_Q["射的:会話2"].Talks.Add("なるほど、もっと具体的に何かありますか？");
        Dict_Q["射的:会話2"].Talks.Add("うーーん...。\n仕事や作業中は丁寧な言葉遣いを心がけてほしいかも！");
        Dict_Q["射的:会話2"].Next_Question = Dict_Q["射的:3-1"];

        Dict_Q["射的:会話3"].Talks.Add("強いて言うなら人を楽しませたいな！");
        Dict_Q["射的:会話3"].Talks.Add("良い目標ですね！");
        Dict_Q["射的:会話3"].Talks.Add("だよね！何かするならエンタメを選ぶ気がするなぁ");

        Dict_Q["射的:会話4"].Talks.Add("僕の知る限り、話せば割と普通の人だよ！");
        Dict_Q["射的:会話4"].Talks.Add("そうなんですね。\n顔が見えないので感情を読み取るのが難しいんです");
        Dict_Q["射的:会話4"].Talks.Add("崩しすぎず硬すぎず、普通の距離感で話せばいいんじゃないかな！\nきっと仲良くなれると思うよ！");

        Dict_Q["射的:会話5"].Talks.Add("銃を扱える国に行って銃を撃ってみたい！");
        Dict_Q["射的:会話5"].Talks.Add("銃を撃つのってどんな感じなんだあろう...");
        Dict_Q["射的:会話5"].Talks.Add("（詮索するのはやめておこう...）");

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
        All_Tasks["射的"] = new Task("射的", "射的の景品を10個用意しよう", 10);
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
    public Question Next_Question;
    public Question(string text)
    {
        Question_Text = text;
        Talks = new List<string>();
        Anss = new List<Reply>();
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