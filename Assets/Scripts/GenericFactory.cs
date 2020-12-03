
using UnityEngine;


public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T prefab;
    public T GetInstance()
    {
        return Instantiate(prefab);
    }
}


