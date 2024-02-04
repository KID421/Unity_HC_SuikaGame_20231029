using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 遊戲管理器：結束判定與分數管理
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField, Header("結束畫面群組")]
        private CanvasGroup groupFinal;
        [SerializeField, Header("原住民")]
        private ControlSystem controlSystem;
        [SerializeField, Header("生成系統")]
        private SpawnSystem spawnSystem;
        [SerializeField, Header("遊戲結束音效")]
        private AudioClip soundGameOver;

        // 1. 需要兩個物件並且都有碰撞器 Collider2D
        // 2. 其中一個要有剛體 Rigidbody2D
        // 3. 其中一個要勾選 Is Trigger
        private void OnTriggerEnter2D(Collider2D collision)
        {
            print($"<color=#f69>碰到的物件：{collision.name}</color>");

            // 如果碰到的物件貼有"掉下去的史萊姆"標籤才會淡入結束畫面
            if (collision.tag == "掉下去的史萊姆") StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            SoundManager.instance.PlaySound(soundGameOver);

            controlSystem.enabled = false;      // 關閉控制系統
            spawnSystem.enabled = false;        // 關閉生成系統

            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }

            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        /* 測試協同程序與迴圈
        private void Awake()
        {
            StartCoroutine(Test());

            // 學習法則 20 80 
            // 迴圈：for、while、do while、foreach
            // for 迴圈：重複執行程式
            // for (初始值；條件；迴圈結束執行程式)
            for (int i = 0; i < 1000; i++)
            {
                print("測試");
            }
        }

        private IEnumerator Test()
        {
            print("第一行");
            yield return new WaitForSeconds(1); // 等 1 秒
            print("第二行");
            yield return new WaitForSeconds(3); // 等 3 秒
            print("第三行");
            yield return new WaitForSeconds(1); // 等 1 秒
            print("第四行");
        }
        */
    }
}
