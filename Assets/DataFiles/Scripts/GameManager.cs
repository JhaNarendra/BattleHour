using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int loadGame;
    private void Awake()
    {
        AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Model/Prefabs/City.prefab");

        asyncOperationHandle.Completed += AsyncOperationHandle_completed;
    }

    private async void Start()
    {
        await Task.Delay(5000);
        if (loadGame != 0)
        {
            SceneManager.LoadScene(loadGame);
            return;
        }
    }
    private void AsyncOperationHandle_completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
        else
        {
            Debug.LogError("Failed to load");
        }
    }
}
