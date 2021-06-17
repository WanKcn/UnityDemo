using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lua没有办法直接访问C# 一定是先从C#调用Lua脚本后，才把核心逻辑交给Lua编写
/// Unity启动的第一个代码是C#
/// 将Main作为主入口 通过它启动Lua 之后将Lua逻辑作为游戏逻辑
/// </summary>
public class Main : MonoBehaviour
{
    private void Start()
    {
        LuaManager.GetInstance().Init();
        // lua中 LuaCallCsharpMain作为主脚本
        LuaManager.GetInstance().DoLuaFile("LuaCallCsharpMain");
    }
}
