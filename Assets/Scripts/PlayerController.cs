using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoardManager m_board;
    [SerializeField] private Vector2Int m_CellPosition;

    public void SpawnPlayer(BoardManager boardManager, Vector2Int cellIndex)
    {
        m_board = boardManager;
        m_CellPosition = cellIndex;
        transform.position = m_board.SetCellIndexToWorldPosition(cellIndex);
    }
}
