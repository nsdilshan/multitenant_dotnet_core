using Core.Contracts;

namespace Core.Entities
{
    public class Branch : IClient
    {
        public Branch(string branchName, string location)
        {
            BranchName = branchName;
            Location = location;
        }

        protected Branch()
        {
        }

        public int BranchId { get; private set; }
        public string BranchName { get; private set; }
        public string Location { get; private set; }
        public string ClientId { get; set; }
    }
}