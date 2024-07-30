using System;
using R3;
using VContainer.Unity;
using WhackAMole.Domain;
using WhackAMole.Infrastructure;
using WhackAMole.View;

namespace WhackAMole.Presenter
{
    public class TitlePresenter : IInitializable, IDisposable
    {
        readonly TitleView titleView;
        readonly SequenceRepository sequenceRepository;

        readonly CompositeDisposable disposable = new();

        [VContainer.Inject]
        public TitlePresenter(
            TitleView titleView,
            SequenceRepository sequenceRepository
            )
        {
            this.titleView = titleView;
            this.sequenceRepository = sequenceRepository;
        }

        void IInitializable.Initialize()
        {
            titleView.OnStartButtonClicked
                .Subscribe(_ => sequenceRepository.SetSequence(SequenceType.Playing))
                .AddTo(disposable);

            sequenceRepository.CurrentSequence
                .Select(sequenceType => sequenceType == SequenceType.Title)
                .Subscribe(isTitle => titleView.SetVisible(isTitle))
                .AddTo(disposable);
        }

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
