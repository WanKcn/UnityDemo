using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallVariable : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        // 使用Global.Get调用
        int i = LuaManager.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumeber:" + i);

        LuaManager.GetInstance().Global.Set("testString", "123456");
        string str = LuaManager.GetInstance().Global.Get<string>("testString");
        Debug.Log("testSting:" + str);
        
        // 无法访问到local变量 打印报错
        // int i2 = LuaManager.GetInstance().Global.Get<int>("num");
        // Debug.Log("testNumeber:" + i2);
    }
}