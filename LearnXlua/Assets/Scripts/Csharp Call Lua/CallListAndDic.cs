using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallListAndDic : MonoBehaviour
{
    private void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        //////////////////////////////     映射到List     ////////////////////////////// 
        // list一般用来映射没有自定义索引的表，确定类型制定类型，不确定类型使用object
        List<int> list = LuaManager.GetInstance().Global.Get<List<int>>("testList");
        foreach (var i in list)
            Debug.Log(i);
        Debug.Log("----- List<int> -----");
        // 值拷贝，C#中修改不会影响原有lua中的值
        list[0] = 200;
        List<int> list2 = LuaManager.GetInstance().Global.Get<List<int>>("testList");
        Debug.Log(list2[0]);
        Debug.Log("----- List<object> -----");
        List<object> list3 = LuaManager.GetInstance().Global.Get<List<object>>("testList2");
        foreach (var i in list3)
            Debug.Log(i);

        //////////////////////////////     映射到Dictionary     //////////////////////////////     
        // 调用object的列表 字典一般用来映射有自定义索引的表，确定类型指定类型，不确定类型使用object （打印顺序无序）
        Debug.Log("------ Dic<string,int> -----");
        Dictionary<string, int> dict = LuaManager.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
        foreach (var k in dict.Keys)
            Debug.Log(k + "_" + dict[k]);
        Debug.Log("----- 测试修改Dic参数 -----");
        // 值拷贝，不会改变lua中的内容
        dict["1"] = 10000;
        Dictionary<string, int> dict2 = LuaManager.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
        Debug.Log(dict2["1"]);
        Debug.Log("----- Dic<object,object> ------");
        Dictionary<object, object> dict3 = LuaManager.GetInstance().Global.Get<Dictionary<object, object>>("testDic2");
        foreach (var k in dict3.Keys)
            Debug.Log(k + "_" + dict3[k]);
    }
}