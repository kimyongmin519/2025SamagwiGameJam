using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    enum Grade
    {
        S,
        A,
        B,
        C,
        D,
        F
    }
    
    public class GameWinUI : MonoSingleton<GameWinUI>
    {
       [Header("References")]
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gradeText;

        [Header("Grade Settings (점수 커트라인 설정)")]
        [SerializeField] private int scoreS = 1000;
        [SerializeField] private int scoreA = 800;
        [SerializeField] private int scoreB = 600;
        [SerializeField] private int scoreC = 400;
        [SerializeField] private int scoreD = 200;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);

            if (scoreManager != null)
            {
                int finalScore = scoreManager.GetScore();
                
                scoreText.text = $"최종 점수: {finalScore}점";
                Grade userGrade = CalculateGrade(finalScore);
                gradeText.text = $"등급: {userGrade}";
                
                SetGradeColor(userGrade);
            }
        }

        private Grade CalculateGrade(int score)
        {
            if (score >= scoreS) return Grade.S;
            if (score >= scoreA) return Grade.A;
            if (score >= scoreB) return Grade.B;
            if (score >= scoreC) return Grade.C;
            if (score >= scoreD) return Grade.D;
            
            return Grade.F;
        }
        
        private void SetGradeColor(Grade grade)
        {
            switch (grade)
            {
                case Grade.S: gradeText.color = Color.yellow; break;
                case Grade.A: gradeText.color = Color.blue; break;
                case Grade.B: gradeText.color = Color.blue; break;
                case Grade.C: gradeText.color = Color.green; break;
                case Grade.D: gradeText.color = Color.gray; break;
                case Grade.F: gradeText.color = Color.red; break;
            }
        }
    }
}