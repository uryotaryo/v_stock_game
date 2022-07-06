using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
public class Real_Time_Cont : MonoBehaviour
{
    [SerializeField]
    private float Max_Time;
    [SerializeField]
    private Slider Timer_Bar;
    [SerializeField]
    private Slider BatLevel_Bar;
    // Start is called before the first frame update
    void Start()
    {
        timer_set();
    }
    private void timer_set(){
        Timer_Bar.maxValue = Max_Time;
        Timer_Bar.value = Max_Time;

    }
    // Update is called once per frame
    void Update()
    {
        Timer_Bar.value -= Time.deltaTime;
    }
}
