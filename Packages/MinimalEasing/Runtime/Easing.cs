using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

#if MINIMAL_EASING_USE_UNITASK
using Cysharp.Threading.Tasks;
#endif

namespace MinimalEasing
{
    public static class Easing
    {
        public static float InOutQuint(float x) =>
            x < 0.5f ? 16 * x * x * x * x * x : 1 - math.pow(-2 * x + 2, 5) / 2;

        public static float InQuint(float x) => x * x * x * x * x;
        public static float OutQuint(float x) => 1 - math.pow(1 - x, 5);

        public static float InOutCubic(float x) => x < 0.5f ? 4 * x * x * x : 1 - math.pow(-2 * x + 2, 3) / 2;
        public static float InCubic(float x) => x * x * x;
        public static float OutCubic(float x) => 1 - math.pow(1 - x, 3);

        public static float InOutQuad(float x) => x < 0.5f ? 2 * x * x : 1 - math.pow(-2 * x + 2, 2) / 2;
        public static float InQuad(float x) => x * x;
        public static float OutQuad(float x) => 1 - math.pow(1 - x, 2);

        public static float InOutSine(float x) => -(math.cos(math.PI * x) - 1) / 2;
        public static float InSine(float x) => 1 - math.cos((x * math.PI) / 2);
        public static float OutSine(float x) => math.sin((x * math.PI) / 2);

        public static float InOutExpo(float x) =>
            x < 0.5f ? math.pow(2, 20 * x - 10) / 2 : (2 - math.pow(2, -20 * x + 10)) / 2;

        public static float InExpo(float x) => math.pow(2, 10 * x - 10);
        public static float OutExpo(float x) => 1 - math.pow(2, -10 * x);

        #if MINIMAL_EASING_USE_UNITASK
        public static async IAsyncEnumerable<float> LinearAsyncEnumerable(float time, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            for (var t = 0.0f; t < time; t += Time.deltaTime)
            {
                yield return t / time;
                await UniTask.Yield(cancellationToken);
            }
            yield return 1;
        }
        #endif
    }
}