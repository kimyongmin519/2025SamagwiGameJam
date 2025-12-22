using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;

    private void Update()
    {
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}