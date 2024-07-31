using R3;
using WhackAMole.Domain;

namespace WhackAMole.Infrastructure
{
    public class TimerRepository : ITimerRepository
    {
        readonly SimpleTimer timer = new();

        public void StartTimer(float time) => timer.StartTimer(time);
        public Observable<Unit> OnComplete => timer.OnComplete;

        Observable<float> ITimerRepository.Time => timer.RemainTime;

        float ITimerRepository.TotalTime => timer.TotalTime;

        public void StopTimer() => timer.StopTimer();
    }
}
