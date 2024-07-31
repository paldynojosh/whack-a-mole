using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using WhackAMole.Domain;

namespace WhackAMole.Model
{
    public class Mole : IDisposable
    {
        readonly ReactiveProperty<MoleStatus> status = new(MoleStatus.Covering);
        public ReadOnlyReactiveProperty<MoleStatus> Status => status;

        readonly CancellationTokenSource cts = new();

        public bool TryWhack()
        {
            if (status.Value != MoleStatus.Uncovering)
            {
                return false;
            }

            WhackAsync().Forget();
            return true;
        }

        public void RequestDelayUncover()
        {
            if (status.Value != MoleStatus.Covering)
            {
                return;
            }

            DelayUncover().Forget();
        }

        async UniTaskVoid DelayUncover()
        {
            var randomTime = UnityEngine.Random.Range(0.5f, 5.0f);
            await UniTask.Delay(TimeSpan.FromSeconds(randomTime), cancellationToken: cts.Token);
            status.Value = MoleStatus.Uncovering;
        }

        async UniTaskVoid WhackAsync()
        {
            status.Value = MoleStatus.Whacked;

            const float reactionTime = 0.5f;
            await UniTask.Delay(TimeSpan.FromSeconds(reactionTime), cancellationToken: cts.Token);
            status.Value = MoleStatus.Covering;
            DelayUncover().Forget();
        }

        void IDisposable.Dispose()
        {
            cts.Cancel();
            cts.Dispose();
        }
    }
}