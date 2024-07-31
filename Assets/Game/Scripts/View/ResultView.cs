using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        public void SetVisible(bool isVisible) => gameObject.SetActive(isVisible);

        public void SetScore(int score) => scoreText.text = $"Score: {score}";
    }
}
