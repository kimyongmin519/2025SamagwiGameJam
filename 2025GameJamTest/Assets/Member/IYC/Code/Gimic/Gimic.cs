using UnityEngine;

public class Gimic : MonoBehaviour
{
    [field:SerializeField]
    public GimicSO gimicData {  get; private set; }

    private Rigidbody2D rigi;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    public void Initialize(GimicSO data)
    {
        gimicData = data;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if(gameObject.TryGetComponent<Rigidbody2D>(out rigi))
            {
                rigi.gravityScale = 2;
            }
        }
    }
}