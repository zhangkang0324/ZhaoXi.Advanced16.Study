using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute {
    public class InvokeAttributeManager {
        /// <summary>
        /// 通过反射来调用特性---确实是可以调用到特性的实例的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Show(Student student) {
            //Type type = typeof(Student);
            Type type = student.GetType();
            //1.先判断是否有特性
            if (type.IsDefined(typeof(CustomAttribute), true)) {
                //2.获取--先判断再获取--为了提高性能
                foreach (CustomAttribute attribute in type.GetCustomAttributes(true)) {
                    Console.WriteLine($"attribute._Name:{attribute._Name}");
                    Console.WriteLine($"attribute._Age:{attribute._Age}");
                    attribute.Do();
                }
            }

            //获取当前Type下所有的属性上标记的特性
            foreach (PropertyInfo prop in type.GetProperties()) {
                if (prop.IsDefined(typeof(CustomAttribute), true)) {
                    //2.获取--先判断再获取--为了提高性能
                    foreach (CustomAttribute attribute in prop.GetCustomAttributes(true)) {
                        Console.WriteLine($"attribute._Name:{attribute._Name}");
                        Console.WriteLine($"attribute._Age:{attribute._Age}");
                        attribute.Do();
                    }
                }
            }

            //获取当前Type下所有的字段上标记的特性
            foreach (FieldInfo field in type.GetFields()) {
                if (field.IsDefined(typeof(CustomAttribute), true)) {
                    //2.获取--先判断再获取--为了提高性能
                    foreach (CustomAttribute attribute in field.GetCustomAttributes(true)) {
                        Console.WriteLine($"attribute._Name:{attribute._Name}");
                        Console.WriteLine($"attribute._Age:{attribute._Age}");
                        attribute.Do();
                    }
                }
            }

            //获取当前Type下所有的方法上标记的特性
            foreach (MethodInfo method in type.GetMethods()) {
                foreach (ParameterInfo para in method.GetParameters()) {
                    if (para.IsDefined(typeof(CustomAttribute), true)) {
                        //2.获取--先判断再获取--为了提高性能
                        foreach (CustomAttribute attribute in para.GetCustomAttributes(true)) {
                            Console.WriteLine($"attribute._Name:{attribute._Name}");
                            Console.WriteLine($"attribute._Age:{attribute._Age}");
                            attribute.Do();
                        }
                    }
                }


                if (method.IsDefined(typeof(CustomAttribute), true)) {
                    //2.获取--先判断再获取--为了提高性能
                    foreach (CustomAttribute attribute in method.GetCustomAttributes(true)) {
                        Console.WriteLine($"attribute._Name:{attribute._Name}");
                        Console.WriteLine($"attribute._Age:{attribute._Age}");
                        attribute.Do();
                    }
                }
            }



        }
    }
}
