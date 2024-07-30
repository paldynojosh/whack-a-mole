using UnityEngine;
using VContainer;
using VContainer.Unity;
using WhackAMole.Model;
using WhackAMole.Presenter;
using WhackAMole.View;

namespace WhackAMole.Installer
{
    public class InGameLifetimeScope : LifetimeScope
    {
        [SerializeField] InGameView inGameView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InGameModel>(Lifetime.Scoped);
            builder.RegisterEntryPoint<InGamePresenter>();
            builder.RegisterInstance(inGameView);
        }
    }
}
