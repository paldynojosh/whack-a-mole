using R3;

namespace WhackAMole.Infrastructure
{
    public interface ITimerRepository
    {
        Observable<float> Time { get; }
        float TotalTime { get; }
    }
}
