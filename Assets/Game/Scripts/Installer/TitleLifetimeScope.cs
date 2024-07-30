using UnityEngine;
using VContainer;
using VContainer.Unity;
using WhackAMole.Presenter;
using WhackAMole.View;

namespace WhackAMole.Installer
{
    public class TitleLifetimeScope : LifetimeScope
    {
        [SerializeField] TitleView titleView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TitlePresenter>();
            builder.RegisterInstance(titleView);
        }
    }
}
