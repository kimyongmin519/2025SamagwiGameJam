using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class GameWinUI : MonoSingleton<GameWinUI>
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gradeText;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}