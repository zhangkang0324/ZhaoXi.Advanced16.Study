namespace CSharp_5._6._7._8._9._10.CSharp8._0
{
    public interface IStudent   // 接口表示“能做什么”，类表示“是什么”
    {
        public int GetAge();

        // 感觉最新的比较奇怪，接口竟然可以有方法体实现
        public string GetName()
        {
            return "张三同学";
        }
    }
}
