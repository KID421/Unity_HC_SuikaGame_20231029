using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成系統：隨機生成第一顆與下一顆物件
    /// </summary>
    public class SpawnSystem : MonoBehaviour
    {
        /* 練習儲存遊戲物件
        // GameObject 場景上的物件以及預製物
        public GameObject prefabSlime1;
        public GameObject prefabSlime2;
        public GameObject prefabSlime3;
        */
        /* 練習陣列與隨機
        private void Awake()
        {
            // 取得陣列資料 Get
            print(prefabSlimes[4]);

            // 設定陣列資料 Set
            prefabSlimes[7] = prefabSlime3;

            // 獲得陣列的資料數量
            print($"<color=#69f>陣列數量：{prefabSlimes.Length}</color>");

            // 隨機.範圍(最小值，最大值)
            // 整數，不會等於最大值

            // 隨機.範圍(1，10) - 結果：1 ~ 9
            int r = Random.Range(1, 3); // 1 ~ 2
            print(r);

            int random = Random.Range(0, prefabSlimes.Length);
            print(random);
        }
        */

        // 陣列 Array - 資料結構
        // 儲存多個同樣資料類型的方式
        [Header("所有史萊姆預製物")]
        public GameObject[] prefabSlimes;

        public GameObject currentSlime;
        public GameObject nextSlime;

        [Header("放生成物位置")]
        public Transform spawnPoint;

        private void Awake()
        {
            int random = Random.Range(0, prefabSlimes.Length);
            currentSlime = prefabSlimes[random];

            int randomNext = Random.Range(0, prefabSlimes.Length);
            nextSlime = prefabSlimes[randomNext];
        }
    }
}
