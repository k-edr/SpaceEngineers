using IngameScript.PulseTesting.Assertion;
using IngameScript.PulseTesting.Models;
using System;

namespace IngameScript.PulseTesting.Testing
{
    class PulseDemoTests :TestClass
    {
        public PulseDemoTests()
        {
            Add(EveryTimePassTest);

            Add(EveryTimePassTestWithParams, 1);
            Add(EveryTimePassTestWithParams, 1, 2);
            Add(EveryTimePassTestWithParams, 1, 2, 3);
            Add(EveryTimePassTestWithParams, 1, 2, 3, 4);

            Add(EveryTimePassTestWithParams, new[] { 1 });
            Add(EveryTimePassTestWithParams, new[] { 1 }, new[] { 2 });
            Add(EveryTimePassTestWithParams, new[] { 1 }, new[] { 2 }, new[] { 3 });
            Add(EveryTimePassTestWithParams, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 });

            Add(EveryTimePassTestWithParamsAnotherName, 1, 2);

            Add(EveryTimeFallTest);

            Add(EveryTimeFallTestWithParams, 1);
            Add(EveryTimeFallTestWithParams, 1, 2);
            Add(EveryTimeFallTestWithParams, 1, 2, 3);
            Add(EveryTimeFallTestWithParams, 1, 2, 3, 4);

            Add(EveryTimeFallTestWithParams, new[] { 1 });
            Add(EveryTimeFallTestWithParams, new[] { 1 }, new[] { 2 });
            Add(EveryTimeFallTestWithParams, new[] { 1 }, new[] { 2 }, new[] { 3 });
            Add(EveryTimeFallTestWithParams, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 });

            Add(SumOfTwoEqualToThird, 1, 2, 3);
            Add(SumOfTwoArraysEqualToThird, new[] { 1, 2 }, new[] { 1, 2 }, new[] { 2, 4 });

            Add(ActionThrowArgumentException, new ArgumentException());//passed
            Add(ActionThrowArgumentException, new ArgumentNullException());//falled
        }

        void EveryTimePassTest(){}

        void EveryTimePassTestWithParams(int a){ }
        void EveryTimePassTestWithParams(int a,int b){ }
        void EveryTimePassTestWithParams(int a,int b,int c){ }
        void EveryTimePassTestWithParams(int a,int b,int c,int d){ }

        void EveryTimePassTestWithParams(int[] a) { }
        void EveryTimePassTestWithParams(int[] a, int[] b) { }
        void EveryTimePassTestWithParams(int[] a, int[] b, int[] c) { }
        void EveryTimePassTestWithParams(int[] a, int[] b, int[] c, int[] d) { }

        void EveryTimePassTestWithParamsAnotherName(int a, int b) { }


        void EveryTimeFallTest() { throw new Exception("Should be excepted"); }

        void EveryTimeFallTestWithParams(int a) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int a,int b) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int a,int b,int c) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int a, int b,int c, int d) { throw new Exception("Should be excepted"); }

        void EveryTimeFallTestWithParams(int[] a) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int[] a, int[] b) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int[] a, int[] b, int[] c) { throw new Exception("Should be excepted"); }
        void EveryTimeFallTestWithParams(int[] a, int[] b, int[] c, int[] d) { throw new Exception("Should be excepted"); }

        void SumOfTwoEqualToThird(int a, int b, int c)
        {
            int temp = a + b;

            Assert.That(temp, c);
        }

        void SumOfTwoArraysEqualToThird(int[] a, int[] b, int[] c)
        {

            int[] temp = new int[a.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = a[i] + b[i];
            }

            Assert.That(temp, c);
        }

        void ActionThrowArgumentException<E>(E exception) where E : Exception
        {
            Action action = () => { throw new ArgumentException(); };

            Assert.That(action, exception);
        }

    }
}
