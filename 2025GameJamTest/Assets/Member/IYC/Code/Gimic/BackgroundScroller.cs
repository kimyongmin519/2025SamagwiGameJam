using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundWidth = 20;
    [SerializeField] private Transform[] backgrounds;

    private void Update()
    {
        if (GameManager.Instance == null) return;

        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.left * 5 * Time.deltaTime;

            if (bg.position.x < -backgroundWidth)
            {
                bg.position += Vector3.right * (backgroundWidth * backgrounds.Length);
            }
        }
    }
}