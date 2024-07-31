using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class InGameHUDView : MonoBehaviour
    {
        [SerializeField] Text timeText;
        [SerializeField] Text scoreText;

        public void SetTime(float time) => timeText.text = $"Time: {time:F1}";

        public void SetVisible(bool isVisible) => gameObject.SetActive(isVisible);

        public void SetScore(int score) => scoreText.text = $"Score: {score}";
    }
}
