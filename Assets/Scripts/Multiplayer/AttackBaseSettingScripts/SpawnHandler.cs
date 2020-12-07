using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    private EnemyType selectedEnemyType;

    [SerializeField]
    private AttackBaseBoard board;

    //The input ray
    Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    GameBehaviorCollection enemies = new GameBehaviorCollection();

    [SerializeField]
    EnemyFactory factory;

    private void Start()
    {
        selectedEnemyType = 0;
    }

    public void SelectSquad(EnemyType type)
    {
        selectedEnemyType = type;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch();
        }
    }

    public void HandleTouch()
    {
        GameTile tile = board.GetTile(TouchRay);
        if (tile.Content.Type != GameTileContentType.SpawnPoint)
            return;

        Enemy enemy = factory.Get(selectedEnemyType);
        enemy.SpawnOn(tile);
        enemies.Add(enemy);
    }
}
