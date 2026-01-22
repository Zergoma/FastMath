using FastMath.Core.Models.Operations;

namespace FastMath.Core.Tests
{
    [TestClass]
    public sealed class OpTests
    {
        [TestMethod]
        public void AddOpOK()
        {
            AdditionnalOp op = new()
            { Left = 1, Right = 2 };

            var resu = op.Compute();

            Assert.AreEqual(3, resu);
        }

        [TestMethod]
        public void AddOpNOK()
        {
            AdditionnalOp op = new()
            { Left = 1, Right = 2 };

            var resu = op.Compute();

            Assert.AreNotEqual(99, resu);
        }

        [TestMethod]
        public void DiveOpOK()
        {
            DivideOp op = new()
            { Left = 9, Right = 3 };

            var resu = op.Compute();

            Assert.AreEqual(3, resu);
        }

        [TestMethod]
        public void DiveOpNOK()
        {
            DivideOp op = new()
            { Left = 10, Right = 3 };

            var resu = op.Compute();

            Assert.AreNotEqual(3, resu);
        }

        [TestMethod]
        public void DiveOpZero()
        {
            DivideOp op = new()
            { Left = 10, Right = 0 };

            Assert.Throws<DivideByZeroException>( () => op.Compute());
        }


        [TestMethod]
        public void DiveOpZeroDecimal()
        {
            DivideOp op = new()
            { Left = 10, Right = 0.0M };

            Assert.Throws<DivideByZeroException>(() => op.Compute());
        }
    }
}
