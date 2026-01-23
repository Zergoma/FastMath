using FastMath.Core.Extension;
using FastMath.Core.Models;
using FastMath.Core.Models.OperandOption;
using FastMath.Core.Models.Operations;

namespace FastMath.Core.Tests;

[TestClass]
public class OpExtensionTests
{

    [TestMethod]
    public void AddOpOperatorStr()
    {
        AdditionnalOp addOp = new();
        Assert.AreEqual("+", addOp.GetOperationStr());
    }

    [TestMethod]
    public void DivOpOperatorStr()
    {
        DivideOp divOp = new();
        Assert.AreEqual("/", divOp.GetOperationStr());
    }

    [TestMethod]
    public void MulOpOperatorStr()
    {
        MultiplyOp mulOp = new();
        Assert.AreEqual("x", mulOp.GetOperationStr());
    }

    [TestMethod]
    public void SouOpOperatorStr()
    {
        SubtractionOp souOp = new();
        Assert.AreEqual("-", souOp.GetOperationStr());
    }

    [TestMethod]
    public void AddOpGetOffuscated()
    {
        AdditionnalOp addOp = new() { Left = 10, Right = 20.2M };

        var left = addOp.GetOffuscatedValue(EOperationMask.left);
        Assert.AreEqual(10M, left);

        var right = addOp.GetOffuscatedValue(EOperationMask.right);
        Assert.AreEqual(20.2M, right);

        var resu = addOp.GetOffuscatedValue(EOperationMask.result);
        Assert.AreEqual(30.2M, resu);
    }

    [TestMethod]
    public void AddOpGetOffuscatedMax()
    {
        RandomOperandOption OperandOption1 = new(Value: 10, zeroAuthorized: true );
        RandomOperandOption OperandOption2 = new (Value: 10, zeroAuthorized: true);
        AdditionnalOp addOp = new() { Left = 10, Right = 20 };

        var left = addOp.GetOffuscatedValueMax(Models.EOperationMask.left, left: OperandOption1, right: OperandOption2);
        Assert.AreEqual(10M, left);

        var right = addOp.GetOffuscatedValue(Models.EOperationMask.right);
        Assert.AreEqual(20M, right);

        var resu = addOp.GetOffuscatedValue(Models.EOperationMask.result);
        Assert.AreEqual(30, resu);
    }

    [TestMethod]
    public void MulOpGetOffuscatedMax()
    {
        RandomOperandOption OperandOption1 = new(Value: 10, zeroAuthorized: true);
        RandomOperandOption OperandOption2 = new(Value: 10, zeroAuthorized: true);
        MultiplyOp mulOp = new() { Left = 10, Right = 20 };

        var left = mulOp.GetOffuscatedValueMax(Models.EOperationMask.left, left: OperandOption1, right: OperandOption2);
        Assert.AreEqual(10M, left);

        var right = mulOp.GetOffuscatedValue(Models.EOperationMask.right);
        Assert.AreEqual(20M, right);

        var resu = mulOp.GetOffuscatedValue(Models.EOperationMask.result);
        Assert.AreEqual(200, resu);
    }

    [TestMethod]
    public void BiggestOnLeftTestOk()
    {
        RandomOperandOption OperandOption1 = new(Value: 10, zeroAuthorized: true);
        RandomOperandOption OperandOption2 = new(Value: 20, zeroAuthorized: true);
        MultiplyOp mulOp = new() { Left = 10, Right = 20 };

        mulOp.BiggestOnLeft();

        
        Assert.AreEqual(20M, mulOp.Left);
    }
}
