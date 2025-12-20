using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public class AgentRenderer : MonoBehaviour
    {
        public void VisualFlip(Vector2 pos, Transform parent)
        {
            if (pos.x > parent.position.x)
            {
                parent.rotation = Quaternion.Euler(0, 0, parent.eulerAngles.z - 180);
            }
            else if (pos.x < parent.position.x)
            {
                parent.rotation = Quaternion.Euler(0, 180, parent.eulerAngles.z + 180);
            }
        }
    }
}
