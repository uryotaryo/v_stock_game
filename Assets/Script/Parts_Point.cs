using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Point : MonoBehaviour
{
    public emort _NowEmort = emort.none;
    public enum emort{
        none = 0,
        angl = 1,
        hart = 2,
        ase = 3
    }
    public GameObject[] emort_obj;
    private void Start(){
        emort_All_Active_Set(false);
    }
    private void emort_All_Active_Set(bool b){
        foreach (var a in emort_obj){
            a.SetActive(b);
        }
    }
    public void Set_Emort(emort e){
        _NowEmort = e;
        emort_All_Active_Set(false);
        switch (_NowEmort)
        {
            case emort.none:
                break;
            case emort.angl:
                emort_obj[0].SetActive(true);
                break;
            case emort.hart:
                emort_obj[1].SetActive(true);
                break;
            case emort.ase:
                emort_obj[2].SetActive(true);
                break;
            default:
                break;
        }
    }
}