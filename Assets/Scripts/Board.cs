using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    Piece[,] pieceArray;
    Piece selectedPiece;

    Vector2Int selectedPieceCoords;

    Grid grid;


    // Start is called before the first frame update
    void Start()
    {
        pieceArray = new Piece[8,8];
        grid = GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placePieceOnCell(Vector2Int coords, Piece piece){
        pieceArray[coords.x, coords.y] = piece;
    }

    public Piece removePieceFromCell(Vector2Int coords){
        Piece prevPiece = pieceArray[coords.x, coords.y];
        pieceArray[coords.x, coords.y] = null;
        return prevPiece;
    }

    public bool isCellEmpty(Vector2Int coords){
        return (pieceArray[coords.x, coords.y] == null);
    }

    private void OnMouseUpAsButton(){
        Vector3 worldCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pieceCellCoords = grid.WorldToCell(worldCoords);
        Vector2Int trueCoords = new Vector2Int((int)pieceCellCoords.x, (int)pieceCellCoords.y);
        print("World coords: " + worldCoords);
        print("Cell coords: " + pieceCellCoords);
        print("True coords: " + trueCoords);
        if (!isCellEmpty(trueCoords)){
            selectedPiece = pieceArray[trueCoords.x, trueCoords.y];
            selectedPieceCoords = trueCoords;
            print("Selected piece: " + selectedPiece.getPieceClass());
        }
        else if (isCellEmpty(trueCoords) && selectedPiece != null){
            Piece chosenOne = removePieceFromCell(selectedPieceCoords);
            placePieceOnCell(trueCoords, chosenOne);
            chosenOne.movePiece(trueCoords);
            selectedPiece = null;
        }
        else{
            print("invalid");
        }
    }
}
