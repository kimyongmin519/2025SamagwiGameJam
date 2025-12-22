using UnityEngine;

public class Gimic : MonoBehaviour
{
    [field:SerializeField]
    public GimicSO gimicData {  get; private set; }

    public void Initialize(GimicSO data)
    {
        gimicData = data;
    }
}