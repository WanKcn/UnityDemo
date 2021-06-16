using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
using XLua.LuaDLL;

[CSharpCallLua]
public interface CsharpCallInterface
{
    int testInt { get; set; }
    float testFloat { get; set; }
    string testString { get; set; }
    bool testBool { get; set; }
    UnityAction testFun { get; set; }
    InCsharpCallInterface testInterface { get; set; }
}

[CSharpCallLua]
public interface InCsharpCallInterface
{
    int testInInt { get; set; }
}

public class CallInterface : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
        CsharpCallInterface cf = LuaManager.GetInstance().Global.Get<CsharpCallInterface>("testInterface");
        Debug.Log(cf.testInt);
        Debug.Log(cf.testFloat);
        Debug.Log(cf.testString);
        Debug.Log(cf.testBool);
        cf.testFun();
        Debug.Log("嵌套接口：" + cf.testInterface.testInInt);

        // 测试修改值
        cf.testInt = 1000;
        CsharpCallInterface cf2 = LuaManager.GetInstance().Global.Get<CsharpCallInterface>("testInterface");
        Debug.Log("值是否被修改" + (cf2.testInt == cf.testInt));
        if (cf2.testInt == cf.testInt)
            Debug.Log("接口映射是引用拷贝");
    }
}