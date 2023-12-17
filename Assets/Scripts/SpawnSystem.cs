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
        [Header("延遲將史萊姆移到手上的時間"), Range(0, 2)]
        public float delayChangeCurrentSlime = 0.5f;

        /// <summary>
        /// 是否能夠放下史萊姆
        /// </summary>
        public bool canReleaseSlime = true;

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

        /// <summary>
        /// 放開史萊姆
        /// </summary>
        private void ReleaseSlime()
        {
            // 如果玩家按下放下按鍵 就放開始史萊姆(重力 1)
            bool slimeKey = Input.GetKeyDown(releaseSlimeKey);
            print($"<color=#f89>玩家有沒有按放下鍵：{slimeKey}</color>");

            // 判斷式 if 語法
            // if (布林值) { 程式，當布林值為 true 執行這裡 }

            // 如果 按下放開鍵 並且 可以放下
            // if (slimeKey && canReleaseSlime == true)
            if (slimeKey && canReleaseSlime)
            {
                // 不可以放下史萊姆
                canReleaseSlime = false;
                // 史萊姆的重力設定為 1
                // 目前史萊姆 取得他的 2D 剛體 並且將 重力 改為 1
                currentSlime.GetComponent<Rigidbody2D>().gravityScale = 1;
                // 將目前史萊姆的父物件設為空
                currentSlime.transform.SetParent(null);
                // 對調目前與下一隻
                SwitchCurrentAndNext();
            }
        }

        /// <summary>
        /// 切換下一隻與目前史萊姆
        /// </summary>
        private void SwitchCurrentAndNext()
        {
            currentSlime = nextSlime;
            nextSlime = RandomSlime();

            // 延遲 0.5 秒執行
            // 延遲呼叫方法(方法名稱，延遲時間)
            Invoke("DelayChangeCurrentSlime", delayChangeCurrentSlime);
        }

        /// <summary>
        /// 延遲將目前史萊姆移動到手上
        /// </summary>
        private void DelayChangeCurrentSlime()
        {
            // 將目前史萊姆放在手上，父物件與座標
            currentSlime.transform.SetParent(spawnPoint);
            currentSlime.transform.localPosition = Vector3.zero;
            // currentSlime.transform.localPosition = new Vector3(0, -1, 0);
            // 再生一隻放到下一隻史萊姆
            nextSlime = Instantiate(nextSlime, nextPoint.position, Quaternion.identity, nextPoint);
            // 可以放下史萊姆
            canReleaseSlime = true;
        }
    }
}
