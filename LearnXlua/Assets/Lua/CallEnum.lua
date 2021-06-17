print("--------- lua调用C#枚举 ---------")

GameObject = CS.UnityEngine.GameObject

-- 调用Unity当中的枚举
-- 枚举的调用规则和类的调用规则一致 CS.命名空间.枚举名.枚举成员 支持别名

PrimitiveType = CS.UnityEngine.PrimitiveType

GameObject.CreatePrimitive(PrimitiveType.Cube);

-- 自定义枚举类型
EN = CS.WR_Enmu
print(EN.IDLE)

-- 枚举转换
-- 数值转枚举
local a = EN.__CastFrom(1)
-- 字符串转枚举
local b = EN.__CastFrom("ATTACK")

print(a)
print(b)