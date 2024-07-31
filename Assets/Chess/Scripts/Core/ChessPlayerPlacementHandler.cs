using System;
using UnityEngine;

namespace Chess.Scripts.Core {

    public class ChessPlayerPlacementHandler : MonoBehaviour {

        [SerializeField] public int row, column;
        private ChessBoardPlacementHandler _boardPlacementHandler;

        [SerializeField] private LayerMask _pawn;

        private void Start() {
            _boardPlacementHandler = ChessBoardPlacementHandler.Instance;
            transform.position = _boardPlacementHandler.GetTile(row, column).transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandlePieceSelection();
            }
        }

        private void HandlePieceSelection()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, _pawn))
            {
                Debug.Log("Pawn is Clicked");
                CalculatePossibleMoves();
            }
        }

        public void CalculatePossibleMoves()
        {
            Debug.Log("Possible moves has been called");
            _boardPlacementHandler.ClearHighlights();

            for(int i = 2; i <= 3;  i++)
            {
                _boardPlacementHandler.Highlight(i, column);
            }
        }

    }
}