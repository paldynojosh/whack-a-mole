using System;
using R3;
using VContainer.Unity;
using WhackAMole.Domain;
using WhackAMole.Infrastructure;
using WhackAMole.Model;
using WhackAMole.View;

namespace WhackAMole.Presenter
{
    public class InGamePresenter : IInitializable, IDisposable
    {
        readonly InGameModel inGameModel;
        readonly InGameView inGameView;
        readonly SequenceRepository sequenceRepository;

        readonly CompositeDisposable disposable = new();

        [VContainer.Inject]
        public InGamePresenter(
            InGameModel inGameModel,
            InGameView inGameView,
            SequenceRepository sequenceRepository)
        {
            this.inGameModel = inGameModel;
            this.inGameView = inGameView;
            this.sequenceRepository = sequenceRepository;
        }

        void IInitializable.Initialize()
        {
            sequenceRepository.CurrentSequence
                .Where(sequenceType => sequenceType == SequenceType.Playing)
                .Subscribe(_ =>
                {
                    inGameView.SetVisible(true);
                    inGameModel.StartGame();
                })
                .AddTo(disposable);

            sequenceRepository.CurrentSequence
                .Where(sequenceType => sequenceType != SequenceType.Playing)
                .Subscribe(_ => inGameView.SetVisible(false))
                .AddTo(disposable);

            inGameModel.OnEndGame
                .Subscribe(_ => sequenceRepository.SetSequence(SequenceType.Result))
                .AddTo(disposable);

            inGameView.OnHoleButtonClicked
                .Subscribe(index =>
                {
                    // TODO: click event
                })
                .AddTo(disposable);
        }

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
