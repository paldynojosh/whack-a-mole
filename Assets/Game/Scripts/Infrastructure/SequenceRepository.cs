using R3;
using WhackAMole.Domain;

namespace WhackAMole.Infrastructure
{
    public class SequenceRepository : ISequenceRepository
    {
        readonly ReactiveProperty<SequenceType> currentSequence = new(SequenceType.Title);
        public ReadOnlyReactiveProperty<SequenceType> CurrentSequence => currentSequence;

        public void SetSequence(SequenceType sequenceType) => currentSequence.Value = sequenceType;
    }
}
