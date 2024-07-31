using System;
using R3;
using VContainer.Unity;
using WhackAMole.Domain;
using WhackAMole.Infrastructure;
using WhackAMole.View;

namespace WhackAMole.Presenter
{
    public class InGameHUDPresenter : IInitializable, IDisposable
    {
        readonly InGameHUDView InGameHUDView;
        readonly ISequenceRepository sequenceRepository;
        readonly ITimerRepository timerRepository;

        readonly CompositeDisposable disposable = new();

        [VContainer.Inject]
        public InGameHUDPresenter(
            InGameHUDView inGameHUDView,
            ISequenceRepository sequenceRepository,
            ITimerRepository timerRepository)
        {
            InGameHUDView = inGameHUDView;
            this.sequenceRepository = sequenceRepository;
            this.timerRepository = timerRepository;
        }

        void IInitializable.Initialize()
        {
            sequenceRepository.CurrentSequence
                .Select(sequenceType => sequenceType == SequenceType.Playing)
                .Subscribe(isPlaying => InGameHUDView.SetVisible(isPlaying))
                .AddTo(disposable);

            timerRepository.Time
                .Subscribe(time => InGameHUDView.SetTime(time))
                .AddTo(disposable);
        }

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
