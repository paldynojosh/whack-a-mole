using System.Linq;
using R3;
using UnityEngine;
using WhackAMole.Domain;

namespace WhackAMole.View
{
    public class InGameView : MonoBehaviour
    {
        [SerializeField] HoleView[] holeViews;

        public Observable<int> OnHoleButtonClicked =>
            holeViews
                .Select((holeView, index) => holeView.OnHoleButtonClicked.Select(_ => index))
                .Merge();

        public int MoleCount => holeViews.Length;

        public void SetVisible(bool isTitle)
        {
            gameObject.SetActive(isTitle);
        }

        public void ShowWake(int index) => holeViews[index].ShowWake();

        public void ShowHit(int index) => holeViews[index].ShowHit();

        public void Hide(int index) => holeViews[index].Hide();
    }
}
