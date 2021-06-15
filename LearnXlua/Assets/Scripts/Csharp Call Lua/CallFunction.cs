using UnityEngine;
using UnityEngine.Events;
using System;
using XLua;


public delegate void CustomCall();

// CsharpCallLua的特性是在Xlua命名空间中 加了之后需要在编辑器Xlua 生成代码generate code
[CSharpCallLua]
public delegate int CustomCall2(int a);

[CSharpCallLua]
public delegate int CustomCall3(int a, out int b, out bool c, out string d, out int e);

[CSharpCallLua]
public delegate int CustomCall4(int a, ref int b, ref bool c, ref string d, ref int e);

public class CallFunction : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        /////////////////////////////////     无参无返回值     /////////////////////////////////
        // 自定义委托
        CustomCall call = LuaManager.GetInstance().Global.Get<CustomCall>("testFun");
        call();
        // 【推荐使用】Unity自带的委托
        UnityAction ua = LuaManager.GetInstance().Global.Get<UnityAction>("testFun");
        ua();
        // 【推荐使用】C#自带的委托
        Action ac = LuaManager.GetInstance().Global.Get<Action>("testFun");
        ac();
        // Xlua提供的获取函数方法 尽量少用
        LuaFunction lf = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun");
        lf.Call();

        /////////////////////////////////     有参有返回值     /////////////////////////////////
        // 自定义委托
        CustomCall2 call2 = LuaManager.GetInstance().Global.Get<CustomCall2>("testFun2");
        Debug.Log("有参数有返回值：" + call2(10));
        // 【推荐使用】System自带的泛型委托 Func 该函数不接受一个参数 Func(传入int，返回int)
        Func<int, int> fc = LuaManager.GetInstance().Global.Get<Func<int, int>>("testFun2");
        Debug.Log("有参数有返回值：" + fc(20));
        // Xlua提供的方法 返回数组
        LuaFunction lf2 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun2");
        Debug.Log("有参数有返回值：" + lf2.Call(30)[0]);

        //////////////////////////////////     多返回值     //////////////////////////////////
        // C#不支持多返回值 使用out和ref
        // 使用out来接收多返回值
        CustomCall3 call3 = LuaManager.GetInstance().Global.Get<CustomCall3>("testFun3");
        int b;
        bool c;
        string d;
        int e;
        int a = call3(100, out b, out c, out d, out e);
        Debug.Log("使用out接收多返回值：" + a + "，" + b + "，" + c + "，" + d + "，" + e);
        // 使用ref来接收 ref区别于out必须在外部初始化
        CustomCall4 call4 = LuaManager.GetInstance().Global.Get<CustomCall4>("testFun3");
        int b1 = 0;
        bool c1 = true;
        string d1 = null;
        int e1 = 0;
        int a1 = call4(200, ref b1, ref c1, ref d1, ref e1);
        Debug.Log("使用out接收多返回值：" + a1 + "，" + b1 + "，" + c1 + "，" + d1 + "，" + e1);
    }
}