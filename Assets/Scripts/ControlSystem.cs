using UnityEngine;  // 引用 Unity 遊戲引擎函式庫

namespace KID
{
    /// <summary>
    /// 玩家角色的控制系統：讓玩家可以控制角色左右移動
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        /* 練習區域
        // 欄位 Field
        // 儲存遊戲內的資料

        // 常用資料類型
        // 整　數 int
        // 浮點數 float
        // 字　串 string
        // 布林值 bool

        // 欄位語法
        // 修飾詞 欄位資料類型 欄位名稱 指定 值；
        // 公開：顯示 (但危險) public
        // 私人 預設：不顯示 private
        public int lv = 1;
        public float cd = 3.5f;
        public string skillName = "先聲奪人";
        public bool isDead = false;

        // 喚醒事件：播放遊戲後執行一次
        private void Awake()
        {
            print("<color=red>喚醒事件</color>");
        }

        // 開始事件：在 Awake 後執行一次
        private void Start()
        {
            print("<color=yellow>開始事件</color>");
        }

        // 更新事件：約一秒執行 60 次 60FPS
        private void Update()
        {
            print("<color=#69f>更新事件</color>");
        }
        */

        [Header("移動速度"), Range(0, 50)]
        public float moveSpeed = 2.5f;
        [Header("左邊界"), Tooltip("這是角色左邊的位置限制")]
        public float limitLeft = -4.5f;
        [Header("右邊界")]
        public float limitRight = 4.5f;

        /* 複習事件與輸出
        // 喚醒事件：遊戲開始時執行一次
        private void Awake()
        {
            // 輸出訊息(訊息)
            // 將訊息輸出至 Unity 的 Console 面板 (Ctrl + Shift + C 開啟)
            print(777);
            print("哈囉，沃德 :D");
            print(moveSpeed);
            print("<color=yellow>黃色的文字</color>");
            print("<color=#69f>左邊邊界：limitLeft</color>");
            print($"<color=#69f>左邊邊界：{limitLeft}</color>");
        }
        */

        // 更新事件：約 60 FPS
        // 可以偵測玩家的輸入行為，鍵盤、滑鼠、搖桿、觸控、XR 控制器
        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動方法：偵測玩家的輸入並控制角色移動以及範圍限制
        /// </summary>
        private void Move()
        {
            // h = 玩家輸入的水平按鍵 A、D 與 ← →
            float h = Input.GetAxis("Horizontal");
            // print($"<color=#96f>水平值：{h}</color>");

            // 角色變形.位移(玩家水平 * 1/60 * 移動速度， 0， 0)
            transform.Translate(h * Time.deltaTime * moveSpeed, 0, 0);

            // 角色的座標
            // print(transform.position);

            // 點 = 角色的座標
            Vector3 point = transform.position;

            // 點.x = 數學的夾數(點.x，左邊屆，又邊界)
            point.x = Mathf.Clamp(point.x, limitLeft, limitRight);

            // 角色的座標 = 點
            transform.position = point;
        }
    }
}

