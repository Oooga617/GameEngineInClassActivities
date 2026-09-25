using UnityEngine;

public class KoopaSpawner : EnemySpawner
{
    public GameObject goombaPrefab;

    public override Enemy SpawnEnemy()
    {
        GameObject enemyEntity = Instantiate(goombaPrefab, transform.position, Quaternion.identity);
        return enemyEntity.GetComponent<Enemy>();
    }
}
