using Zhaoxi.DbProxy;
using Zhaoxi.DBProxy.Models.Models;

namespace Zhaoxi.DBProxyTest {
    public class Program {
        static void Main(string[] args) {

            try {

                DBProxyCore dbProxyCore = new DBProxyCore();
                {
                    // Commodity commodity = dbProxyCore.GetCommodity(1);
                }
                // 到这里已经有了面向对象操作数据库

                // 一个方法满足不同的实体查询，一个方法满足不同实体通用的查询诉求 --泛型
                // 一、泛型
                // 1.泛型方法、泛型类、泛型接口、泛型委托
                // 2.泛型约束
                // 3.泛型缓存
                // 4.泛型协变逆变

                Commodity commodity = dbProxyCore.Find<Commodity>(1);
                Syscompany company = dbProxyCore.Find<Syscompany>(1); // 当前存在问题，sql语句写死了；

                // 要给对象的属性赋值，不能通过new一个对象，直接调用对象的属性赋值；可以怎么做？ -- 使用反射
                // 反射：
                // 1.反射的应用，反射创建对象，各种调用方法
                // 2.反射和科技（破坏单例）
                // 3.反射调用属性字段

                // 到现在Find --泛型的--可以传入任何类型，带有无参数构造函数约束，只要四无参数构造的类都可以传递进来。

                //dbProxyCore.Find<Program>(123123);  // 这样写存在问题。
                // 封装框架--高级核心开发，架构师做的事。要尽可能让使用这个框架的开发者没有犯错的机会。
                // 缩小泛型的使用机会，给一个约束，必要要符合某个条件，才能允许来调用我的方法。 -- 泛型的基类约束
                // 泛型约束：
                // 基类约束
                // 接口约束
                // 无参数构造函数约束
                // 引用类型约束
                // 值类型约束
                // 枚举约束
                

                Console.ReadKey();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }
        }

    }
}