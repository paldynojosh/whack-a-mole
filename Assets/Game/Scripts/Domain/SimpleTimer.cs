using System;
using R3;
using UnityEngine;

namespace WhackAMole.Domain
{
    public class SimpleTimer : IDisposable
    {
        readonly ReactiveProperty<float> remainTime = new(0);
        public Observable<float> RemainTime => remainTime;

        readonly Subject<Unit> onComplete = new();
        public Observable<Unit> OnComplete => onComplete;

        public float TotalTime { get; private set; }

        readonly SerialDisposable disposable = new();

        public void StartTimer(float time)
        {
            TotalTime = time;
            remainTime.Value = TotalTime;

            disposable.Disposable = Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    remainTime.Value -= Time.deltaTime;
                    if (remainTime.Value > 0)
                    {
                        return;
                    }

                    remainTime.Value = 0;
                    onComplete.OnNext(Unit.Default);
                });
        }

        public void StopTimer() => disposable.Dispose();

        void IDisposable.Dispose() => disposable.Dispose();
    }
}
