namespace CSharp_5._6._7._8._9._10.CSharp9._0
{
    public record Person1(string FirstName, string LastName);

    public record Person2
    {
        public Person2()
        {
            FirstName = "1234556";
            LastName = "一二三四五六";
        }
        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
    };

    public record Person3
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }

    public record Person4(string FirstName, string LastName, string[] PhoneNumbers);
}
