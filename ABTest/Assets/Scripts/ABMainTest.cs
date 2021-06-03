using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABMainTest : MonoBehaviour
{
    void Start()
    {
        // 加载主包
        AssetBundle adMain = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "StandaloneWindows");
        // 加载主包固定文件
        AssetBundleManifest adMaiManifest = adMain.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 得到使用包依赖关系
        string[] strs = adMaiManifest.GetAllDependencies("model");

        // 加载使用的包
        AssetBundle ab =AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "model");
        GameObject obj = ab.LoadAsset("Cube", typeof(GameObject)) as GameObject;
        Instantiate(obj);
        
        for (int i = 0; i < strs.Length; i++)
        {
            // 加载依赖包
            AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + strs[i]);
        }
    }
}