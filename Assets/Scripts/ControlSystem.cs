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

        // 將資料設為 私人 private 避免其他程式存取 (安全)
        // 要將私人資料顯示 SerializeField 序列化欄位
        [Header("動畫控制器元件"), SerializeField]
        private Animator ani;
        [Header("圖片渲染元件"), SerializeField]
        private SpriteRenderer sprite;

        private string parMove = "移動數值";

        // 屬性 Property 與欄位相似：儲存資料
        // 可以設定 存取 權限
        // prop + Tab
        // 唯讀屬性
        public float inputHorizontal
        {
            get
            {
                return Input.GetAxis("Horizontal");
            }
        }

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
            UpdateAnimation();
            // Flip();
            FlipAngle();
        }

        // 元件被關閉時會執行一次的事件
        private void OnDisable()
        {
            // 移動浮點數歸零，恢復待機
            ani.SetFloat(parMove, 0);
        }

        /// <summary>
        /// 移動方法：偵測玩家的輸入並控制角色移動以及範圍限制
        /// </summary>
        private void Move()
        {
            // 區域變數 float h = ...;
            // 僅在此大括號內可以存取
            // h = 玩家輸入的水平按鍵 A、D 與 ← →
            // float h = Input.GetAxis("Horizontal");
            // print($"<color=#96f>水平值：{h}</color>");

            // 角色變形.位移(玩家水平 * 1/60 * 移動速度， 0， 0，空間)
            transform.Translate(inputHorizontal * Time.deltaTime * moveSpeed, 0, 0, Space.World);

            // 角色的座標
            // print(transform.position);

            // 點 = 角色的座標
            Vector3 point = transform.position;

            // 點.x = 數學的夾數(點.x，左邊屆，又邊界)
            point.x = Mathf.Clamp(point.x, limitLeft, limitRight);

            // 角色的座標 = 點
            transform.position = point;
        }

        /// <summary>
        /// 更新動畫
        /// </summary>
        private void UpdateAnimation()
        {
            // 將玩家水平值 設定為 絕對值
            float hAbs = Mathf.Abs(inputHorizontal);
            // 動畫.設定浮點數(移動數值參數，水平值絕對值)
            ani.SetFloat(parMove, hAbs);
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            // 如果 水平值取絕對值 < 0.1 就跳出 (避免回頭)
            if (Mathf.Abs(inputHorizontal) < 0.1f) return;

            sprite.flipX = inputHorizontal < 0;
        }

        /// <summary>
        ///  翻面：旋轉角度處理
        /// </summary>
        private void FlipAngle()
        {
            // 如果 水平值取絕對值 < 0.1 就跳出 (避免回頭)
            if (Mathf.Abs(inputHorizontal) < 0.1f) return;

            Vector3 angle = Vector3.zero;
            // 如果 水平值 > 0，Y 軸 0， 水平值 < 0，Y 軸 180
            // 三元運算子 ? : 
            // 語法：布林值 ? 當布林值等於 true : 當布林值等於 false;
            // 範例：true ? 1 : 180; 結果：1
            // 範例：false ? 1 : 180; 結果：180
            angle.y = inputHorizontal > 0 ? 0 : 180;

            // 更新變形元件的角度 = 新角度
            transform.eulerAngles = angle;
        }
    }
}

