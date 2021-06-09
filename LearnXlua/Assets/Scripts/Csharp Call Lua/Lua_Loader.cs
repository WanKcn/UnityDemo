// Author : WenRcn
// DataTime: 2021-06-09

using System;
using System.IO;
using UnityEngine;
using XLua;

public class Lua_Loader : MonoBehaviour
{
    void Start()
    {
        LuaEnv env = new LuaEnv();
        env.AddLoader(MyCustomLoader);
        env.DoString("require('Main')");
        env.DoString("require('Main_2')");
    }

    private Byte[] MyCustomLoader(ref string fileName)
    {
        string path = Application.dataPath + "/Lua/" + fileName + ".lua";
        Debug.Log(path);
        
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
            Debug.Log("MyCustonLoader重定向文件失败，文件名为"+fileName);
        
        return null;
    }

}
