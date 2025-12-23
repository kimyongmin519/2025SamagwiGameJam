using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

namespace Member.KYM.Code
{
    public class PoolItemLauncher : MonoBehaviour
    {
        [SerializeField] private PoolItemListSO poolItemListSO;
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private float minSpawnTime = 1f;
        [SerializeField] private float maxSpawnTime = 3f;
        
        private bool isActive = true;
        private float _currentTime = 0f;
        private float _nextSpawnTime;
        private int _totalSpawnedCount = 0;
        private void Start()
        {
            if (poolItemListSO == null || poolItemListSO.PoolItems.Count == 0)
            {
                Debug.LogError("PoolItemListSO가 할당되지 않았거나 비어있습니다!");
                enabled = false;
                return;
            }

            _nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }

        private void Update()
        {
            if (!isActive) return;
            _currentTime += Time.deltaTime;

            if (_currentTime >= _nextSpawnTime)
            {
                SpawnPoolItem();
                _currentTime = 0f;
                _nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }

        private void SpawnPoolItem()
        {
            int randomIndex = Random.Range(0, poolItemListSO.PoolItems.Count);
            PoolItemSO selectedSO = poolItemListSO.PoolItems[randomIndex];

            if (selectedSO == null)
            {
                Debug.LogError("선택된 PoolItemSO가 null입니다!");
                return;
            }

            IPoolable item = PoolManager.Instance.Pop(selectedSO.ItemName);

            if (item != null)
            {
                GameObject itemObj = item.GetGameObject();

                itemObj.transform.position = spawnTransform.position;
                itemObj.transform.rotation = spawnTransform.rotation;

                _totalSpawnedCount++;
            }
        }

        public void StartSpawning()
        {
            isActive = true;
        }

        public void StopSpawning()
        {
            isActive = false;
        }
    }
}