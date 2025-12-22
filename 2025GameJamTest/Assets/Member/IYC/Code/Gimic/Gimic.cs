using UnityEngine;

public class Gimic : MonoBehaviour
{
    [field: SerializeField]
    public GimicSO gimicData { get; private set; }

    private Rigidbody2D rigi;
    private bool isFalling = false;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        if (rigi != null)
        {
            rigi.gravityScale = 0;
        }
    }

    public void Initialize(GimicSO data)
    {
        gimicData = data;
    }

    private void Update()
    {
        if (!isFalling && GameManager.Instance != null)
        {
            transform.position += Vector3.left * GameManager.Instance.currentScrollSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isFalling)
        {
            isFalling = true;
            if (rigi != null)
            {
                rigi.gravityScale = 2;
            }
            Destroy(collision.gameObject);
        }
    }
}