﻿using UnityEngine;

namespace KID
{
    /// <summary>
    /// 合成系統
    /// </summary>
    // 腳本執行順序，數字越小越先執行
    [DefaultExecutionOrder(0)]
    public class MergeSystem : MonoBehaviour
    {
        [Header("所有史萊姆預製物")]
        public GameObject[] prefabSlimes;

        // 單例模式
        // 只有一個存在的時候可以使用
        // instance 實體：物件
        // static 靜態
        public static MergeSystem instance;

        /// <summary>
        /// 可以合成
        /// </summary>
        private bool canMerge = true;

        private void Awake()
        {
            // 實體物件 = 這個腳本；
            instance = this;
        }

        /// <summary>
        /// 合成
        /// </summary>
        /// 小括號內參數語法：類型 參數名稱 (接收資料)
        public void Merge(int _index, Vector2 _point)
        {
            // 如果可以合成
            if (canMerge)
            {
                // 不可以合成
                canMerge = false;
                GameObject tempSlimes = Instantiate(prefabSlimes[_index], _point, Quaternion.identity);
                // 生成出來的史萊姆 重力 恢復為 1
                tempSlimes.GetComponent<Rigidbody2D>().gravityScale = 1;
                // 延遲 0.1 秒恢復可以合成
                // 延遲呼叫方法(方法名稱，延遲時間)
                Invoke("CanMerge", 0.1f);
            }
        }

        /// <summary>
        /// 恢復成可以合成
        /// </summary>
        private void CanMerge()
        {
            canMerge = true;
        }
    }
}