using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallLuaTable : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        // 使用LuaTable映射table 
        // 通过Xlua提供的类 得和改使用Get和Set 引用方法，用完需要Dispose() 不建议使用
        LuaTable table = LuaManager.GetInstance().Global.Get<LuaTable>("testClass");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<float>("testFloat"));
        Debug.Log(table.Get<string>("testString"));
        Debug.Log(table.Get<bool>("testBool"));
        table.Get<LuaFunction>("testFun").Call();

        table.Dispose();
    }
}