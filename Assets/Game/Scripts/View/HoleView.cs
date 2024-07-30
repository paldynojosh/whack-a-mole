using R3;
using UnityEngine;
using UnityEngine.UI;

namespace WhackAMole.View
{
    public class HoleView : MonoBehaviour
    {
        [SerializeField] Button holeButton;
        [SerializeField] MoleSpriteView moleSpriteView;

        public Observable<Unit> OnHoleButtonClicked => holeButton.OnClickAsObservable();

        public void ShowWake()
        {
            holeButton.image.enabled = true; // モグラが出ている時のみraycastするように
            moleSpriteView.ShowWake();
        }

        public void ShowHit()
        {
            holeButton.image.enabled = false;
            moleSpriteView.ShowHit();
        }

        public void Hide()
        {
            holeButton.image.enabled = false;
            moleSpriteView.Hide();
        }
    }
}
