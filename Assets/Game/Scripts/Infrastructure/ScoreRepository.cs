using R3;

namespace WhackAMole.Infrastructure
{
    public class ScoreRepository : IScoreRepository
    {
        readonly ReactiveProperty<int> score = new();
        public ReadOnlyReactiveProperty<int> Score => score;

        public void IncrementScore() => score.Value++;

        public void ResetScore() => score.Value = 0;
    }
}
