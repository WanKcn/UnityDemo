using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 泛型单例模版
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject();
            DontDestroyOnLoad(obj);
            instance = obj.AddComponent<T>();
        }

        return instance;
    }
}