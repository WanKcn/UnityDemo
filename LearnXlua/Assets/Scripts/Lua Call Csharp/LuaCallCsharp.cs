using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Lua调用自定义类

// 自定义类
public class Test
{
    public void outPut(string str)
    {
        Debug.Log("Test:" + str);
    }
}

namespace WRTest
{
    public class TestInSpace
    {
        public void outPut(string str)
        {
            Debug.Log("Test in Space:" + str);
        }
    }
}

#endregion

#region Lua调用自定义枚举

/// <summary>
/// 自定义枚举类 用于lua调用
/// </summary>
public enum WR_Enmu
{
    IDLE,
    RUN,
    ATTACK
}

#endregion

#region Array List Dictionary

public class ArrListDic
{
    public int[] arr = {1, 2, 3, 4, 5};
    public List<int> list = new List<int>();
    public Dictionary<int, string> dic = new Dictionary<int, string>();

    public void Test()
    {
        Debug.Log(arr.Length);
    }
}

#endregion


#region 扩展方法

public static class Tools
{
    // ExtendFunc的扩展方法
    public static void Move(this ExtendsFunc obj)
    {
        Debug.Log(obj.name + "移动");
    }
}

public class ExtendsFunc
{
    public string name = "文若";

    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("eat something");
    }
}

#endregion

public class LuaCallCsharp : MonoBehaviour
{
    private void Start()
    {
        // Unity中的枚举类
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}