using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 分數管理
    /// </summary>
    [DefaultExecutionOrder(0)]
    public class ScoreManager : MonoBehaviour
    {
        [Header("分數")]
        public TextMeshProUGUI textScore;
        [Header("所有史萊姆的分數")]
        public int[] slimeScores = { 10, 20, 30, 40, 50, 60, 70, 80 };

        private int totalScore;

        public static ScoreManager instance;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// 加分數方法
        /// </summary>
        /// <param name="_index">要加編號幾的史萊姆分數</param>
        public void AddScore(int _index)
        {
            // 拿出對應編號的史萊姆分數
            int score = slimeScores[_index];
            // 累加總分
            totalScore += score;
            // 更新分數文字介面 = 總分.轉為文字()；
            textScore.text = totalScore.ToString();
        }
    }
}
