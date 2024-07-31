using UnityEngine;
using VContainer;
using VContainer.Unity;
using WhackAMole.Model;
using WhackAMole.Presenter;
using WhackAMole.View;

namespace WhackAMole.Installer
{
    public class InGameHUDLifetimeScope : LifetimeScope
    {
        [SerializeField] InGameHUDView inGameHUDView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InGameHUDPresenter>();
            builder.RegisterInstance(inGameHUDView);
        }
    }
}
