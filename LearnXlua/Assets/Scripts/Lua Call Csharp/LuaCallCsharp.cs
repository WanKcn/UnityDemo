using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

/// <summary>
/// 自定义枚举类 用于lua调用
/// </summary>
public enum WR_Enmu
{
    IDLE,
    RUN,
    ATTACK
}

public class LuaCallCsharp : MonoBehaviour
{
    private void Start()
    {
        // Unity中的枚举类
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}