using System;
using R3;
using VContainer.Unity;
using WhackAMole.Domain;
using WhackAMole.Infrastructure;
using WhackAMole.View;

namespace WhackAMole.Presenter
{
    public class ResultPresenter : IInitializable, IDisposable
    {
        readonly ResultView resultView;
        readonly ISequenceRepository sequenceRepository;
        readonly IScoreRepository scoreRepository;

        readonly CompositeDisposable disposable = new();

        [VContainer.Inject]
        public ResultPresenter(
            ResultView resultView,
            ISequenceRepository sequenceRepository,
            IScoreRepository scoreRepository)
        {
            this.resultView = resultView;
            this.sequenceRepository = sequenceRepository;
            this.scoreRepository = scoreRepository;
        }

        void IInitializable.Initialize()
        {
            sequenceRepository.CurrentSequence
                .Select(sequenceType => sequenceType == SequenceType.Result)
                .Subscribe(isResult =>
                {
                    resultView.SetVisible(isResult);
                    if (isResult)
                    {
                        resultView.SetScore(scoreRepository.Score.CurrentValue);
                    }
                })
                .AddTo(disposable);
        }

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
