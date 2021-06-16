using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 如果将Lua中的表映射到C#中类对象中，声明一个自定义类，其中成员变量命名需要和Lua中保持一直，支持嵌套
public class CallLuaClass
{
    // 在类中声明成员变量需要和lua中的变量保持一致
    // 必须是public 否则不可在外部进行赋值
    // 定义变量的多少不影响获取lua中的变量 有就获取，没有就忽略
    public int testInt;
    public float testFloat;
    public bool testBool;

    public string testString;

    public CallLuaInClass testInClass;

    // 委托接收lua中的函数
    public UnityAction testFun;
    public int num;
}

public class CallLuaInClass
{
    public int testInInt;
}

public class CallClass : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        // 使用自定义类接收lua表
        CallLuaClass clc = LuaManager.GetInstance().Global.Get<CallLuaClass>("testClass");
        Debug.Log("testInt:" + clc.testInt);
        Debug.Log("testFloat:" + clc.testFloat);
        Debug.Log("testString:" + clc.testString);
        Debug.Log("testBool:" + clc.testBool);
        Debug.Log("嵌套表:" + clc.testInClass.testInInt);
        clc.testFun();

        // 类调用也是值拷贝
        clc.testInt = 111;
        CallLuaClass clc2 = LuaManager.GetInstance().Global.Get<CallLuaClass>("testClass");
        Debug.Log("Lua中的值是否被修改：" + (clc2.testInt == clc.testInt));
    }
}