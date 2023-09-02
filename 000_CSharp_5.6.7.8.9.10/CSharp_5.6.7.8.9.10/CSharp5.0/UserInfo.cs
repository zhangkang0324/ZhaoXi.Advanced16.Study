namespace CSharp_5._6._7._8._9._10.CSharp5._0
{
    internal class UserInfo
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string GetUserName() => this.Name;

        public Task Show()
        {
            return Task.FromResult(0);
        }

        public async Task ShowAsync()
        {
            // 5.0之前不支持async和await
            await Task.FromResult(0);
        }
    }
}
