using Member.KYM.Code.Agent;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GetComponent<HealthSystem>();
    }

    /// <summary>
    /// 물리처리
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gimic")) // 태그로 기믹 오브젝트 확인
        {
            Gimic gimic = collision.gameObject.GetComponent<Gimic>(); // 기믹의 기믹 가져오기

            if (gimic != null && gimic.gimicData != null) // 기믹에 데이터가 있으면
            {
                healthSystem.GetDamage(gimic.gimicData.Damage); // GetDamage

                if (gimic.gimicData.StunDuration > 0)
                {
                    Stun(gimic.gimicData.StunDuration);
                }

                if (gimic.gimicData.DestroyOnHit)
                {
                    Destroy(collision.gameObject);
                } // 나머지 if는 알아서 해석
            }
        }
    }

    /// <summary>
    /// 스턴 매서드
    /// todo:실제 스턴 구현하기
    /// </summary>
    private void Stun(float duration)
    {
        print($"산타 장애물 맞아서 스턴이되");
    }
}