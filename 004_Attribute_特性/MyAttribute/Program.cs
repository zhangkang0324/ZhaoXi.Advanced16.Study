namespace MyAttribute {

    internal class Program {

        #region 课程介绍
        /*
            * 1. 特性Attribute的本质
            * 2. 和注释有什么区别
            * 3. 声明Attribute，AttributeUsage
            * 4. 运行中反射获取Attribute
            * 5. 特性获取额外信息
            * 6. 特性获取额外功能
            * 7. Attribute的实战应用
        */
        #endregion
        static void Main(string[] args) {

            try {

                Console.WriteLine("欢迎学习.Net课程，今天的内容是特性 Attribute !");

                // 特性真的是无处不在，各种框架:MVC、IOC、ORM、WebService...大多都有他

                #region 一、什么是特性，特性的本质
                {
                    // 【Serializable】序列化：只要是标记Serializable，就可以序列化
                    // 【Obsolete】弃用：还可以影响编译器。特性是会影响程序运行的，在编译时确定的。

                    // 1. 特性是什么？
                    //      特性Attribute就是一个类，直接继承、间接继承自Attribute抽象类
                    // 2. 应用特性：
                    //     是把这个特性以[]中括号包裹，标记在类或者是类内部的成员上。其实就是调用构造函数
                }
                #endregion

                #region 二、特性和注释的区别
                {
                    // 1. 注释只是一个描述，让人看懂写的是什么。除此之外没有任何影响。在编译后，是不存在的;
                    // 2. 特性呢？ 编译后是存在的
                    {
                        // --看看特性的本质
                        //      
                    }
                }
                #endregion

                #region 三、如何自定义特性，特性的多种标记
                {
                    // 定义：
                    // 1. 标记的特性，约定俗成用 Attribute结尾，在标记的时候可以省略掉。
                    // 2. 可以标记在类内部的任何成员上
                    // 3. 特性在标记的时候，其实就是去调用构造函数

                }
                #endregion

                #region 四、如何调用到特性内部的成员
                {
                    //  --自定义的这个特性，如何才能使用他呢？
                    Student student = new Student();
                    // student.custom // 调用不到

                    // 1. 经过反编译后，在标记有特性的类的内部，生成了custom的成员，但是我们不能直接调用；
                    //    -- 要通过反射调用:要让特性生效，实际上来说是要去执行我们这个特性？ --就需要构造特性的实例
                    // 2. 可以标记在类内部的任何成员上
                    // 3. 特性在标记的时候，其实就是去调用构造函数
                    // 4. 在标记的时候也可以对公开的属性或者字段赋值
                    // 5. 默认是不能重复标记的
                    // 6. AttributeUsage：也是一个特性，是用来修饰特性的特性。
                    // 7. AttributeTargets:指定当前特性只能标记在某个地方：建议大家在自定义特性的时候，最好能够明确指定 AttributeTargets --明确告诉别人，我这个特性是专门用来标记哪里的。
                    // 8. AllowMultiple:是否可以重复标记
                    // 9. Inherited：是否可以继承此特性

                }
                #endregion

                #region 五、

                #endregion







            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}