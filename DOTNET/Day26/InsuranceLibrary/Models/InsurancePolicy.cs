using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public InsurancePolicy(int policyId,string policyHolderName,string policyType,decimal premiumAmount,int policyTerm,bool isActive)
        {
			this.PolicyId = policyId;
			this.PolicyHolderName = policyHolderName;
			this.PolicyType = policyType;
			this.PremiumAmount = premiumAmount;
			this.PolicyTerm = policyTerm;
			this.IsActive = isActive;
        }

		//props
        private int policyId;

		public int PolicyId
		{
			get { return policyId; }
			set { policyId = value; }
		}

		private string policyHolderName;

		public string PolicyHolderName
		{
			get { return policyHolderName; }
			set { policyHolderName = value; }
		}

		private string policyType;

		public string PolicyType
		{
			get { return policyType; }
			set { policyType = value; }
		}
		private decimal premiumAmount;

		public decimal PremiumAmount
		{
			get { return premiumAmount; }
			set { premiumAmount = value; }
		}

		private int policyTerm;

		public int PolicyTerm
		{
			get { return policyTerm; }
			set { policyTerm = value; }
		}
		private bool isActive;

		public bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

        public override string ToString()
        {
			string res = String.Empty;
            res += $"{policyId}\t\t{policyHolderName}\t\t\t{policyType}\t\t{premiumAmount}\t{policyTerm}\t\t{isActive}";
            return res;
        }
	}
}
