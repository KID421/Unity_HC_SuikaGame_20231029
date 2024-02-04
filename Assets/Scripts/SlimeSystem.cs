using UnityEngine;

namespace KID
{
    /// <summary>
    /// 史萊姆物件系統：碰撞處理
    /// </summary>
    public class SlimeSystem : MonoBehaviour
    {
        [Header("史萊姆編號"), Range(0, 7)]
        public int index;

        /* 練習插值
        private void Awake()
        {
            // 插值 Lerp
            // a b 兩個 2D 座標
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(100, 100);
            // 計算 a b 兩個座標的中心點，中心點 0.5 (50%)
            print(Vector2.Lerp(a, b, 0.5f));
        }
        */

        // OnCollisionXXX 碰撞事件
        // 條件
        // 1. 兩個物件都要有碰撞器 Collider
        // 2. 其中一個要有 Rigidbody

        // 碰撞開始 Enter 一次
        // 碰撞結束 Exit  一次
        // 碰撞持續 Stay  持續執行約 60 FPS

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 把這隻史萊姆貼上標籤"掉下去的史萊姆"
            tag = "掉下去的史萊姆";

            // 如果 這是最大隻的 就跳出
            /*
            if (index == 7)
            {
                return;
            }
            */

            if (index == 7) return;

            // print($"<color=#f69>碰到的物件 {collision.gameObject.name}</color>");

            // 如果 碰到物件的名稱 與 這個物件的名稱 相同
            // 就 合成 (刪除、爆炸特效、升級後的史萊姆)
            // 等於 ==
            // gameObject 此物件
            if (collision.gameObject.name == gameObject.name)
            {
                // print($"<color=#69f>要生出的史萊姆編號 {index + 1}</color>");

                // 此物件的座標
                Vector2 pointA = transform.position;
                // 碰到物件的座標
                Vector2 pointB = collision.transform.position;
                // 計算出兩個物件的中間座標
                Vector2 result = Vector2.Lerp(pointA, pointB, 0.5f);

                // 單例模式的使用方式
                // 語法：
                // 腳本名稱.實體.公開 public 成員
                MergeSystem.instance.Merge(index + 1, result);

                // 刪除物件(要刪除的物件)
                Destroy(gameObject);
            }
        }
    }
}
