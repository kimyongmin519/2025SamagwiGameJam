using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float cameraSpeed = 2.0f; 

    private void Update()
    {
        transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
    }
}
