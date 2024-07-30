using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class MoleSpriteView : MonoBehaviour
    {
        [SerializeField] Image moleWakeImage;
        [SerializeField] Image moleHitImage;

        public void ShowWake()
        {
            moleWakeImage.gameObject.SetActive(true);
            moleHitImage.gameObject.SetActive(false);
        }

        public void ShowHit()
        {
            moleWakeImage.gameObject.SetActive(false);
            moleHitImage.gameObject.SetActive(true);
        }

        public void Hide()
        {
            moleWakeImage.gameObject.SetActive(false);
            moleHitImage.gameObject.SetActive(false);
        }
    }
}
