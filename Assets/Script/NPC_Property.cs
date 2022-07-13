using System.Collections;
using System.Collections.Generic;


/// <summary>
///　全NPCにくっつくクラス
/// NPCの目的座標や目的
/// 感情：性格などのパラメータを保持する
/// </summary>
public class NPC_Property
{
    //移動時に使用されるターゲット座標
    public (int x,int y)target_point;
    //現在の座標
    public (int x,int y)now_point;
    
    public string Character = "";

    //不満度float:(0~1)*100でパーセント
    private float _complain = 0; 
    public float Complain{
        get{
            return _complain;
        }
        set{
            _complain = (value > 1)?1:value;
            _complain = (value < 0)?0:value;
        }
    }
    //NPCの感情
    public NPC_Emotions _emotion;
    //NPCの内部パラメータ
    public NPC_Parameters _parameters = new NPC_Parameters(10,2,4,5,6,7);
    
}

public class NPC_Parameters{
    //パラメータの最大値
    private static int Max_int = 0;
    private int _speed = 0;
    private int _stamina = 0;
    private int _power = 0;
    private int _intelligence = 0;
    private int _resistance = 0;

    /// <summary>速さ</summary>
    public int Speed{get{return _speed;}set{_speed = fit_Within_MAX(value);}}

    /// <summary>スタミナ</summary>
    public int Stamina{get{return _stamina;}set{_stamina = fit_Within_MAX(value);}}

    /// <summary>力</summary>
    public int Power{get{return _power;}set{_power = fit_Within_MAX(value);}}

    /// <summary>賢さ</summary>
    public int Intelligence{get{return _intelligence;}set{_intelligence = fit_Within_MAX(value);}}

    /// <summary>耐性</summary>
    public int Resistance{get{return _resistance;}set{_resistance = fit_Within_MAX(value);}}

    /// <summary>
    /// 初期パラメータ : 最大値・速さ・体力・賢さ・耐性
    /// </summary>
    /// <param name="M">パラメータの最大値</param>
    /// <param name="S">速さ</param>
    /// <param name="ST">体力</param>
    /// <param name="P">力</param>
    /// <param name="I">賢さ</param>
    /// <param name="R">耐性</param>
    public NPC_Parameters(int M,int S,int ST,int P,int I,int R){
        Max_int = M;
        Speed = S;
        Stamina = ST;
        Power = P;
        Intelligence = I;
        Resistance = R;
    }
    /// <summary>
    /// 0~最大値以内にintで収める
    /// </summary>
    /// <param name="i">おさまっているか確認したい値</param>
    /// <returns>0~最大値いないなら引数が返る</returns>
    private static int fit_Within_MAX(int i){
        int re_float =0;
        re_float = (i > Max_int)?Max_int:i;
        re_float = (i < 0)?0:i;
        return re_float;
    }
}

/// <summary>
/// NPCの感情を表すクラス
/// </summary>
public class NPC_Emotions{
    // クラス内で利用する内部感情
    private Dictionary <string,float> _emotion= new Dictionary<string, float>(){
        {"嬉",0f},
        {"怒",0f},
        {"哀",0f},
        {"楽",0f},
    };
    //クラス外で感情別に値を取得・セットする際に使用する
    public float Happy{ get{return _emotion["喜"];} set{_emotion["喜"] = fit_Within_1(value);}}
    public float Angry{ get{return _emotion["怒"];} set{_emotion["怒"] = fit_Within_1(value);}}
    public float Sorrow{ get{return _emotion["哀"];} set{_emotion["哀"] = fit_Within_1(value);}}
    public float Fun{ get{return _emotion["楽"];} set{_emotion["楽"] = fit_Within_1(value);}}

    /// <summary>
    /// 0~1以内にfloatで収める
    /// </summary>
    /// <param name="f">おさまっているか確認したい値</param>
    /// <returns>0~1いないなら引数が返る</returns>
    private static float fit_Within_1(float f){
        float re_float =0;
        re_float = (f > 1)?1:f;
        re_float = (f < 0)?0:f;
        return re_float;
    }
    /// <summary>
    /// 現在最も値が高い感情名を返す
    /// </summary>
    /// <returns>string:喜|怒|哀|楽</returns>
    public string Top_Largest_Emotion(){
        string top_string = "";
        foreach(var c in _emotion){
            if(top_string == ""||_emotion[top_string] < c.Value)top_string = c.Key;
        }
        return top_string;
    }
}
