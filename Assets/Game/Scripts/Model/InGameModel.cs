using System;
using R3;
using WhackAMole.Infrastructure;

namespace WhackAMole.Model
{
    public class InGameModel : IDisposable
    {
        readonly TimerRepository timerRepository;

        public Observable<Unit> OnEndGame => timerRepository.OnComplete;

        [VContainer.Inject]
        public InGameModel(
            TimerRepository timerRepository)
        {
            this.timerRepository = timerRepository;
        }

        public void StartGame()
        {
            const float time = 30.0f;
            timerRepository.StartTimer(time);
        }

        void IDisposable.Dispose() => timerRepository.StopTimer();
    }
}
