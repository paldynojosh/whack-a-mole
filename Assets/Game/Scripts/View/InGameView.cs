using UnityEngine;

namespace WhackAMole.View
{
    public class InGameView : MonoBehaviour
    {
        public void SetVisible(bool isTitle)
        {
            gameObject.SetActive(isTitle);
        }
    }
}
