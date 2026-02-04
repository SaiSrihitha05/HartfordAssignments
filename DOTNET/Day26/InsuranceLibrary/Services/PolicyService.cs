using InsuranceLibrary.Models;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private InsurancePolicy[] policies = new InsurancePolicy[5]; 
        private int count = 0;

        public PolicyService()
        {
            policies[count++] = new InsurancePolicy(101, "Ravi", "Life", 10000.09m, 10, true);
            policies[count++] = new InsurancePolicy(102, "Hema", "Health", 30000.98m, 5, true);
        }

        public bool AddPolicy(InsurancePolicy policy)
        {
            if (count >= policies.Length)
                return false; 

            for (int i = 0; i < count; i++)
            {
                if (policies[i].PolicyId == policy.PolicyId)
                    return false; 
            }

            policies[count++] = policy;
            return true;
        }

        public InsurancePolicy[] GetAllPolicies()
        {
            InsurancePolicy[] result = new InsurancePolicy[count];
            Array.Copy(policies, result, count);
            return result;
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (policies[i].PolicyId == id)
                    return policies[i];
            }
            return null;
        }

        public bool UpdatePolicy(int id, decimal newPremium, int newTerm)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null || !policy.IsActive)
                return false;

            policy.PremiumAmount = newPremium;
            policy.PolicyTerm = newTerm;
            return true;
        }

        public bool DeactivatePolicy(int id)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null)
                return false;

            policy.IsActive = false;
            return true;
        }
    }
}
