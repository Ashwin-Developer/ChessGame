using Chess.Scripts.Core;
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
        if (player != null)
        {
            switch (player.piece)
            {
                case ChessPiece.Pawn:
                    player.PawnPossibleMoves();
                    break;

                case ChessPiece.Rook:
                    player.RookPossibleMoves();
                    break;

                case ChessPiece.Bhishop:
                    player.BhishopPossibleMoves();
                    break;

                case ChessPiece.Queen:
                    player.QueenPossibleMoves();
                    break;

                case ChessPiece.Knight:
                    player.KnightPossibleMoves();
                    break;

                case ChessPiece.king:
                    player.KingPossibleMovements();
                    break;

                default:
                    Debug.LogWarning("Unknown chess piece type.");
                    break;
            }
        }
    }

}


