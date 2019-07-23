using UnityEngine;

public class EnemyController : MonoBehaviour {
    private CharacterData[] enemiesData;
    private EnemyBase[] enemies;
    public void initEnemy(){
        //todo
    }

    public EnemyBase[] getEnemies(){
        return enemies;
    }
}