using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class GameOverUI : MonoSingleton<GameOverUI>
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}