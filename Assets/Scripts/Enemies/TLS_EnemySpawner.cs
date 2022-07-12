using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_EnemySpawner : MonoBehaviour
    {
        #region SerializeField
        [SerializeField] private Transform player;
        [SerializeField] private float spawnRange;
        [SerializeField] private float spawnDistanceFromPlayer;

        [SerializeField] private GameObject skeletonEnemy;

        // Remove
        public int count;
        public float startingDelay;
        public float delayBetween;
        #endregion

        #region Private Field
        private Vector2 spawnPos;
        #endregion

        private void Start()
        {
            StartCoroutine(SpawnEnemyWaves(count, startingDelay, delayBetween));
        }

        public IEnumerator SpawnEnemyWaves(int numberOfEnemy, float startingDelay, float delayBetween)
        {
            yield return new WaitForSeconds(startingDelay);

            for (int i = 0; i < numberOfEnemy; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(delayBetween);
            }
        }

        private void SpawnEnemy()
        {
            spawnPos.x = (spawnPos.x = Random.Range(player.position.x - spawnRange, player.position.x + spawnRange)) < player.position.x ? spawnPos.x -= spawnDistanceFromPlayer : spawnPos.x + spawnDistanceFromPlayer;
            spawnPos.y = skeletonEnemy.transform.position.y;

            GameObject obj  = Instantiate(skeletonEnemy, spawnPos, Quaternion.identity);
            obj.GetComponent<TLS_SkeletonController>().AssignTarget(player);
        }

        private void OnDrawGizmos()
        {
            Debug.DrawLine(new Vector2(player.position.x - spawnRange - spawnDistanceFromPlayer, player.position.y), new Vector2(player.position.x + spawnRange + spawnDistanceFromPlayer, player.position.y), Color.red);
            Debug.DrawLine(new Vector2(player.position.x - spawnDistanceFromPlayer, player.position.y), new Vector2(player.position.x + spawnDistanceFromPlayer, player.position.y), Color.green);
        }
    }
}