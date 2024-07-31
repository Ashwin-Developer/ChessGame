using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("RaySend");
                var player = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                Debug.Log("Player " + player);
                PieceHandler(player);
            }
        }
    }

    //Checking specific piece and calling the specific method
    internal void PieceHandler(ChessPlayerPlacementHandler player)
    {
        
        if(player != null)
        {
            if(player.piece == ChessPiece.pawn)
            {
                player.PawnPossibleMoves();
            }

            else if (player.piece == ChessPiece.rook)
            {
                player.RookPossibleMoves();
            }

            else if (player.piece == ChessPiece.Bhishop)
            {
                player.BhishopPossibleMoves();
            }

            else if(player.piece == ChessPiece.Queen)
            {
                player.QueenPossibleMoves();
            }

            else if(player.piece == ChessPiece.Knight)
            {
                player.KnightPossibleMoves();
            }

            else if (player.piece == ChessPiece.king)
            {
                player.KingPossibleMovements();
            }
        }
    }

}


