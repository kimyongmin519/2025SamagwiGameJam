using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Member.KYM.Code
{
    public class TestUI : MonoBehaviour
    {
        private Image _image;
        private void Awake()
        {
            _image = GetComponent<Image>();

            EventBus<ActiveUIEvent>.OnEvent += ChangeColor;
        }

        private void ChangeColor(ActiveUIEvent etv)
        {
            _image.color = etv.Color;
        }
    }
}
