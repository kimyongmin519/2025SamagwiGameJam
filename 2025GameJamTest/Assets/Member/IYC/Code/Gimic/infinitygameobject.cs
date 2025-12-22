using UnityEngine;
using Member.KYM.Code.Players;

public class infinitygameobject : MonoBehaviour
{
    [SerializeField]
    private Player player;


    private void Update()
    {
        if(player.gameObject.transform.position.x == gameObject.transform.position.x + 3.11)
        {
            
        }
    }
}