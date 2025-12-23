using UnityEngine;
using Member.KYM.Code.Players;

public class infinitygameobject : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private GameObject[] Spawnner;

    private void Update()
    {
        if (player.transform.position.x > backgrounds[2].gameObject.transform.position.x + 3.11)
        {
            backgrounds[0].gameObject.transform.position = new Vector3(backgrounds[2].gameObject.transform.position.x, backgrounds[2].gameObject.transform.position.y, backgrounds[2].gameObject.transform.position.z);
            UpdateSpawnnersToRightmost();
        }

        if (player.transform.position.x > backgrounds[0].gameObject.transform.position.x + 3.11)
        {
            backgrounds[1].gameObject.transform.position = new Vector3(backgrounds[0].gameObject.transform.position.x, backgrounds[0].gameObject.transform.position.y, backgrounds[0].gameObject.transform.position.z);
            UpdateSpawnnersToRightmost();
        }

        if (player.transform.position.x > backgrounds[1].gameObject.transform.position.x + 3.11)
        {
            backgrounds[2].gameObject.transform.position = new Vector3(backgrounds[1].gameObject.transform.position.x, backgrounds[1].gameObject.transform.position.y, backgrounds[1].gameObject.transform.position.z);
            UpdateSpawnnersToRightmost();
        }
    }

    private void UpdateSpawnnersToRightmost()
    {
        float rightmostX = Mathf.Max(
        backgrounds[0].transform.position.x,
        backgrounds[1].transform.position.x,
        backgrounds[2].transform.position.x 
        );

        foreach (GameObject spawner in Spawnner)
        {
            spawner.transform.position = new Vector3(rightmostX, spawner.transform.position.y, spawner.transform.position.z);
        }
    }
}