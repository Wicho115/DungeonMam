using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void BootstrapMethod()
    {
        //Se crea el collisionSystem
        CreateObject<CollisionSystem>();

        //SE CRE GAME MANAGER
        CreateObject<GameManager>();
    }

    public static void CreateObject<T>() where T : MonoBehaviour
    {
        if (Object.FindObjectOfType<T>() != null) return;

        var obj = new GameObject(typeof(T).Name);
        obj.AddComponent<T>();
    }
}
