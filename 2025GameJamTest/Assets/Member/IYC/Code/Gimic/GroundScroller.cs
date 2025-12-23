using UnityEngine;
using Member.KYM.Code.Players;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private Player player;
    private Rigidbody2D playerRigidbody;
    
    private void Start()
    {
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody2D>();
        }
    }
    
    private void Update()
    {
        if (playerRigidbody != null)
        {
            transform.position += Vector3.right * playerRigidbody.linearVelocityX * Time.deltaTime;
        }
    }
}