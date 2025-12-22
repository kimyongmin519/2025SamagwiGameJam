using Member.KYM.Code.Interface;
using UnityEngine;
using UnityEngine.Events;

public class PresentBox : MonoBehaviour
{
    public UnityEvent OnBulletHit;
    private void Awake()
    {
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            OnBulletHit.AddListener(() => scoreManager.AddScore());
        }
        else
        {
            print("없어 없다고 score");
        }
    }


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