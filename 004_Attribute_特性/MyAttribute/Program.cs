using Business.DB.Model;
using Business.DB.SqlServer;
using MyAttribute.Extend;
using MyAttribute.ValidateExtend;
using System;

namespace MyAttribute {
    class Program {
        //1.特性Attibute的本质
        //2.和注释有什么区别
        //3.声明Attribute，AttributeUsage
        //4.运行中获取Attribute：
        //5.特性获取额外信息
        //6.特性获取额外功能
        //7.Attribute的实战应有

        static void Main(string[] args) {
            //特性真的是无处不在的，各种框架，MVC,IOC，ORM,WebService....各种框架多有他
            //一、什么是特性，特性的本质
            //Serializable:只要是标记Serializable，就可以序列化
            //Serializable:还可以影响我们这个编译器
            //很厉害
            //1.特性其实是一个Clas(类)，声明的时候，默认以Attribute结尾，直接或者是间接继承在Attribute抽象类
            //2.应用特性，是把这个特性以[]包裹标记在类或者是类内部的成员上；

            //二、特性和注释的区别---看看特性的本质
            //1.注释只是会个描述；在编译后，是不存在的
            //2.特性呢？编译后是存在的
            {

            }
            //三、如何自定义特性，特性的多种标记
            {//1.标记的特性，如果是以Attribute结果，Attribute可以省略掉
             //2.可以标记的类内部的任何成员上 
             //3.特性在标记的时候，其实就是去调用构造函数
             //4.在标记的时候也可以对公开的属性或者字段赋值
             //5.特性标记默认是不能重复标记的
             //6.AttributeUsage:也是一个特性，是用来修饰特性的特性--约束特性的特性
             //7.AttributeTargets指定当前特性只能标记在某个地方；建议大家在自己定义特性的时候，最好能够明确指定AttributeTargets--明确告诉别人，我这个特性是专们用来标记在哪里的
             //8.AllowMultiple:是否可以重复标记
             //9.Inherited:是否可以继承特性 
            }

            //四、如何调用到特性内部的成员--自定义的这个特性，如果才能使用他呢？
            //1.进过反编译之后，在标记有特性的类的内部，生成了cutom的成员，但是我们不能直接调用；---要通过反射来调用的；要让特性生效，实际上来说是要去执行我们这个特性？---就需要构造特性的实例

            //特性标记后好像无法直接取调用他；好像没什么用；---当然是要用反射的
            //2.在使用反射获取特性的时候，可以把标记在任何地方的特性都可以获取到
            //3.既然标记的特性可以通过反射来获取到实例，就可以加以应用
            {
                //Student student = new Student()
                //{
                //    Id = 123,
                //    Name = "我与春风皆过客"
                //};
                ////student.custom//调用不到 
                // InvokeAttributeManager.Show(student);
            }


            //五、特性获取额外信息
            {
                //五-一、传统方式获取没聚聚
                {
                    //UserStateEnum userState = UserStateEnum.Normal;
                    ////1.传统方式如果要获取到描述--只能一层一层的判断
                    ////2.你们觉得这样好吗？
                    ////问题：
                    ////   a.分支判断太多了--如果增加一个枚举字段---就需要增加一个判断
                    ////   b.如果说描述信息改了呢？只要是是使用到这个枚举的地方--都需要修改这个描述信息----工作量剧增
                    //if (userState == UserStateEnum.Normal)
                    //{
                    //    Console.WriteLine("正常状态");
                    //}
                    //else if (userState == UserStateEnum.Frozen)
                    //{
                    //    Console.WriteLine("已冻结");
                    //}
                }
                //....
                //五-二.通过特性来获取描述信息---额外信息--特性获取额外信息
                {
                    //1.特性获取描述信息---获取额外信息
                    //好处：
                    //  a.如果增加字段，就可以直接获取不用其他的改动
                    //  b.描述修改后，获取描述信息的方法不用修改
                    //2.通过反射+特性+扩展方法，可以封装一个获取额外新的的公共方法
                    {
                        //UserStateEnum normal = UserStateEnum.Normal;
                        //UserStateEnum frozen = UserStateEnum.Frozen;
                        //UserStateEnum deleted = UserStateEnum.Deleted;
                        //UserStateEnum other = UserStateEnum.Other;
                        //UserStateEnum other1 = UserStateEnum.Other1;
                        //string strnormalRemark = RemarkAttributeExtension.GetRemark(normal);
                        //string strfrozenRemark = RemarkAttributeExtension.GetRemark(frozen);
                        //string strdeletedRemark = RemarkAttributeExtension.GetRemark(deleted);
                        //string strotherRemark = RemarkAttributeExtension.GetRemark(other);
                        //string strother1Remark = RemarkAttributeExtension.GetRemark(other1);
                    }
                    {
                        //UserStateEnum normal = UserStateEnum.Normal;
                        //UserStateEnum frozen = UserStateEnum.Frozen;
                        //UserStateEnum deleted = UserStateEnum.Deleted;
                        //UserStateEnum other = UserStateEnum.Other;
                        //UserStateEnum other1 = UserStateEnum.Other1;
                        //string strnormalRemark = normal.GetRemark();
                        //string strfrozenRemark = frozen.GetRemark();
                        //string strdeletedRemark = deleted.GetRemark();
                        //string strotherRemark = other.GetRemark();
                        //string strother1Remark = other1.GetRemark();

                    }

                    {
                        // //从数据库中查询出来一条数据； 
                        // UserInfo user = new UserInfo()
                        // {
                        //     Id = 1234,
                        //     Name = "暖风昔人",
                        //     Age = 25,
                        //     State = UserStateEnum.Normal
                        // }; 
                        // Console.WriteLine($"当前用户的状态为：{user.UserStateDescription}");


                        // UserInfo user1 = new UserInfo()
                        // {
                        //     Id = 1234,
                        //     Name = "暖风昔人",
                        //     Age = 25,
                        //     State = UserStateEnum.Frozen
                        // };
                        // Console.WriteLine($"当前用户的状态为：{user1.UserStateDescription}");

                        // UserInfo user2 = new UserInfo()
                        // {
                        //     Id = 1234,
                        //     Name = "暖风昔人",
                        //     Age = 25,
                        //     State = UserStateEnum.Deleted 
                        // };
                        // Console.WriteLine($"当前用户的状态为：{user2.UserStateDescription}"); 
                        ////编程这事儿，代码写的精妙了以后，其实一门艺术；
                    }
                }
            }

            //六、特性获取额外功能--在之前的基础上，新增一个功能
            {
                //1.如果要保存一条数据到数据库中去
                //2.从前端提交过来的数据格式为：
                //  {
                //     "id": 0,
                //     "name": "string",
                //     "age": 0,
                //     "state": 1
                //   }

                //3.包含了很多字；
                //4.如果数据库总Name的值要求存储的长度为40个字符--如果保存的数据超过40个字符---肯定会报错
                //5.肯定要在保存之前就需要验证这行数据

                //前端提交过来的数据 
                UserInfo adduse = new UserInfo() {
                    Id = 123,
                    Name = "456464",
                    Age = 25,
                    Mobile = "sdfsdf"
                };

                //六-一
                //1.传统方式：
                //问题：
                /// a. 太多的if判断
                /// b. 代码量太多

                {
                    //if (adduse.Name == null)
                    //{
                    //    Console.WriteLine("不能为空");
                    //}
                    //if (adduse.Name.Length > 40)
                    //{
                    //    Console.WriteLine("Name超长了");
                    //}
                    //if (adduse.Mobile.Length != 11)
                    //{
                    //    Console.WriteLine("手机号有问题");
                    //}
                }
                //六--二//特性了获取额外功能---特性来完成验证
                {
                    //增加了一个特性：可以对一个实体中的字段做验证-和验证不能为空
                    //1.通过特性加反射额外的获取了一个功能
                    //2.实体验证==特性获取额外信息+特性获取额外的来完成的

                    //好处：
                    //1.只要是把验证的规则特性定义好，就可以重新使用
                    //2.如果需要验证哪个属性，就把特性标记在哪个属性上就可以了；
                    //3.只是标记了一个特性，就可以获取了一个验证的逻辑

                    ApiResult bResult = ValidateInvokeManager.ValiDate<UserInfo>(adduse);
                    //验证一下QQ
                    //5位数---12位数 
                }
            }
            //七、特性在自定义ORM中的应用---自己完成
            //场景：如果我自定义的这个ORM中，对应数据库表的实体；
            //如果存在数据库中的表名称和类名称不一样
            //如果存在数据库表中的字段名称和类的属性名称不一样---怎么解决?[TableName]---对应表名称
            //[PropertuyName]---属性和表字段的  

            //可以通过特性来完成；
            {
                //SqlServerHelper helper = new SqlServerHelper();
                //SysUser sysUser = helper.Find<SysUser>(1);
            }
        }
    }
}
