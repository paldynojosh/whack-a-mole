using R3;

namespace WhackAMole.Infrastructure
{
    public interface IScoreRepository
    {
        ReadOnlyReactiveProperty<int> Score { get; }
    }
}
