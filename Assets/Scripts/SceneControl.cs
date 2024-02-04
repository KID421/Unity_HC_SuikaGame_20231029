using UnityEngine;
using UnityEngine.SceneManagement;

namespace KID
{
    /// <summary>
    /// 場景控制
    /// </summary>
    public class SceneControl : MonoBehaviour
    {
        // Unity 的 Button 要呼叫方法必須設為公開 public
        public void LoadScene(string scene)
        {
            print("載入場景");
            SceneManager.LoadScene(scene);
        }

        public void Quit()
        {
            print("離開遊戲");
            // 在 PC、Mobiel、Console 才會有作用
            Application.Quit();
        }
    }
}
