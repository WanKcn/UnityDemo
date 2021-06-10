using System;
using System.IO;
using UnityEngine;
using XLua;

public class LuaManager : BaseManager<LuaManager>
{
    private LuaEnv luaEnv;

    /// <summary>
    /// 初始化解析器
    /// </summary>
    public void Init()
    {
        if (luaEnv != null)
            return;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
    }

    private Byte[] MyCustomLoader(ref string fileName)
    {
        // 拼接路径
        string path = Application.dataPath + "/Lua/" + fileName + ".lua";
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
            Debug.Log("MyCustomLoader重定义失败：" + fileName);

        return null;
    }
    
    /// <summary>
    /// 执行Lua脚本
    /// </summary>
    /// <param name="str">lua语言字符串</param>
    public void DoString(string str)
    {
        // luaEnv.DoString("require('Main')");
        luaEnv.DoString(str);
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Tick()
    {
        luaEnv.Tick();
    }

    /// <summary>
    /// 销毁
    /// </summary>
    public void Dispose()
    {
        luaEnv.Dispose();
        // 销毁后解析器为空
        luaEnv = null;
    }
}