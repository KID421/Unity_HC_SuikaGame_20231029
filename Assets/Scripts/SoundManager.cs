using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音效管理器
    /// </summary>
    [DefaultExecutionOrder(0)]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        // AudioSource 播放聲音的元件
        private AudioSource aud;

        private void Awake()
        {
            instance = this;
            // 音效元件 = 取得此物件身上的 AudioSource
            aud = GetComponent<AudioSource>();
        }

        // AudioClip 音效檔案
        /// <summary>
        /// 播音效
        /// </summary>
        /// <param name="sound">想要播放的音效</param>
        public void PlaySound(AudioClip sound)
        {
            // 音效元件.播放一次音效(音效)
            aud.PlayOneShot(sound);
        }
    }
}
