using UnityEngine;
using Member.KYM.Code.Players;

public class infinitygameobject : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField] private GameObject[] backgrounds;

    private void Update()
    {
        if (player.transform.position.x > backgrounds[2].gameObject.transform.position.x + 3.11)
        {
            backgrounds[0].gameObject.transform.position = new Vector3(backgrounds[2].gameObject.transform.position.x + 20, backgrounds[2].gameObject.transform.position.y, backgrounds[2].gameObject.transform.position.z);
        }

        if (player.transform.position.x > backgrounds[0].gameObject.transform.position.x + 3.11)
        {
            backgrounds[1].gameObject.transform.position = new Vector3(backgrounds[0].gameObject.transform.position.x + 20, backgrounds[0].gameObject.transform.position.y, backgrounds[0].gameObject.transform.position.z);
        }

        if (player.transform.position.x > backgrounds[1].gameObject.transform.position.x + 3.11)
        {
            backgrounds[2].gameObject.transform.position = new Vector3(backgrounds[1].gameObject.transform.position.x + 20, backgrounds[1].gameObject.transform.position.y, backgrounds[1].gameObject.transform.position.z);
            
        }
    }
}