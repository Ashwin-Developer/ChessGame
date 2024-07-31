using System;
using UnityEngine;
using UnityEngine.UI;

namespace Chess.Scripts.Core {
    
    public enum ChessPiece
    {
        Pawn,
        king,
        Rook,
        Bhishop,
        Queen,
        Knight
    }

    public class ChessPlayerPlacementHandler : MonoBehaviour {

        [SerializeField] public int row, column;
        public ChessPiece piece;    
        private ChessBoardPlacementHandler _boardPlacementHandler;
        private int  _boardSize = 8;

        private void Start() {
            _boardPlacementHandler = ChessBoardPlacementHandler.Instance;
            transform.position = _boardPlacementHandler.GetTile(row, column).transform.position;
        }

        internal void StraightMovements()
        {
            // For vertical highlights
            for (int i = row + 1; i < _boardSize; i++)
            {
                if (_boardPlacementHandler.IsTileOccupied(i, column)) break;
                _boardPlacementHandler.Highlight(i, column);
            }

            for (int i = row - 1; i >= 0; i--)
            {
                if (_boardPlacementHandler.IsTileOccupied(i, column)) break;
                _boardPlacementHandler.Highlight(i, column);
            }

            // For horizontal highlights
            for (int i = column + 1; i < _boardSize; i++)
            {
                if (_boardPlacementHandler.IsTileOccupied(row, i)) break;
                _boardPlacementHandler.Highlight(row, i);
            }

            for (int i = column - 1; i >= 0; i--)
            {
                if (_boardPlacementHandler.IsTileOccupied(row, i)) break;
                _boardPlacementHandler.Highlight(row, i);
            }
        }

        internal void DiagonalMovements()
        {
            int[] directions = { 1, -1 };

            foreach (var dirX in directions)
            {
                foreach (var dirY in directions)
                {
                    int x = row;
                    int y = column;
                    while (true)
                    {
                        x += dirX;
                        y += dirY;

                        if (x >= 0 && x < _boardSize && y >= 0 && y < _boardSize)
                        {
                            if (_boardPlacementHandler.IsTileOccupied(x, y)) break;
                            _boardPlacementHandler.Highlight(x, y);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
       
        //Checking possible moves of the Pawn
        internal void PawnPossibleMoves()
        {
            _boardPlacementHandler.ClearHighlights();
            for (int i = 1; i <= 2; i++)
            {
                if (_boardPlacementHandler.IsTileOccupied(row + i, column)) break;
                _boardPlacementHandler.Highlight(row + i, column);
            }
        }

        //Checking possible moves of the Rook
        internal void RookPossibleMoves()
        {
            Debug.Log("Rook's possible moves called");
            _boardPlacementHandler.ClearHighlights();
            StraightMovements();
        }

        //Checking possible moves of the Bhishop
        internal void BhishopPossibleMoves()
        {
            Debug.Log("Bishop's possible moves called");

            _boardPlacementHandler.ClearHighlights();
            DiagonalMovements();
        }


        //Checking possible moves of the Queen
        internal void QueenPossibleMoves()
        {
            _boardPlacementHandler.ClearHighlights();
            StraightMovements();
            DiagonalMovements();
        }

        //Checking possible moves of the Knight
        internal void KnightPossibleMoves()
        {
            Debug.Log("Knight's possible moves called");
            _boardPlacementHandler.ClearHighlights();
            int[,] knightMoves = new int[,] {
                { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
                { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
            };

            for (int i = 0; i < knightMoves.GetLength(0); i++)
            {
                int newRow = row + knightMoves[i, 0];
                int newCol = column + knightMoves[i, 1];

                if (newRow >= 0 && newRow < _boardSize && newCol >= 0 && newCol < _boardSize)
                {
                    if (!_boardPlacementHandler.IsTileOccupied(newRow, newCol))
                    {
                        _boardPlacementHandler.Highlight(newRow, newCol);
                    }
                }
            }
        }

        //Checking possible moves of the King
        internal void KingPossibleMovements()
        {
            Debug.Log("King's possible moves called");

            _boardPlacementHandler.ClearHighlights();
            int[,] kingMoves = new int[,] {
                { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
                { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }
            };

            for (int i = 0; i < kingMoves.GetLength(0); i++)
            {
                int newRow = row + kingMoves[i, 0];
                int newCol = column + kingMoves[i, 1];

                if (newRow >= 0 && newRow < _boardSize && newCol >= 0 && newCol < _boardSize)
                {
                    if (!_boardPlacementHandler.IsTileOccupied(newRow, newCol))
                    {
                        _boardPlacementHandler.Highlight(newRow, newCol);
                    }
                }
            }
        }

        
    }

}