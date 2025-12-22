using UnityEngine;
using Member.KYM.Code.Players;

public class infinitygameobject : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField] private Transform[] backgrounds;

    private void Update()
    {
        if(player.gameObject.transform.position.x == backgrounds[2].gameObject.transform.position.x + 3.11)
        {
            
        }
    }
}