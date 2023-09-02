namespace CSharp_5._6._7._8._9._10.CSharp9._0
{
    public record Person(string FirstName, string LastName);
    record PersonChild(string FirstName, string LastName) : Person(FirstName, LastName)
    {
        /// <summary>
        /// 如果再有某一个记录继承自本记录，ToString方法不可以再被覆写
        /// </summary>
        /// <returns></returns>
        public sealed override string ToString()
        {
            return base.ToString();
        }
    }
    public class People
    {
        int position = -1;
        private Person[] _people { get; init; }
        public People(Person[] people)
        {
            _people = people;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public object Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                    throw;
                }
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            Reset();
        }
    }

    /// <summary>
    /// 使用扩展，把 GetEnumerator 方法扩展给 People类
    /// </summary>
    public static class PeopleExtensions
    {
        public static People GetEnumerator(this People people) => people;
    }
}
