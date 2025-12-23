using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

public class ElecProxy : MonoBehaviour
{
    private ElectronicDisplayBoard board;

    private void Awake()
    {
        board = GetComponent<ElectronicDisplayBoard>();
    }
    public void Push()
    {
        PoolManager.Instance.Push(board);
    }
}
