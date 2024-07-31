using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public LayerMask pawn;

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

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Pawn is Clicked");
            //ChessPlayerPlacementHandler.Instance.CalculatePossibleMoves();
        }
    }
}
