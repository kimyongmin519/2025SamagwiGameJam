using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    enum Grade
    {
        SSS_Plus,
        SSS,
        SS_Plus,
        SS,
        S_Plus,
        S,
        AAA_Plus,
        AAA,
        AA_Plus,
        AA,
        A_Plus,
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
        [SerializeField] private int scoreSSSP = 10000;
        [SerializeField] private int scoreSSS = 9900;
        [SerializeField] private int scoreSSP = 9800;
        [SerializeField] private int scoreSS = 9700;
        [SerializeField] private int scoreSP = 9600;
        [SerializeField] private int scoreS = 9500;
        [SerializeField] private int scoreAAAP = 9250;
        [SerializeField] private int scoreAAA = 9000;
        [SerializeField] private int scoreAAP = 8500;
        [SerializeField] private int scoreAA = 8000;
        [SerializeField] private int scoreAP = 7000;
        [SerializeField] private int scoreA = 6000;
        [SerializeField] private int scoreB = 5000;
        [SerializeField] private int scoreC = 3500;
        [SerializeField] private int scoreD = 1000;
        
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