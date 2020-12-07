using UnityEngine;

public class AttackBaseSetup : MonoBehaviour
{
    const float pausedTimeScale = 0f;

    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11, 11);

    [SerializeField]
    AttackBaseBoard board = default;

    [SerializeField]
    GameTileContentFactory tileContentFactory = default;

    void Awake()
    {
        board.Initialize(boardSize, tileContentFactory);
        board.Generate(AttackBaseData.attackboardLogic);
    }

    void OnValidate()
    {
        if (boardSize.x < 2)
        {
            boardSize.x = 2;
        }
        if (boardSize.y < 2)
        {
            boardSize.y = 2;
        }
    }
}
