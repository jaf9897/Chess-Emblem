using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public enum unitClass{
        pawn,
        rook,
        bishop,
        knight, 
        queen,
        king
    }

    public Sprite pawnSprite;
    public Sprite rookSprite;
    public Sprite bishopSprite;
    public Sprite knightSprite;
    public Sprite queenSprite;
    public Sprite kingSprite;
    
    private int str;
    private int spd;
    private int skl;    
    private int lck;
    private int con;

    private float strGrowth;
    private float spdGrowth;
    private float sklGrowth;
    private float lckGrowth;
    private float conGrowth;
    

    private bool pawnFirstMove = false;
    private bool promoted = false;
    private bool captured = false;

    private unitClass currentClass;

    Board board;
    Grid grid;
    SpriteRenderer sr;


    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public unitClass getPieceClass(){
        return currentClass;
    }

    public void initializePiece(){
        board = GameObject.Find("Board").GetComponent<Board>();
        if(board == null)
            {
                Debug.LogError("null board");
            }
        grid = board.GetComponent<Grid>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void createPiece(unitClass cls, Vector2Int coords){
        Vector3 loc = new Vector3();
        loc = grid.GetCellCenterWorld(new Vector3Int(coords.x, coords.y, 1));
        transform.position = loc;
        switch (cls){
            case unitClass.pawn: 
            {
                sr.sprite = pawnSprite;
                currentClass = unitClass.pawn;
                pawnFirstMove = true;
                str = 2;
                spd = 1;
                lck = 5;
                skl = 3;
                con = 3;
                break;
            }
            case unitClass.rook: 
            {
                sr.sprite = rookSprite;
                currentClass = unitClass.rook;
                str = 8;
                spd = 4;
                lck = 2;
                skl = 8;
                con = 8;
                break;
            }
            case unitClass.bishop: 
            {
                sr.sprite = bishopSprite;
                currentClass = unitClass.bishop;
                str = 7;
                spd = 4;
                lck = 2;
                skl = 10;
                con = 6;
                break;
            }
            case unitClass.knight: 
            {
                sr.sprite = knightSprite;
                currentClass = unitClass.knight;
                str = 10;
                spd = 3;
                lck = 2;
                skl = 6;
                con = 10;
                break;
            }
            case unitClass.queen: 
            {
                sr.sprite = queenSprite;
                currentClass = unitClass.queen;
                str = 12;
                spd = 10;
                lck = 8;
                skl = 9;
                con = 4;
                break;
            }
            case unitClass.king: 
            {
                sr.sprite = kingSprite;
                currentClass = unitClass.king;
                str = 12;
                spd = 1;
                lck = 1;
                skl = 12;
                con = 9;
                break;
            }
        
        }
        board.placePieceOnCell(coords, this);
    }

    public Vector2Int movePiece(Vector2Int destination){
        Vector2Int oldPosition = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        transform.position = grid.GetCellCenterWorld(new Vector3Int(destination.x, destination.y, 1));
        return oldPosition;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void setUpPiece(unitClass cls){

    }
}
