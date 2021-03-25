using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;
using System.Data;
using System.IO;

public class ArmyController : MonoBehaviour
{




    
    List<Piece> army = new List<Piece>();
    bool deployed;

    Dictionary<Piece.unitClass, int> deployLimit = new Dictionary<Piece.unitClass, int>(){
        {Piece.unitClass.pawn, 8},
        {Piece.unitClass.rook, 2},
        {Piece.unitClass.bishop, 2},
        {Piece.unitClass.knight, 2},
        {Piece.unitClass.queen, 1},
        {Piece.unitClass.king, 1}
    };

    public Piece p;

    // Start is called before the first frame update
    void Start()
    {
        DataService ds = new DataService("defaultStats.db");
        ds.createDB();

		/*ds.insertAll (new[]{
			new defaultStats{
                unit = "pawn",
                baseStr = 2,
                baseSpd = 1,
                baseSkl = 3,
                baseLck = 5,
                baseCon = 3,
                strGrowth = 60,
                spdGrowth = 30,
                sklGrowth = 60,
                lckGrowth = 70,
                conGrowth = 20,
                
			},
			new defaultStats{
                unit = "rook",
                baseStr = 7,
                baseSpd = 4,
                baseSkl = 8,
                baseLck = 2,
                baseCon = 8,
                strGrowth = 30,
                spdGrowth = 70,
                sklGrowth = 30,
                lckGrowth = 50,
                conGrowth = 10,
                
			},
			new defaultStats{
                unit = "bishop",
                baseStr = 6,
                baseSpd = 4,
                baseSkl = 10,
                baseLck = 2,
                baseCon = 6,
                strGrowth = 30,
                spdGrowth = 70,
                sklGrowth = 10,
                lckGrowth = 50,
                conGrowth = 20,
                
			},
			new defaultStats{
                unit = "knight",
                baseStr = 9,
                baseSpd = 3,
                baseSkl = 6,
                baseLck = 2,
                baseCon = 9,
                strGrowth = 40,
                spdGrowth = 20,
                sklGrowth = 60,
                lckGrowth = 40,
                conGrowth = 40,
                
			},
            new defaultStats{
                unit = "queen",
                baseStr = 12,
                baseSpd = 10,
                baseSkl = 9,
                baseLck = 8,
                baseCon = 11,
                strGrowth = 15,
                spdGrowth = 20,
                sklGrowth = 20,
                lckGrowth = 30,
                conGrowth = 10,
                
			},
            new defaultStats{
                unit = "king",
                baseStr = 13,
                baseSpd = 1,
                baseSkl = 13,
                baseLck = 1,
                baseCon = 8,
                strGrowth = 30,
                spdGrowth = 30,
                sklGrowth = 30,
                lckGrowth = 30,
                conGrowth = 30,
                
			},
		});
        */

        print(ds.GetDefaultStatsForUnit("pawn"));
        createArmy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Vector3 getGridLocation(Vector2Int coords){
        
    //     GameObject board = GameObject.Find("Board");
    //     Vector3 origin = new Vector3();
    //     if(board == null)
    //     {
    //         Debug.LogError("null board");
    //     }
    //     Grid tmap = board.GetComponent<Grid>();
    //     origin = tmap.GetCellCenterWorld(new Vector3Int(coords.x, coords.y, 1));
    //     return origin;
    // }

    void createArmy()
    {   
        Piece clone;
        Piece.unitClass pieceType = Piece.unitClass.pawn;
        //Loop that creates pawns
        for (int x = 0; x < 8; x++){
            clone = Instantiate(p);
            clone.initializePiece();
            clone.createPiece(pieceType, new Vector2Int(x, 1));
            clone.transform.SetParent(this.transform);
            army.Add(clone);
            // print("pawn created: " + p);
        }

        //Create rooks
        pieceType = Piece.unitClass.rook;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(0, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        pieceType = Piece.unitClass.rook;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(7, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        //Create bishops
        pieceType = Piece.unitClass.bishop;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(1, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        pieceType = Piece.unitClass.bishop;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(6, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        //Create knights
        pieceType = Piece.unitClass.knight;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(2, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        pieceType = Piece.unitClass.knight;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(5, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        //Create king and queen
        pieceType = Piece.unitClass.king;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(3, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

        pieceType = Piece.unitClass.queen;
        clone = Instantiate(p);
        clone.initializePiece();
        clone.createPiece(pieceType, new Vector2Int(4, 0));
        clone.transform.SetParent(this.transform);
        army.Add(clone);

    }

}
