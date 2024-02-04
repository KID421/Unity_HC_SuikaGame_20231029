using UnityEngine;
using UnityEngine.SceneManagement;

namespace KID
{
    /// <summary>
    /// 場景控制
    /// </summary>
    public class SceneControl : MonoBehaviour
    {
        private string scene;

        // Unity 的 Button 要呼叫方法必須設為公開 public
        public void LoadScene(string scene)
        {
            // 將參數的場景名稱儲存在 這個腳本的 scene 資料內
            this.scene = scene;
            // 延遲 1.2 秒呼叫
            Invoke("DelayLoadScene", 1.2f);
        }

        private void DelayLoadScene()
        {
            //print("載入場景");
            SceneManager.LoadScene(scene);
        }

        public void Quit()
        {
            // 延遲 1.2 秒呼叫
            Invoke("DelayQuit", 1.2f);
        }

        private void DelayQuit()
        {
            //print("離開遊戲");
            // 在 PC、Mobiel、Console 才會有作用
            Application.Quit();
        }
    }
}
