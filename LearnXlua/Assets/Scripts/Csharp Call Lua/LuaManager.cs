using System;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// Lua管理器
/// 提供luaEnv解析器
/// 保证解析器的唯一性
/// </summary>
public class LuaManager : BaseManager<LuaManager>
{
    private LuaEnv luaEnv;

    /// 得到Lua中的_G
    public LuaTable Global
    {
        get { return luaEnv.Global; }
    }

    /// <summary>
    /// 初始化解析器
    /// </summary>
    public void Init()
    {
        if (luaEnv != null)
            return;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        // 热更新测试用
        // luaEnv.AddLoader(MyCustomABLoader);
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

    private Byte[] MyCustomABLoader(ref string fileName)
    {
        // AB管理器加载 必须使用同步加载，lua文件重定向必须马上返回，无法使用异步
        TextAsset tx = ABManager.GetInstance().LoadResource<TextAsset>("lua", fileName + ".lua");
        if (tx != null)
            return tx.bytes;
        else
            Debug.Log("MyCustomABLoader重定向失败，文件名为：" + fileName);
        return null;
    }


    /// 执行Lua脚本 优化DoString字符串拼接
    public void DoLuaFile(string fileName)
    {
        string str = string.Format("require('{0}')", fileName);
        DoString(str);
    }

    /// <summary>
    /// 执行Lua脚本
    /// </summary>
    /// <param name="str">lua语言字符串</param>
    private void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为空");
            return;
        }

        luaEnv.DoString(str);
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为空");
            return;
        }

        luaEnv.Tick();
    }

    /// <summary>
    /// 销毁
    /// </summary>
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为空");
            return;
        }

        luaEnv.Dispose();
        // 销毁后解析器为空
        luaEnv = null;
    }
}