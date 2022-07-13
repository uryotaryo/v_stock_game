using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complain : MonoBehaviour
{
    public int Human;//不満度の入れ物

    //不満度のグラフを入れている場所
    public GameObject Human0;
    public GameObject Human1;
    public GameObject Human2;
    public GameObject Human3;
    public GameObject Human4;
    public GameObject Human5;
    public GameObject Human6;
    public GameObject Human7;
    public GameObject Human8;
    public GameObject Human9;
    public GameObject Human10;

    // Start is called before the first frame update
    void Start()
    {
        Human = 0;//最初に不満度をゼロで始める
        Human0.SetActive(false);
        Human1.SetActive(false);
        Human2.SetActive(false);
        Human3.SetActive(false);
        Human4.SetActive(false);
        Human5.SetActive(false);
        Human6.SetActive(false);
        Human7.SetActive(false);
        Human8.SetActive(false);
        Human9.SetActive(false);
        Human10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Human == 0)//不満度がゼロなら対応した不満度グラフのみ表示する
        {
            Human0.SetActive(true);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 1)
        {
            Human1.SetActive(true);
            Human0.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 2)
        {
            Human2.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 3)
        {
            Human3.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 4)
        {
            Human4.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 5)
        {
            Human5.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 6)
        {
            Human6.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 7)
        {
            Human7.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 8)
        {
            Human8.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human9.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 9)
        {
            Human9.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human10.SetActive(false);
        }

        if (Human == 10)
        {
            Human10.SetActive(true);
            Human0.SetActive(false);
            Human1.SetActive(false);
            Human2.SetActive(false);
            Human3.SetActive(false);
            Human4.SetActive(false);
            Human5.SetActive(false);
            Human6.SetActive(false);
            Human7.SetActive(false);
            Human8.SetActive(false);
            Human9.SetActive(false);
        }
    }
}
