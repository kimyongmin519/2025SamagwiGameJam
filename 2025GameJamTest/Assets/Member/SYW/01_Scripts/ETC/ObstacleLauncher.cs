using System;
using System.Collections;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using Member.SYW._01_Scripts.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Member.SYW._01_Scripts.ETC
{
    public class ObstacleLauncher : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private ObstacleListSO obstacleList;
        [SerializeField] private float spawnInterval = 2f;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                SpawnObstacle();
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void SpawnObstacle()
        {
            if (obstacleList == null || obstacleList.Obstacles.Count == 0)
            {
                Debug.LogWarning("ObstacleListSO가 비어있거나 할당되지 않았습니다.");
                return;
            }

            int randomIndex = Random.Range(0, obstacleList.Obstacles.Count);
            ObstacleSO selectedData = obstacleList.Obstacles[randomIndex];
            
            string obstacleName = selectedData.Obstacle.gameObject.name;
            
            IPoolable item = PoolManager.Instance.Pop(obstacleName);

            if (item != null)
            {
                GameObject obj = item.GetGameObject();
                obj.transform.position = spawnPoint.position;
                obj.transform.rotation = Quaternion.identity;
            }
        }
    }
}