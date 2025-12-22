using Member.SYW._01_Scripts.Manager;

namespace Member.SYW._01_Scripts.UI
{
    public class GameOverUI : MonoSingleton<GameOverUI>
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}