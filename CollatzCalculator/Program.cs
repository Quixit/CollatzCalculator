using System;
using System.Numerics;

namespace CollatzCalculator
{
    class Program
    {
        static DataStore _values;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            _values = new DataStore();
            _values.Set(1, 4);

            ulong i = 1;

            try
            {

                for (i = 2; i <= int.MaxValue; i++)
                {
                    Operate(i);
                    Console.WriteLine(i);
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Out of Range based off {i}");
            }

            Console.ReadLine();
        }

        static void Operate(ulong value)
        {
            //already set
            if (_values.Get(value) != default)
            {
                return;
            }

            try
            {
                ulong nextValue;

                //Event
                if (value % 2 == 0)
                    nextValue = value / 2l;
                else
                    nextValue = (value * 3) + 1;

                _values.Set(value, nextValue);

                Operate(nextValue);
            }
            catch (OverflowException overflow)
            {
                Console.WriteLine($"Overflow at value: {value}. {overflow.Message}");
            }
        }
    }

    public class DataStore
    {
        const int _maxIndex = 0X7FEFFFFF;
        ulong[][] _store = new ulong[_maxIndex][];

        public ulong Get(ulong i)
        {
            var two = (i % _maxIndex);
            var one = (two == i ? 0 : (i - two) / _maxIndex);

            if (_store[one] == null)
                return default;

            return _store[one][two];
        }

        public void Set(ulong i, ulong value)
        {
            var two = (i % _maxIndex);
            var one = (two == i ? 0 : (i - two) / _maxIndex);

            if (_store[one] == null)
                _store[one] = new ulong[_maxIndex];

            _store[one][two] = value;
        }
    }
}
