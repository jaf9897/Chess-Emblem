using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class defaultStats
{
    [PrimaryKey]
    public string unit { get; set; }
    public int baseStr { get; set; }
    public int baseSpd { get; set; }
    public int baseSkl { get; set; }
    public int baseLck { get; set; }
    public int baseCon { get; set; }
    public int strGrowth { get; set; }
    public int spdGrowth { get; set; }
    public int sklGrowth { get; set; }
    public int lckGrowth { get; set; }
    public int conGrowth { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString ()
    {
        return string.Format ("[Unit: Type={0}", unit);
    }
}
