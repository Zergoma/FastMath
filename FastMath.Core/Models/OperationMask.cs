namespace FastMath.Core.Models
{
    public class OperationMask
    {
        private Random rdm = Random.Shared;
        public OperationMasked Masked { get; set; }

        public OperationMask()
        {
            RandIt();
        }
        private void RandIt()
        {
            int val = rdm.Next(3);
            Masked = val switch
            { 
                0 => OperationMasked.left,
                1 => OperationMasked.right,
                2 => OperationMasked.result,
                3 => OperationMasked.none,
                _ => OperationMasked.result,
            };
        }
    }
}
