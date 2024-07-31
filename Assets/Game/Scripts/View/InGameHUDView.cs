using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class InGameHUDView : MonoBehaviour
    {
        [SerializeField] Text timeText;

        public void SetTime(float time) => timeText.text = $"Time: {time:F1}";

        public void SetVisible(bool isVisible) => gameObject.SetActive(isVisible);
    }
}
