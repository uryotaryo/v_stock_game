using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static Vector3 VectorReturn(int x,int y){
        //TODO:配列番号に対しての３次元座標を返す
        return new Vector3(0,0,0);
    }
    public static (int,int)BoxPos_Move(int n_x,int n_y,int g_x,int g_y){
        int x_diff = diff(n_x,g_x);
        int y_diff = diff(n_y,g_y);
        if(x_diff == 0&& y_diff == 0)return(n_x,n_y);
        if(y_diff > x_diff||x_diff == 0)
        {
            return(n_x,n_y-1);
        }
        else return (n_x-1,n_y);
    }
    private static int diff(int s,int g){
        return (s - g) * (int)Mathf.Sign(s - g);
    }
}
