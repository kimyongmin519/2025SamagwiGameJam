using UnityEngine;

public class Santa : MonoBehaviour
{
    private HealthManager healthManager;

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
    }


}
