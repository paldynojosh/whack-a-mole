using System;
using System.Collections.Generic;
using R3;
using WhackAMole.Infrastructure;

namespace WhackAMole.Model
{
    public class InGameModel : IDisposable
    {
        readonly TimerRepository timerRepository;
        readonly ScoreRepository scoreRepository;

        public Observable<Unit> OnEndGame => timerRepository.OnComplete;

        readonly List<Mole> moleList = new();
        public IEnumerable<Mole> MoleList => moleList;

        [VContainer.Inject]
        public InGameModel(
            TimerRepository timerRepository,
            ScoreRepository scoreRepository)
        {
            this.timerRepository = timerRepository;
            this.scoreRepository = scoreRepository;
        }

        public void Initialize(int moleCount)
        {
            moleList.Clear();
            for (var i = 0; i < moleCount; i++)
            {
                moleList.Add(new Mole());
            }

            scoreRepository.ResetScore();
        }

        public void StartGame()
        {
            foreach (var mole in moleList)
            {
                mole.RequestDelayUncover();
            }

            const float time = 30.0f;
            timerRepository.StartTimer(time);
        }

        void IDisposable.Dispose() => timerRepository.StopTimer();

        public void TryWhackMole(int index)
        {
            if (moleList[index].TryWhack())
            {
                scoreRepository.IncrementScore();
            }
        }
    }
}
