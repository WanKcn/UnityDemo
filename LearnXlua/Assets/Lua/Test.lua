print("进入Test脚本")

-- 定义全局变量

testNumber = 100
testBool = true
testFloat = 1.1111
testString = "str3"

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

-- list
testList = {1,2,3,4,}
testList2 = {1,0.2,"333",false}

-- Dictionary
testDic={
	["1"] = 1,
	["2"] = 2,
	["3"] = 3,
	["4"] = 4
}

testDic2={
	["1"] = 1,
	["ture"] = 1,
	["false"] = true,
	["222"] = false
}


-- Lua当中的一个自定义类
testClass ={
	testInt = 2;
	testFloat = 1.3;
	testBool = true;
	testString = "567";
	testFun = function()
		print("this is a test fun")
	end,
	-- 嵌套映射
	testInClass = {
		testInInt = 5;
	}
}

-- 接口Interface
testInterface ={
	testInt = 2;
	testFloat = 1.3;
	testBool = true;
	testString = "567";
	testFun = function()
		print("this is a test fun")
	end,
	-- 嵌套映射
	testInterface = {
		testInInt = 5;
	}
}
