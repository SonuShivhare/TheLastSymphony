using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_EnemySpawner : MonoBehaviour
    {
        #region SerializeField
        [SerializeField] private Transform player;
        [SerializeField] private List<TLS_SO_EnemiesData> enemiesData;
        [SerializeField] private TLS_Utility.DeployEnemies diployEnemies;
        #endregion

        #region Private Field
        private TLS_Level_01_EnemyProperty skeletonProperties;
        private TLS_Level_01_EnemyProperty hellHoundProperties;

        private List<Coroutine> coroutines;
        #endregion

        private void Start()
        {

            if (diployEnemies.skeleton)
            {
                skeletonProperties = enemiesData.Find(x => x.enemyType == EnemyType.Skeleton)?.skeleton;
                StartCoroutine(SpawnLevel_01_EnemyWavesCoroutine(skeletonProperties, 20));
            }

            if (diployEnemies.HellHound)
            {
                hellHoundProperties = enemiesData.Find(x => x.enemyType == EnemyType.HellHound)?.hellHound;
                StartCoroutine(SpawnLevel_01_EnemyWavesCoroutine(hellHoundProperties, 20));
            }
        }

        public IEnumerator SpawnLevel_01_EnemyWavesCoroutine(TLS_Level_01_EnemyProperty enemiesProperties, int numOfEnemy)
        {
            yield return new WaitForSeconds(enemiesProperties.startingDelay);

            for (int i = 0; i < numOfEnemy; i++)
            {
                SpawnLevel_01_Enemy(enemiesProperties);
                yield return new WaitForSeconds(enemiesProperties.delayBetween);
            }
        }

        private void SpawnLevel_01_Enemy(TLS_Level_01_EnemyProperty enemiesProperties)
        {
            Vector2 spawnPos;
            spawnPos.x = (spawnPos.x = Random.Range(player.position.x - enemiesProperties.spawnRange, player.position.x + enemiesProperties.spawnRange)) < player.position.x ? spawnPos.x -= enemiesProperties.spawnDistanceFromPlayer : spawnPos.x + enemiesProperties.spawnDistanceFromPlayer;
            spawnPos.y = enemiesProperties.prefeb.transform.position.y;

            float speed = Random.Range(enemiesProperties.minSpeed, enemiesProperties.maxSpeed);

            GameObject obj = Instantiate(enemiesProperties.prefeb, spawnPos, Quaternion.identity);
            obj.GetComponent<TLS_EnemyController>().Init(player, speed, enemiesProperties.damage);

            if (enemiesProperties.enemyType == EnemyType.HellHound)
            {
                obj.GetComponent<TLS_EnemyController>().ChaseTheTarget();
            }
        }

        public void deployHellHound( )
        {
            StopDeploying();

            diployEnemies.HellHound = true;
                hellHoundProperties = enemiesData.Find(x => x.enemyType == EnemyType.HellHound)?.hellHound;
                StartCoroutine(SpawnLevel_01_EnemyWavesCoroutine(hellHoundProperties, 20));
        }

        public void StopDeploying()
        {
            diployEnemies.skeleton = false;
            diployEnemies.HellHound = false;
            StopAllCoroutines();
        }

        //private void OnDrawGizmos()
        //{
        //    Debug.DrawLine(new Vector2(player.position.x - skeletonProperties.spawnRange - skeletonProperties.spawnDistanceFromPlayer, player.position.y), new Vector2(player.position.x + skeletonProperties.spawnRange + skeletonProperties.spawnDistanceFromPlayer, player.position.y), Color.red);
        //    Debug.DrawLine(new Vector2(player.position.x - skeletonProperties.spawnDistanceFromPlayer, player.position.y), new Vector2(player.position.x + skeletonProperties.spawnDistanceFromPlayer, player.position.y), Color.green);
        //}
    }
}