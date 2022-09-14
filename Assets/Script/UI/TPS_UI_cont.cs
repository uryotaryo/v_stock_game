using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_UI_cont : MonoBehaviour
{
    private int _Human_Level = 0;
    //不満度を示す値
    [SerializeField]
    public int Human_level{
        get{
            return _Human_Level;
        }
        set{
            if(Humans.Length > value&&value >= 0)_Human_Level = value;
            else if (value < 0)_Human_Level = 0;
            else _Human_Level = Humans.Length; 
            Set_Human();
        }
    }
    
    //不満度ゲージ用
    [SerializeField]
    private GameObject[] Humans;
    //不満度ゲージセット
    private void Set_Human(){
        for (int i = 0; i < Humans.Length;i ++){
            if(Human_level >= i)Humans[i].SetActive(true);
            else Humans[i].SetActive(false);
        }
    }
    void Start()
    {
        Set_Human();
    }
}
