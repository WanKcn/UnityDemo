print("进入Test脚本")

-- 定义全局变量

testNumber = 1
testBool = true
testFloat = 1.2
testString = "123"

-- 本地变量无法通过C# 调用
local num = 2

-- 函数的获取
-- 无参无返回值
testFun = function()
	print("无参无返回值")
end

-- 有参又返回值
testFun2 = function(a)
	print("有参数有返回值")
	return a+1
end

-- 多返回值
testFun3 = function(a)
	print("多返回值")
	return 1,2,false,"123",a
end

-- 变长参数
testFun4 = function(a,...)
	print("变长参数")
	print(a)
	arg={...}
	for k,v in pairs(arg) do
		print(k,v)
	end
end