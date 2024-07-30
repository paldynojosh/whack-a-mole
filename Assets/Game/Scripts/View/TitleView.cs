using R3;
using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] Button startButton;

        public Observable<Unit> OnStartButtonClicked => startButton.OnClickAsObservable();

        public void SetVisible(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}