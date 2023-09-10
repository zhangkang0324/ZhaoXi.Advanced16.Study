using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace Reflection
{

    public class MyDynamicType
    {
        public int NumberField = 0;
        public int NumberProp { get; set; }
        public MyDynamicType(int numberField)
        {
            this.NumberField = numberField;
        }

        public int MyMethod(int para)
        {
            return 2 * para;
        }
    }

    public class ReflectionEmit
    {
        public static void Show()
        {
            // //AssemblyBuilder // 建造者模式 --专门创建Assembly

            AssemblyName assemblyName = new AssemblyName("DanamicAssemblyExample");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);

            // 对于单个模块程序集，模块名称通常为：程序集名称加上扩展名。
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModal");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public);

            // 在type中生成的私有字段
            FieldBuilder fieldBuilder = typeBuilder.DefineField("NumberField", typeof(int), FieldAttributes.Public);

            // 定义一个接受整数参数类型的构造函数，储存在私人区域。
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);

            // 中间语言的生成者
            ILGenerator ctor1IL = ctor1.GetILGenerator();

            // 对于构造函数，参数0是对新实例。在调用base之前将其推到堆栈上
            // 类构造函数。指定的默认构造函数
            // 通过传递
            // 类型（Type.EmptyTypes）到GetConstructor。

            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));

            // 在推送参数之前，先将实例推送到堆栈上
            // 将被分配给私有字段 m\u 编号
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fieldBuilder);
            ctor1IL.Emit(OpCodes.Ret);

            // 完成构造函数传值，Int设置给字段 --测试代码
            {
                //MyDynamicType myDynamicType = new MyDynamicType(123456);
                //int number = myDynamicType.NumberField;

                //// 动态的生成程序集；
                //// 动态的生成类；
                //// 动态的生成字段；
                //// 动态的生成构造函数；
                //Type type1 = typebuilder.CreateType();
                //object oInstacne = Activator.CreateInstance(type1, new object[] { 123456 });
                //FieldInfo fieldInfo = type1.GetField("NumberField");
                //object numberFieldResult = fieldInfo.GetValue(oInstacne);
            }

            MethodBuilder consoleMethod = typeBuilder.DefineMethod("ConsoleMethod", MethodAttributes.Public | MethodAttributes.Static, null, null);

            ILGenerator consoleMethodIL = consoleMethod.GetILGenerator();
            consoleMethodIL.Emit(OpCodes.Ldstr, "欢迎来到高级班第15期进阶学习");
            consoleMethodIL.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            consoleMethodIL.Emit(OpCodes.Ret); //写IL最后一定要Ret

            {
                Console.WriteLine("测试。。。。。。");
                Type type1 = typeBuilder.CreateType();
                object oInstacne = Activator.CreateInstance(type1, new object[] { 123456 });
                MethodInfo myMethod = type1.GetMethod("ConsoleMethod");
                object oResult = myMethod.Invoke(oInstacne, null);

            }

        }

    }
}
