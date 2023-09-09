using Business.DB.Interface;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Reflection
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory
    {
        // 创建MySqlHelper的时候，没有出现MySqlHelper；没有依赖于MySqlHelper
        // 依赖的是两个字符串：Business.DB.MySql.dll + Business.DB.MySql.MySqlHelper
        public static IDBHelper CreateInstance()
        {
            string ReflictionConfig = CustomConfigManager.GetConfig("ReflictionConfig");

            // Business.DB.MySql.MySqlHelper, Business.DB.MySql.dll
            string typeName = ReflictionConfig.Split(',')[0];
            string dllName = ReflictionConfig.Split(',')[1];

            //Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");
            //Type type = assembly.GetType("Business.DB.MySql.MySqlHelper");

            Assembly assembly = Assembly.LoadFrom(dllName);
            Type type = assembly.GetType(typeName);

            object? oInstance = Activator.CreateInstance(type);
            IDBHelper helper = oInstance as IDBHelper;
            return helper;
        }
    }

    public static class CustomConfigManager
    {
        // 读取配置文件：appsettings
        // 1. Microsoft.Extensions.Configuration;
        // 2. Mocrosoft.Extensions.Configuration.Json;
        public static string GetConfig(string key)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");   // 默认读取 当前运行目录
            IConfigurationRoot configuration = builder.Build();
            string configValue = configuration.GetSection(key).Value;
            return configValue;
        }
    }
}
