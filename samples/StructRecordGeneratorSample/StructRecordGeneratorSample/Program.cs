﻿//using System;
//using System.Text;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using StructGenerators;
#nullable disable
namespace StructRecordGeneratorSample
{
    [StructGenerators.StructEquality]
    public partial struct Point3
    {
        public double X { get; init; }
        public double Y { get; init; }
    }

    [StructGenerators.StructEquality]
    partial struct S1
    {
        private readonly int x1;
        private int x3 => 42;
        private int x4 { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [StructGenerators.StructEquality]
    public partial struct S2
    {
        public double X { get; }
        //public S1(double x) => (X) = x;
    }

    //public record X(int X) {

    //}

    //public class XY : X
    //{

    //}

    public struct S3
    {
        public byte B { get; }
        public double X { get; }
        //public S2(double x) => (X, B) = (x, 0);
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // The first line prints 'False',
    //        // because S1 is properly packed and the runtime uses
    //        // a bit-wise comparison for two instances.
    //        // And even though -0.0 is equals to +0.0 they do have
    //        // a different binary representation, so the result is false.
    //        Console.WriteLine(new S1(-0.0).Equals(new S1(+0.0))); // False

    //        // The next line prints 'True',
    //        // because the optimized version of ValueType.Equals
    //        // can't be used here, because S2 is not properly packed!
    //        Console.WriteLine(new S2(-0.0).Equals(new S2(+0.0))); // True
    //    }
    //}

    //    [StructGenerators.StructEquality]
    //    public partial struct F(int x, string y)
    //    { }

    //[StructGenerators.StructEquality]
    //public partial struct S
    //{
    //    private F f;
    //    private StringBuilder sb;
    //    public double D { get; }
    //    public S(double d) => (D, f, sb) = (d, new F(), null);
    //}


    //[StructGenerators.GenerateToString(MaxStringLength = 1000, PrintTypeName = false)]
    //public readonly partial struct CustomRecord
    //{
    //    [StructGenerators.ToStringImpl(Skip = true)]
    //    public readonly double X;
    //    public readonly int Y;
    //    public readonly int Z;
    //    public int Foo => 42;
    //    static readonly string _staticProperty;
    //}


    public record CustomRecord<T>
    {
        public T Value { get; set; }
    }

    [GenerateToString]
    public partial class CustomClass<T>
    {
        public T Value { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var cs = new CustomClass<int>();
            // No allocations here
            Console.WriteLine(cs.ToString());

            var cr = new CustomRecord<int>();
            // cr.ToString() calls StringBuilder.Append(Value)
            // that causes a boxing allocation!
            Console.WriteLine(cr.ToString());

            //var ms = new MyStruct2();
            //Console.WriteLine(ms);
        }


    }
}


/*
 *     [GenerateToString]
    public partial class CustomClass<T>
    {
        public string[] S = new[] {"1", null, "2"};
        
        public T Value { get; set; }
        
        [ToStringImpl(Skip = true)]
        public int Ignore { get; set; }
    }

 * */