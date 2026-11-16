using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] GameObject enemyObj;
    public override void Spawn()
    {
        Instantiate(enemyObj, transform.position, Quaternion.identity);
        
    }
}
