using FastMath.Core.Extension;
using FastMath.Core.Models;
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
        SoustractionOp souOp = new();
        Assert.AreEqual("-", souOp.GetOperationStr());
    }

    [TestMethod]
    public void AddOpGetOffuscated()
    {
        AdditionnalOp addOp = new() { Left = 10, Right = 20.2M };

        var left = addOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.left });
        Assert.AreEqual(10M, left);

        var right = addOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.right });
        Assert.AreEqual(20.2M, right);

        var resu = addOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.result });
        Assert.AreEqual(30.2M, resu);
    }

    [TestMethod]
    public void AddOpGetOffuscatedMax()
    {
        ComputeOperandOption OperandOption1 = new(randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true );
        ComputeOperandOption OperandOption2 = new (randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true);
        AdditionnalOp addOp = new() { Left = 10, Right = 20 };

        var left = addOp.GetOffuscatedValueMax(new() { Masked = Models.OperationMasked.left }, left: OperandOption1, right: OperandOption2);
        Assert.AreEqual(10M, left);

        var right = addOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.right });
        Assert.AreEqual(20M, right);

        var resu = addOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.result });
        Assert.AreEqual(30, resu);
    }

    [TestMethod]
    public void MulOpGetOffuscatedMax()
    {
        ComputeOperandOption OperandOption1 = new(randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true);
        ComputeOperandOption OperandOption2 = new(randOrFixed: OperandDof.randomized, maxOrValue: 10, zeroAuthorized: true);
        MultiplyOp mulOp = new() { Left = 10, Right = 20 };

        var left = mulOp.GetOffuscatedValueMax(new() { Masked = Models.OperationMasked.left }, left: OperandOption1, right: OperandOption2);
        Assert.AreEqual(10M, left);

        var right = mulOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.right });
        Assert.AreEqual(20M, right);

        var resu = mulOp.GetOffuscatedValue(new() { Masked = Models.OperationMasked.result });
        Assert.AreEqual(200, resu);
    }
}
