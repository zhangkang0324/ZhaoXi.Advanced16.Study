using Business.DB.Interface;
using Business.DB.MySql;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Reflection
{
    public class SimpleFactory
    {
        public static IDBHelper CreateInstance()
        {
            // string ReflectionConfig = CustomConfigManager.GetConfig("ReflectionConfig");
            Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");
            Type type = assembly.GetType("Business.DB.MySql.MySqlHelper");
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
