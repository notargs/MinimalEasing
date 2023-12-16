using System.Threading;
using Cysharp.Threading.Tasks;
using MinimalEasing;
using UnityEngine;

namespace Sample.Runtime
{
public class MinimalEasingSample : MonoBehaviour
{
    private void Start()
    {
        RunAsync(destroyCancellationToken).Forget();
    }

    private async UniTaskVoid RunAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await foreach (var t in Easing.LinearAsyncEnumerable(0.5f, cancellationToken: cancellationToken))
            {
                transform.position = Easing.InOutQuad(t) * Vector3.right;
            }

            await foreach (var t in Easing.LinearAsyncEnumerable(0.5f, cancellationToken: cancellationToken))
            {
                transform.position = Vector3.right + Easing.InSine(t) * Vector3.up;
            }
        
            await foreach (var t in Easing.LinearAsyncEnumerable(0.5f, cancellationToken: cancellationToken))
            {
                transform.position = Vector3.right + Vector3.up + Easing.OutExpo(t) * Vector3.left;
            }
            
            await foreach (var t in Easing.LinearAsyncEnumerable(0.5f, cancellationToken: cancellationToken))
            {
                transform.position = Vector3.up + Easing.InQuint(t) * Vector3.down;
            }
        }
    }
}
}