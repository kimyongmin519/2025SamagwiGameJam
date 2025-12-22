using UnityEngine;
using UnityEngine.Events;

public class PresentBox : MonoBehaviour
{
    public UnityEvent OnBulletHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnBulletHit?.Invoke();

            Destroy(collision.gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Bullet"))
    //    {
    //        OnBulletHit?.Invoke();
    //        Destroy(other.gameObject);
    //    }
    //}
}