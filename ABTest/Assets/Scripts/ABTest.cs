using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABTest : MonoBehaviour
{
    public Image image;

    void Start()
    {
        // 同步加载

        // 1.加载AB包
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "model");
        // 2.加载 AB包中的资源 只使用同名加载会出现不同类型同名的资源分不清楚
        // 使用泛型加载或者Type制定类型
        // GameObject obj = ab.LoadAsset<GameObject>("Cube");
        // 指定类型加载 lua不支持泛型，需要as到固定类型
        GameObject obj = ab.LoadAsset("Cube", typeof(GameObject)) as GameObject;
        // GameObject obj1 = ab.LoadAsset("Sphere", typeof(GameObject)) as GameObject;
        Instantiate(obj);
        // Instantiate(obj1);

        ab.Unload(true);
        // 异步加载——》协程
        StartCoroutine(LoadRes("head", "head1"));
    }

    // 加载协程资源
    IEnumerator LoadRes(string ABName, string resName)
    {
        AssetBundleCreateRequest abCR = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/" + ABName);
        yield return abCR;
        AssetBundleRequest abR = abCR.assetBundle.LoadAssetAsync(resName, typeof(Sprite));
        yield return abR;
        // abR.asset是一个Object类型
        image.sprite = abR.asset as Sprite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            // false可以保留资源只卸载AB包
            AssetBundle.UnloadAllAssetBundles(false);
        if (Input.GetKeyDown(KeyCode.A))
            // 会卸载掉所有资源
            AssetBundle.UnloadAllAssetBundles(true);
    }
}