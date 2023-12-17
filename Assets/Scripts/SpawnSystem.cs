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
        [Header("下一個物件的位置")]
        public Transform nextPoint;
        [Header("放下按鍵")]
        public KeyCode releaseSlimeKey = KeyCode.Space;

        private void Awake()
        {
            currentSlime = RandomSlime();
            nextSlime = RandomSlime();

            // 生成(生成物件，座標，角度，父物件)
            currentSlime = Instantiate(currentSlime, spawnPoint.position, Quaternion.identity, spawnPoint);
            nextSlime = Instantiate(nextSlime, nextPoint.position, Quaternion.identity, nextPoint);
        }

        private void Update()
        {
            ReleaseSlime();
        }

        /// void 無傳回：使用這個方法不會有傳回資料
        /// <summary>
        /// 獲得隨機史萊姆
        /// </summary>
        /// <returns>隨機史萊姆</returns>
        private GameObject RandomSlime()
        {
            int random = Random.Range(0, prefabSlimes.Length);
            return prefabSlimes[random];
        }

        private void ReleaseSlime()
        {
            // 如果玩家按下放下按鍵 就放開始史萊姆(重力 1)
            bool slimeKey = Input.GetKeyDown(releaseSlimeKey);
            print($"<color=#f89>玩家有沒有按放下鍵：{slimeKey}</color>");

            // 判斷式 if 語法
            // if (布林值) { 程式，當布林值為 true 執行這裡 }
            if (slimeKey)
            {
                // 史萊姆的重力設定為 1
                // 目前史萊姆 取得他的 2D 剛體 並且將 重力 改為 1
                currentSlime.GetComponent<Rigidbody2D>().gravityScale = 1;
                // 將目前史萊姆的父物件設為空
                currentSlime.transform.SetParent(null);
                // 對調目前與下一隻
                SwitchCurrentAndNext();
            }
        }

        private void SwitchCurrentAndNext()
        {
            currentSlime = nextSlime;
            nextSlime = RandomSlime();
        }
    }
}
