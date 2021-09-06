using System;
using System.Numerics;
using System.Threading.Tasks;

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

            long i = 1;

            try
            {

                Parallel.For(2, int.MaxValue, (i) =>
                {
                    Operate(i);
                    Console.WriteLine(i);
                });

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Out of Range based off {i}");
            }
            catch (StackOverflowException)
            {
                Console.WriteLine($"Stack overflow based off {i}");
            }

            Console.ReadLine();
        }

        static void Operate(long value)
        {
            //already set
            if (_values.Get(value) != default || value == 1)
            {
                return;
            }

            try
            {
                long nextValue;

                //Event
                if (value % 2 == 0)
                    nextValue = value / 2L;
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
        //const int _maxIndex = 0X7FEFFFFF;
        //ulong[][] _store = new ulong[_maxIndex][];

        public ulong Get(long i)
        {
            return default;

            //var two = (i % _maxIndex);
            //var one = (two == i ? 0 : (i - two) / _maxIndex);

            //if (_store[one] == null)
            //    return default;

            //return _store[one][two];
        }

        public void Set(long i, long value)
        {
            //var two = (i % _maxIndex);
            //var one = (two == i ? 0 : (i - two) / _maxIndex);

            //if (_store[one] == null)
            //    _store[one] = new ulong[_maxIndex];

            //_store[one][two] = value;
        }
    }
}
