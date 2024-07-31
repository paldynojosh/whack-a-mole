using UnityEngine;
using VContainer;
using VContainer.Unity;
using WhackAMole.Presenter;
using WhackAMole.View;

namespace WhackAMole.Installer
{
    public class ResultLifetimeScope : LifetimeScope
    {
        [SerializeField] ResultView resultView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ResultPresenter>();
            builder.RegisterInstance(resultView);
        }
    }
}
