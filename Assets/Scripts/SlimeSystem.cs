using UnityEngine;

namespace KID
{
    /// <summary>
    /// 史萊姆物件系統：碰撞處理
    /// </summary>
    public class SlimeSystem : MonoBehaviour
    {
        // OnCollisionXXX 碰撞事件
        // 條件
        // 1. 兩個物件都要有碰撞器 Collider
        // 2. 其中一個要有 Rigidbody

        // 碰撞開始 Enter 一次
        // 碰撞結束 Exit  一次
        // 碰撞持續 Stay  持續執行約 60 FPS

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print($"<color=#f69>碰到的物件 {collision.gameObject.name}</color>");

            // 如果 碰到物件的名稱 與 這個物件的名稱 相同
            // 就 合成 (刪除、爆炸特效、升級後的史萊姆)
            // 等於 ==
            // gameObject 此物件
            if (collision.gameObject.name == gameObject.name)
            {
                // 刪除物件(要刪除的物件)
                Destroy(gameObject);
            }
        }
    }
}
