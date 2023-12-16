# MinimalEasing
MinimalEasing is a [UniTask](https://github.com/Cysharp/UniTask) friendly minimal easing library for Unity.

## Example

![record](https://github.com/notargs/MinimalEasing/assets/3889597/3552c9a9-a314-4c7f-8427-f61a3438fa61)

```cs
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
```

## UPM Package
MinimalEasing supports UPM.
Write this snippets to `manifest.json`

```json
"com.notargs.minimal-easing": "git@github.com:notargs/MinimalEasing.git?path=/Packages/MinimalEasing#0.0.2"
```

## License
MIT License
