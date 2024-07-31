using VContainer;
using VContainer.Unity;
using WhackAMole.Infrastructure;

namespace WhackAMole.Installer
{
    public class ParentLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SequenceRepository>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.Register<TimerRepository>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}
