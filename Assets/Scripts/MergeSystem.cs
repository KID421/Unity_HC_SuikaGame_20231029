using UnityEngine;

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

        private void Awake()
        {
            // 實體物件 = 這個腳本；
            instance = this;
        }

        /// <summary>
        /// 合成
        /// </summary>
        /// 小括號內參數語法：類型 參數名稱 (接收資料)
        public void Merge(int _index)
        {
            print("<color=#99f>合成</color>");
            Instantiate(prefabSlimes[_index], Vector3.zero, Quaternion.identity);
        }
    }
}
