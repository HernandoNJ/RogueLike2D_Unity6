using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private BoardManager m_board;
    [SerializeField] private Vector2Int m_CellPosition; // It stores the current player cell index

    public void SpawnPlayer(BoardManager boardManager, Vector2Int cellIndex)
    {
        m_board = boardManager;
        m_CellPosition = cellIndex;
        transform.position = m_board.SetCellIndexToWorldPosition(cellIndex);
    }

    private void Update()
    {
        Vector2Int newTargetCell = m_CellPosition;
        bool hasMoved = false;

        // Update targetCell if key is pressed
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newTargetCell.y += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            newTargetCell.y -= 1;
            hasMoved = true;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newTargetCell.x += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newTargetCell.x -= 1;
            hasMoved = true;
        }

        if (hasMoved)
        {
            BoardManager.CellData cellData = m_board.GetCellData(newTargetCell);
            
            if (cellData != null && cellData.IsPassable)
            {
                // Update m_CellPosition value
                m_CellPosition = newTargetCell;

                // Get a new Vector3 using cell index to set the player position
                transform.position = m_board.SetCellIndexToWorldPosition(m_CellPosition);
            }
        }
    }
}
