using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{

    int strStat;
    int spdStat;
    int sklStat;
    int lckStat;
    int conStat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateStat(int val, string stat){
        switch(stat){
            case "str":
                strStat = val;
                break;
            case "spd":
                spdStat = val;
                break;
            case "skl":
                sklStat = val;
                break;
            case "lck":
                lckStat = val;
                break;
            case "con":
                conStat = val;
                break;
        }
    }
}