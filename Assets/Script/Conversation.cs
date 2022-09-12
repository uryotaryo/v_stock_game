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

        //金魚
        Dict_Q.Add("金魚:挨拶", new Question("お疲れ様です～"));

        Dict_Q.Add("金魚:1", new Question("プレイヤー行動選択肢"));

        Dict_Q.Add("金魚:2", new Question("金魚を仕入れてもらいたい"));
        Dict_Q.Add("金魚:2-1", new Question("(もう一度頼もう)"));

        Dict_Q.Add("金魚:3", new Question("世間話"));
        Dict_Q.Add("金魚:3-1", new Question("好きなことの選択肢"));
        Dict_Q.Add("金魚:3-2", new Question("趣味の選択肢"));

        Dict_Q.Add("金魚:会話1", new Question("好きなこと"));
        Dict_Q.Add("金魚:会話2", new Question("嫌いなこと"));
        Dict_Q.Add("金魚:会話3", new Question("趣味"));
        Dict_Q.Add("金魚:会話4", new Question("金魚のコツ"));
        Dict_Q.Add("金魚:会話5", new Question("お祭りへの意気込み"));

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


        
       //共通タスク
        Dict_Q.Add("共通:挨拶", new Question("こんにちは"));

        Dict_Q.Add("共通:1", new Question("プレイヤー行動選択肢"));

        Dict_Q.Add("共通:2", new Question("お面を作ってもらいたい"));
        Dict_Q.Add("共通:2-1", new Question("要件選択後後の返事"));

        Dict_Q.Add("共通:3", new Question("世間話"));

        Dict_Q.Add("共通会話0", new Question("ボランティアを集めた後の会話"));
        Dict_Q.Add("共通会話1", new Question("ボランティアについて"));
        Dict_Q.Add("共通会話2", new Question("意気込み"));
        Dict_Q.Add("共通会話3", new Question("やるべきこと"));
        
        //Dict_Q.Add("金魚:共通", new Question("お疲れ様です～"));
        //Dict_Q.Add("金魚:1-1", new Question("丁寧のプレイヤーの返し"));
        //Dict_Q.Add("金魚:1-2", new Question("雑のプレイヤーの返し"));
    }
    /// <summary>
    /// 質問に紐づけされる解答一覧(N)
    /// </summary>
    private static void Reply_Load()
    {
        //お面屋
        Dict_Q["お面:挨拶"].Anss.Add(new Reply("挨拶", "お疲れ様～", Dict_Q["お面:1"]));

        Dict_Q["お面:1"].Anss.Add(new Reply("要件", "何か御用かしら？", Dict_Q["お面:2"]));
        Dict_Q["お面:1"].Anss.Add(new Reply("世間話", "お話？いいわよ", Dict_Q["お面:3"]));
        Dict_Q["お面:1"].Anss.Add(new Reply("特になし", "あら、そう。", 0));

        Dict_Q["お面:2"].Anss.Add(new Reply("丁寧", "わかったわ～任せて頂戴", -1));
        Dict_Q["お面:2"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["お面:2"].Anss.Add(new Reply("雑", "それはちょっと嫌ね", Dict_Q["お面:2-1"]));

        Dict_Q["お面:2-1"].Anss.Add(new Reply("一般", "OK～やってくるわ", 0));
        Dict_Q["お面:2-1"].Anss.Add(new Reply("雑", "…まぁいいわよ", +1));

        Dict_Q["お面:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["お面:会話1"]));
        Dict_Q["お面:3"].Anss.Add(new Reply("Hate", "嫌いなこととかありますか？", Dict_Q["お面:会話2"]));
        Dict_Q["お面:3"].Anss.Add(new Reply("Who", "あなたは一体何者ですか…？", Dict_Q["お面:会話3"]));
        Dict_Q["お面:3"].Anss.Add(new Reply("Why", "なぜお面屋のボランティアを？", Dict_Q["お面:会話4"]));
        Dict_Q["お面:3"].Anss.Add(new Reply("Interview", "お祭りへの意気込みをお願いします！", Dict_Q["お面:会話5"]));

        Dict_Q["お面:3-1"].Anss.Add(new Reply("意外です", "最近は面白いものがたくさんあるから、読み飽きないし面白いわよ？", -2));
        Dict_Q["お面:3-1"].Anss.Add(new Reply("おすすめを聞く", "そうね…スポーツ系統の漫画はジャンルが多くておすすめね。", -2));

        Dict_Q["お面:3-2"].Anss.Add(new Reply("金魚は？", "正直少し苦手ね…祭りということで妥協しているけれど…", -2));//長い
        Dict_Q["お面:3-2"].Anss.Add(new Reply("不気味な感じ？", "あのギョロっとした目つきが特にゾッとするわ…もうこの話は終わりにしましょ…", -2));

        Dict_Q["お面:3-3"].Anss.Add(new Reply("気になる", "ふふ笑　見せたくないってわけではないけど、知らない方がいいわよ～後悔しちゃうから...", -2));
        Dict_Q["お面:3-3"].Anss.Add(new Reply("気にならない", "あまり聞かない方がいいわよ？かき氷のお兄さんとか、まじめだからしっかりね", -2));//長い
        Dict_Q["お面:3-3"].Talks.Add("(やはり少し気になるなぁ…)");

        Dict_Q["お面:会話1"].Talks.Add("読書かしらね、最近は漫画をよく読むのよ");
        Dict_Q["お面:会話1"].Next_Question = Dict_Q["お面:3-1"];

        Dict_Q["お面:会話2"].Talks.Add("お魚が少し苦手ね…なんかこう不気味な感じがするわ。");
        Dict_Q["お面:会話2"].Next_Question = Dict_Q["お面:3-2"];

        Dict_Q["お面:会話3"].Talks.Add("不思議な質問ねｗこの仮面の下が気になるの？");
        Dict_Q["お面:会話3"].Next_Question = Dict_Q["お面:3-3"];

        Dict_Q["お面:会話4"].Talks.Add("昔からお面が好きだったからかしら？子供の頃お祭りでよくつけていたのよね");
        Dict_Q["お面:会話4"].Talks.Add("今もつけてますもんね");
        Dict_Q["お面:会話4"].Talks.Add("そうなの！祭りが地元であるここでやるって聞いてやりたかったのよね～");
        Dict_Q["お面:会話4"].Talks.Add("なるほど…では好きなお面は付けているその狐のお面ですか？");
        Dict_Q["お面:会話4"].Talks.Add("そうね…他のもいいけれどやっぱり狐ね～一番しっくりくるのよ");

        Dict_Q["お面:会話5"].Talks.Add("そうね…やっぱりたくさんの方にお祭りを楽しんでもらいたいわ");
        Dict_Q["お面:会話5"].Talks.Add("なるほど…");
        Dict_Q["お面:会話5"].Talks.Add("私もお祭りは好きだからね～そのために頑張らないとね");

        //綿あめ屋
        Dict_Q["綿あめ:挨拶"].Anss.Add(new Reply("挨拶", "どうも。お疲れ様です。", Dict_Q["綿あめ:1"]));

        Dict_Q["綿あめ:1"].Anss.Add(new Reply("要件", "何か用事があるんですか？", Dict_Q["綿あめ:2"]));
        Dict_Q["綿あめ:1"].Anss.Add(new Reply("世間話", "世間話ですか？", Dict_Q["綿あめ:3"]));
        Dict_Q["綿あめ:1"].Anss.Add(new Reply("特になし", "わかりました。", -2));

        Dict_Q["綿あめ:2"].Anss.Add(new Reply("雑", "頼みたいことがあるんだけどいい！？", Dict_Q["綿あめ:2-1"]));
        Dict_Q["綿あめ:2"].Anss.Add(new Reply("一般", "お願いがあるんです！聞いてくれませんか！？", Dict_Q["綿あめ:2-2"]));
        Dict_Q["綿あめ:2"].Anss.Add(new Reply("丁寧", "恐縮ながら頼みたい事がありまして...", Dict_Q["綿あめ:2-3"]));

        Dict_Q["綿あめ:2-1"].Anss.Add(new Reply("", "いいですよ。喜んでやりましょう！",-1));
        Dict_Q["綿あめ:2-2"].Anss.Add(new Reply("", "分かりました。手伝います。", 0));
        Dict_Q["綿あめ:2-3"].Anss.Add(new Reply("", "うーーん...", Dict_Q["綿あめ:2-4"]));

        Dict_Q["綿あめ:2-4"].Anss.Add(new Reply("一般", "聞いてもらえませんか...？", Dict_Q["綿あめ:2-5"]));
        Dict_Q["綿あめ:2-4"].Anss.Add(new Reply("丁寧", "お忙しい中大変だと思うのですが...", Dict_Q["綿あめ:2-6"]));

        Dict_Q["綿あめ:2-5"].Anss.Add(new Reply("", "分かりました", 0));
        Dict_Q["綿あめ:2-6"].Anss.Add(new Reply("", "まぁできなくもないです。", +1));

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

        //金魚
        Dict_Q["金魚:挨拶"].Anss.Add(new Reply("挨拶", "お疲れ～", Dict_Q["金魚:1"]));

        Dict_Q["金魚:1"].Anss.Add(new Reply("要件", "何か用かな？", Dict_Q["金魚:2"]));
        Dict_Q["金魚:1"].Anss.Add(new Reply("世間話", "世間話ですか？いいですね", Dict_Q["金魚:3"]));
        Dict_Q["金魚:1"].Anss.Add(new Reply("特になし", "あ、そう？", 0));

        Dict_Q["金魚:2"].Anss.Add(new Reply("丁寧", "大丈夫だよ、任せてください", -1));
        Dict_Q["金魚:2"].Anss.Add(new Reply("一般", "OKです。やってきますね", 0));
        Dict_Q["金魚:2"].Anss.Add(new Reply("雑", "それはちょっと…", Dict_Q["金魚:2-1"]));

        Dict_Q["金魚:2-1"].Anss.Add(new Reply("一般", "OKです。やってきますね", 0));
        Dict_Q["金魚:2-1"].Anss.Add(new Reply("雑", "うーん、まあいいですけど", +1));

        Dict_Q["金魚:3"].Anss.Add(new Reply("Like", "好きなことは何ですか？", Dict_Q["金魚:会話1"]));
        Dict_Q["金魚:3"].Anss.Add(new Reply("Hate", "嫌いなこととかありますか？", Dict_Q["金魚:会話2"]));
        Dict_Q["金魚:3"].Anss.Add(new Reply("hobby", "趣味はありますか", Dict_Q["金魚:会話3"]));
        Dict_Q["金魚:3"].Anss.Add(new Reply("point", "金魚のコツは？", Dict_Q["金魚:会話4"]));
        Dict_Q["金魚:3"].Anss.Add(new Reply("Interview", "お祭りへの意気込みをお願いします！", Dict_Q["金魚:会話5"]));
        
        Dict_Q["金魚:3-1"].Anss.Add(new Reply("いいですよね", "わかる～見てると癒されるんだよね", -2));
        Dict_Q["金魚:3-1"].Anss.Add(new Reply("ほかの方はどうだろう？", "どうなんだろう？お面の方は狐が好きそうだね笑", -2));

        Dict_Q["金魚:3-2"].Anss.Add(new Reply("読んでみます", "ぜひ感想教えてね", -2));
        Dict_Q["金魚:3-2"].Anss.Add(new Reply("活字苦手…", "そういえば、お面の方も読書好きだったはず。何かおすすめの本を教えてくれるかも", -2));//長い

        Dict_Q["金魚:会話1"].Talks.Add("動物を育てることかな");
        Dict_Q["金魚:会話1"].Next_Question = Dict_Q["金魚:3-1"];

        Dict_Q["金魚:会話2"].Talks.Add("少し騒がしいところが苦手かな");
        Dict_Q["金魚:会話2"].Talks.Add("なるほど…");
        Dict_Q["金魚:会話2"].Talks.Add("祭りとかはいいんだけど、どうも気分が乗らなくてね");
        Dict_Q["金魚:会話2"].Talks.Add("注意しておきます");
        Dict_Q["金魚:会話2"].Talks.Add("頼みます。焼き鳥の人とか少し苦手…");

        Dict_Q["金魚:会話3"].Talks.Add("小説を読むのが好きだね。");
        Dict_Q["金魚:会話3"].Talks.Add("どんなものが好き？");
        Dict_Q["金魚:会話3"].Talks.Add("謎解き系を読むかな。少し難しいけど面白いですよ");
        Dict_Q["金魚:会話3"].Next_Question = Dict_Q["金魚:3-2"];

        Dict_Q["金魚:会話4"].Talks.Add("あまり教えたくないのだけど…");
        Dict_Q["金魚:会話4"].Talks.Add("少しだけ教えてください");
        Dict_Q["金魚:会話4"].Talks.Add("しいて言えば壁際の水面近くの金魚なんかがねらい目だよ");
        Dict_Q["金魚:会話4"].Talks.Add("なるほど…");
        Dict_Q["金魚:会話4"].Talks.Add("あまり広めないでくださいね笑");

        Dict_Q["金魚:会話5"].Talks.Add("やっぱりたくさんの人に楽しんでほしいね");
        Dict_Q["金魚:会話5"].Talks.Add("そうですよね！");
        Dict_Q["金魚:会話5"].Talks.Add("そのためにあなたも頑張ってくれているから、こちらも頑張らないと");
        Dict_Q["金魚:会話5"].Talks.Add("ありがとうございます。絶対成功させましょう！");
        Dict_Q["金魚:会話5"].Talks.Add("頑張ろうね");

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

        //共通タスク
        Dict_Q["共通:挨拶"].Anss.Add(new Reply("挨拶", "お疲れ様～何用かな？", Dict_Q["共通:1"]));

        Dict_Q["共通:1"].Anss.Add(new Reply("要件", "OK!人手が足りないから、何人かボランティアの人を呼んできて頂戴ね", Dict_Q["共通:2"]));
        Dict_Q["共通:1"].Anss.Add(new Reply("世間話", "世間話かい？", Dict_Q["共通:3"]));
        Dict_Q["共通:1"].Anss.Add(new Reply("特になし", "そうかい", -2));

        //このセリフの後町長との会話がいったん終了して他NPCに話しかけに行く
        Dict_Q["共通:2"].Anss.Add(new Reply("", "了解です！", -2));

        //他NPCに話しかけた後の町長との会話
        Dict_Q["共通会話:0"].Talks.Add("集めてきました！");
        Dict_Q["共通会話:0"].Talks.Add("ありがとう！じゃあ取りに行ってくるね");
        Dict_Q["共通会話:0"].Next_Question = Dict_Q["共通:2-1"];
        Dict_Q["共通:2-1"].Anss.Add(new Reply("よろしくお願いします。", "任せておくれ", 0));
        Dict_Q["共通:2-1"].Anss.Add(new Reply("頼みます", "任せておくれ", 0));

        Dict_Q["共通:3"].Anss.Add(new Reply("volunteers", "ボランティアの人たちってどんな人？", Dict_Q["共通会話:1"]));
        Dict_Q["共通:3"].Anss.Add(new Reply("target", "お祭りへの意気込みはありますか？", Dict_Q["共通会話:2"]));
        Dict_Q["共通:3"].Anss.Add(new Reply("to do", "お祭りと言っても何から始めればいいですかね", Dict_Q["共通会話:3"]));

        Dict_Q["共通会話:1"].Talks.Add("私もあんまり話したことはないけれど、みんな個性的な人だよ");
        Dict_Q["共通会話:1"].Talks.Add("個性的ですかw");
        Dict_Q["共通会話:1"].Talks.Add("実際に本人たちと話してみなさい、そうしたら色んなことが分かるよ");
        Dict_Q["共通会話:1"].Talks.Add("分かりました！");
        Dict_Q["共通会話:1"].Talks.Add("頑張ってね～");

        Dict_Q["共通会話:2"].Talks.Add("このお祭りを成功させて町を活性化させたいね");
        Dict_Q["共通会話:2"].Talks.Add("かなり真面目な回答ですねw");
        Dict_Q["共通会話:2"].Talks.Add("まぁこれは建前で、実際は楽しんでもらえればいいかなw\n夏の良い思い出にしてほしいね");
        Dict_Q["共通会話:2"].Talks.Add("頑張りましょう！");
        Dict_Q["共通会話:2"].Talks.Add("うん、期待してるよ～");

        Dict_Q["共通会話:3"].Talks.Add("まずは屋台から作ろう。\n建材はこちらで用意できるから、欲しい時はいつでも言って");
        Dict_Q["共通会話:3"].Talks.Add("わかりました");
        Dict_Q["共通会話:3"].Talks.Add("その後はボランティアの人たちにそれぞれお店の商品や備品を用意してもらうのがいいと思うよ");
        Dict_Q["共通会話:3"].Talks.Add("なるほど、頑張ります！");
        Dict_Q["共通会話:3"].Talks.Add("分からないことがあったらいつでも相談してね");
        //共通タスクのやつ//
        /*
        //お面
        Dict_Q["お面:共通"].Anss.Add(new Reply("丁寧", "わかったわ～頑張るわね", Dict_Q["1-1"]));
        Dict_Q["お面:共通"].Anss.Add(new Reply("雑", "OK～", Dict_Q["1-2"]));
        Dict_Q["1-1"].Talks.Add("お願いします！");
        Dict_Q["1-2"].Talks.Add("任せる。頼むね～");
        */
        //金魚すくい
        //Dict_Q["金魚:共通"].Anss.Add(new Reply("丁寧", "大丈夫だよ～", Dict_Q["金魚:1-1"]));
        //Dict_Q["金魚:共通"].Anss.Add(new Reply("雑", "了解", Dict_Q["金魚:1-2"]));
        //Dict_Q["金魚:1-1"].Talks.Add("ありがとうございます！");
        //Dict_Q["金魚:1-2"].Talks.Add("ありがとう！頼むね");
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
        All_Tasks["金魚"] = new Task("金魚", "金魚を100匹発注しよう", 100);


        All_Tasks["共通1"] = new Task("共通1", "建材を用意しよう", 1);
        All_Tasks["共通2"] = new Task("共通2", "看板を豪華にしよう", 1);
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