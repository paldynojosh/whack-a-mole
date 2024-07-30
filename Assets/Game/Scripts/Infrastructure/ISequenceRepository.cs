using R3;
using WhackAMole.Domain;

namespace WhackAMole.Infrastructure
{
    public interface ISequenceRepository
    {
        public ReadOnlyReactiveProperty<SequenceType> CurrentSequence { get; }

    }
}
