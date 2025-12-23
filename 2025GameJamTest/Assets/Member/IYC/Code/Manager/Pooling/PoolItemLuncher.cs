using System.Collections;
using System.Collections.Generic;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace Member.KYM.Code.Spawner
{
    public class PoolItemLuncher : MonoBehaviour
    {
        [SerializeField] private PoolItemListSO poolItemList;
        [SerializeField] private float minSpawnTime = 2f;
        [SerializeField] private float maxSpawnTime = 5f;
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private bool useRandomX = false;
        [SerializeField] private float minX = 0f;
        [SerializeField] private float maxX = 5f;

        [SerializeField] private bool useRandomY = false;
        [SerializeField] private float minY = 0f;
        [SerializeField] private float maxY = 5f;

        [SerializeField] private List<string> spawnItemNames = new List<string>();

        private Coroutine _spawnCoroutine;
        private bool _isSpawning = false;
        private IPoolable _currentActiveItem = null;
        private void OnValidate()
        {
            if (poolItemList != null)
            {
                UpdateSpawnItemNames();
            }
        }

        private void UpdateSpawnItemNames()
        {
            spawnItemNames.Clear();

            foreach (PoolItemSO item in poolItemList.PoolItems)
            {
                if (!string.IsNullOrEmpty(item.ItemName))
                {
                    spawnItemNames.Add(item.ItemName);
                }
            }
        }

        private void Start()
        {
            if (spawnPoint == null)
            {
                spawnPoint = transform;
            }

            if (poolItemList != null)
            {
                UpdateSpawnItemNames();
            }

            StartSpawning();
        }


        public void StartSpawning()
        {
            if (_isSpawning) return;

            _isSpawning = true;
            _spawnCoroutine = StartCoroutine(SpawnRoutine());
        }

        public void StopSpawning()
        {
            if (!_isSpawning) return;

            _isSpawning = false;
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator SpawnRoutine()
        {
            while (_isSpawning)
            {
                float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(waitTime);

                SpawnRandom();
            }
        }

        private void SpawnRandom()
        {
            if (spawnItemNames.Count == 0)
            {
                return;
            }

            if (_currentActiveItem != null)
            {
                PoolManager.Instance.Push(_currentActiveItem);
                _currentActiveItem = null;
            }

            string randomItemName = spawnItemNames[Random.Range(0, spawnItemNames.Count)];

            IPoolable item = PoolManager.Instance.Pop(randomItemName);

            if (item != null)
            {
                float xOffset = useRandomX ? Random.Range(minX, maxX) : 0f;
                float yOffset = useRandomY ? Random.Range(minY, maxY) : 0f;

                Vector3 spawnPosition = new Vector3(
                    spawnPoint.position.x + xOffset,
                    spawnPoint.position.y + yOffset,
                    spawnPoint.position.z
                );

                item.GetGameObject().transform.position = spawnPosition;
                item.GetGameObject().transform.rotation = spawnPoint.rotation;

                _currentActiveItem = item;
            }
        }

        public void Spawn(string itemName)
        {
            if (_currentActiveItem != null)
            {
                PoolManager.Instance.Push(_currentActiveItem);
                _currentActiveItem = null;
            }

            IPoolable item = PoolManager.Instance.Pop(itemName);

            if (item != null)
            {
                float xOffset = useRandomX ? Random.Range(minX, maxX) : 0f;
                float yOffset = useRandomY ? Random.Range(minY, maxY) : 0f;

                Vector3 spawnPosition = new Vector3(
                    spawnPoint.position.x + xOffset,
                    spawnPoint.position.y + yOffset,
                    spawnPoint.position.z
                );

                item.GetGameObject().transform.position = spawnPosition;
                item.GetGameObject().transform.rotation = spawnPoint.rotation;

                _currentActiveItem = item;
            }
        }

        private void OnDestroy()
        {
            StopSpawning();

            if (_currentActiveItem != null)
            {
                PoolManager.Instance.Push(_currentActiveItem);
                _currentActiveItem = null;
            }
        }
    }
}