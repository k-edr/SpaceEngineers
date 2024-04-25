using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript
{
    internal class MyTests : BaseTestClass
    {
        public MyTests():base()
        {
            AddTest(Test_Bool_IsTrue);
            AddTest(Test_Bool_IsFalse);
            AddTest(Test_Bool_ArgumentExceptionWait);
        }

        public void Test_Bool_IsTrue()
        {
            //Arrange

            bool isTrue = false;

            //Act

            if (!isTrue)
            {
                isTrue = true;
            }

            //Assert

            Assert.To(isTrue, Is.True);
        }

        public void Test_Bool_IsFalse()
        {
            //Arrange

            bool isTrue = false;

            //Act

            if (isTrue)
            {
                isTrue = true;
            }

            //Assert

            Assert.To(isTrue, Is.False);
        }

        public void Test_Bool_ArgumentExceptionWait()
        {
            //Arrange

            Action act = () => { throw new ArgumentException(); };

            //Assert

            Assert.To(act, new ArgumentException());
        }
    }
}
