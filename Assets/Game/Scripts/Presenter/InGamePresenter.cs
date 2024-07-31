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
        CompositeDisposable moleViewDisposable = new();

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
                    inGameModel.Initialize(inGameView.MoleCount);

                    SubscribeMoles();
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
                    inGameModel.TryWhackMole(index);
                })
                .AddTo(disposable);
        }

        void SubscribeMoles()
        {
            moleViewDisposable?.Dispose();
            moleViewDisposable = new CompositeDisposable();

            var index = 0;
            foreach (var mole in inGameModel.MoleList)
            {
                mole.Status
                    .Subscribe(index, (status, i) =>
                    {
                        switch (status)
                        {
                            case MoleStatus.Covering:
                                inGameView.Hide(i);
                                break;
                            case MoleStatus.Uncovering:
                                inGameView.ShowWake(i);
                                break;
                            case MoleStatus.Whacked:
                                inGameView.ShowHit(i);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(status), status, null);
                        }
                    })
                    .AddTo(disposable);
                index++;
            }
        }

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
