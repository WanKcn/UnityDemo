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

public class LuaCallCsharp : MonoBehaviour
{
}