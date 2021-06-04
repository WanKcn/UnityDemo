using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// AB包资源加载管理器 让外部更方便的进行资源加载
/// </summary>
public class ABManager : Singleton<ABManager>
{
    // 记录主包
    private AssetBundle mainAB = null;

    // 记录依赖包获取用的配置文件
    private AssetBundleManifest manifest = null;

    // 声明加载包的路径,方便修改
    private string PathUrl
    {
        get { return Application.streamingAssetsPath + "/"; }
    }

    // 声明主包名
    private string MainABName
    {
        get
        {
#if UNITY_IOS
                return "IOS";
#elif UNIITY_ANDROID
            return "Android";
#else
            return "PC";
#endif
        }
    }

    // 用字典存储加载过的AB包
    private Dictionary<string, AssetBundle> abDict = new Dictionary<string, AssetBundle>();

    #region 同步加载

    /// <summary>
    /// 加载AB包
    /// </summary>
    /// <param name="abName">需要加载的包名</param>
    public void LoadAB(string abName)
    {
        if (mainAB == null)
        {
            // 加载主要包
            mainAB = AssetBundle.LoadFromFile(PathUrl + MainABName);
            // 加载主包中的关键配置文件
            manifest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }

        // 从关键配追信息里读取依赖包相关信息
        string[] strs = manifest.GetAllDependencies(abName);
        AssetBundle ab = null;
        for (int i = 0; i < strs.Length; i++)
        {
            if (!abDict.ContainsKey(strs[i]))
            {
                // 获取需要用到的资源包
                ab = AssetBundle.LoadFromFile(PathUrl + strs[i]);
                abDict.Add(strs[i], ab);
            }
        }

        // 加载资源所需要的包
        if (!abDict.ContainsKey(abName))
        {
            ab = AssetBundle.LoadFromFile(PathUrl + abName);
            abDict.Add(abName, ab);
        }
    }

    /// <summary>
    /// 同步加载 不指定类型
    /// </summary>
    /// <param name="abName">AB包名</param>
    /// <param name="resName">资源名称</param>
    /// <returns></returns>
    public Object LoadResource(string abName, string resName)
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        Object obj = abDict[abName].LoadAsset(resName);
        if (obj is GameObject)
            return Instantiate(obj);
        return obj;
    }

    /// <summary>
    /// 同步加载，根据type指定类型
    /// </summary>
    /// <param name="abName">AB包名</param>
    /// <param name="resName">资源名称</param>
    /// <param name="type">加载资源类型</param>
    /// <returns></returns>
    public Object LoadResource(string abName, string resName, System.Type type)
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        Object obj = abDict[abName].LoadAsset(resName, type);
        if (obj is GameObject)
            return Instantiate(obj);
        return obj;
    }

    /// <summary>
    /// 同步加载，根据泛型加载
    /// </summary>
    public T LoadResource<T>(string abName, string resName) where T : Object
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        T obj = abDict[abName].LoadAsset<T>(resName);
        if (obj is GameObject)
            return Instantiate(obj);
        return obj;
    }

    #endregion

    #region MyRegion

    // 异步加载 AB包并没有使用异步加载 只是从ab包中加载资源时使用异步
    // 提供给外部的方法，目的是启动协程

    /// <summary>
    /// 根据名字异步加载资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack"></param>
    public void LoadResourceAsync(string abName, string resName, UnityAction<Object> callBack)
    {
        StartCoroutine(ReallyLoadRes(abName, resName, callBack));
    }

    private IEnumerator ReallyLoadRes(string abName, string resName, UnityAction<Object> callBack)
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync(resName);
        yield return abr;

        // 异步加载结束后，通过委托传递给外部
        if (abr.asset is GameObject)
            callBack(Instantiate(abr.asset));
        else
            callBack(abr.asset);
    }

    /// <summary>
    /// 根据Typo异步加载资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="type"></param>
    /// <param name="callBack"></param>
    public void LoadResourceAsync(string abName, string resName, System.Type type, UnityAction<Object> callBack)
    {
        StartCoroutine(ReallyLoadRes(abName, resName, type, callBack));
    }

    private IEnumerator ReallyLoadRes(string abName, string resName, System.Type type, UnityAction<Object> callBack)
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync(resName, type);
        yield return abr;

        // 异步加载结束后，通过委托传递给外部
        if (abr.asset is GameObject)
            callBack(Instantiate(abr.asset));
        else
            callBack(abr.asset);
    }

    /// <summary>
    /// 根据泛型进行异步加载资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack"></param>
    /// <typeparam name="T"></typeparam>
    public void LoadResourceAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : Object
    {
        StartCoroutine(ReallyLoadRes<T>(abName, resName, callBack));
    }

    private IEnumerator ReallyLoadRes<T>(string abName, string resName, UnityAction<T> callBack) where T : Object
    {
        LoadAB(abName);
        // 为了在外部使用方便，在加载资源的时候判断一下 资源是不是GameObject 实例化后返回给外部
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync<T>(resName);
        yield return abr;

        // 异步加载结束后，通过委托传递给外部
        if (abr.asset is GameObject)
            callBack(Instantiate(abr.asset) as T);
        else
            callBack(abr.asset as T);
    }

    #endregion

    #region 卸载AB包

    /// 单个包卸载
    public void Unload(string abName)
    {
        if (abDict.ContainsKey(abName))
        {
            // 卸载包
            abDict[abName].Unload(false);
            // 卸载后移除
            abDict.Remove(abName);
        }
    }

    /// 所有包的卸载
    public void ClearAllAB()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        abDict.Clear();
        mainAB = null;
        manifest = null;
    }

    #endregion
}