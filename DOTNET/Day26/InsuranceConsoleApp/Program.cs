
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    public class Program
    {
        static PolicyService service = new PolicyService();
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add Policy\n2. View All Policies\n3. Search Policy By Id\n4. Update Policy\n5. Delete Policy\n0. Exit");
                Console.WriteLine("Enter Choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }
                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    addPolicy();
                }
                else if (choice == 2)
                {
                    viewPolicies();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter ID : ");
                    int id = int.Parse(Console.ReadLine());
                    searchPoliyById(id);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter Id to update policy: ");
                    int idUpdate=int.Parse(Console.ReadLine());
                    updatePolicy(idUpdate);
                }
                else if (choice == 5)
                {
                    Console.Write("Enter ID : ");
                    int id = int.Parse(Console.ReadLine());
                    deletePolicyById(id);
                }
            }
        }

        private static void deletePolicyById(int id)
        {
            bool possible = service.DeactivatePolicy(id);
            if (!possible)
            {
                Console.WriteLine("Couldn't find id");
            }
            else
            {

                Console.WriteLine("Deleted Successfully");
            }
        }

        private static void updatePolicy(int id)
        {
            Console.Write("Enter Premium Amount: ");
            int newPremium=int.Parse(Console.ReadLine());
            Console.Write("Enter Policy Term: ");
            int newTerm= int.Parse(Console.ReadLine());
            bool possible=service.UpdatePolicy(id, newPremium, newTerm);
            if (!possible)
            {
                Console.WriteLine("couldn't find id");
            }
            else
            {
                InsurancePolicy policy = service.GetPolicyById(id);
                if (policy == null)
                {
                    Console.WriteLine("Couldn't find id");
                }
                else
                {
                    Console.WriteLine("Fetching Details: ");
                    Console.WriteLine("------------------Policy Details--------------------\n");
                    Console.WriteLine("PolicyId\tPolicy Holder Name\tPolicy Type\tPremium Amount\tPolicy Term\tStatus");

                    Console.WriteLine(policy.ToString());
                    Console.WriteLine("------------------------------------------------------");
                }

            }

        }

        private static void searchPoliyById(int id)
        {
            InsurancePolicy policy = service.GetPolicyById(id);
            if (policy == null)
            {
                Console.WriteLine("Couldn't find id");
            }
            else
            {
                Console.WriteLine("Fetching Details: ");
                Console.WriteLine("------------------Policy Details--------------------\n");
                Console.WriteLine("PolicyId\tPolicy Holder Name\tPolicy Type\tPremium Amount\tPolicy Term\tStatus");
                Console.WriteLine(policy.ToString());
                Console.WriteLine("------------------------------------------------------");
            }
        }

        private static void viewPolicies()
        {
            InsurancePolicy[] policies = service.GetAllPolicies();
            policies =service.GetAllPolicies();
            Console.WriteLine("------------------Policy Details--------------------\n");
            Console.WriteLine("PolicyId\tPolicy Holder Name\tPolicy Type\tPremium Amount\tPolicy Term\tStatus");
            Console.WriteLine("________________________________________________________________________________________________\n");
            foreach (InsurancePolicy policy in policies)
            {
                if (policy.IsActive)
                {
                    Console.WriteLine(policy.ToString());
                }
                
            }
        }

        static void addPolicy()
        {
            Console.WriteLine("Enter details seperated with commas(,) PolicyId,PolicyHolderName,PolicyType(Health / Life / Vehicle),PremiumAmount,PolicyTerm,IsActive");
            string policyDetails = Console.ReadLine();
            string[] inputSplit = policyDetails.Split(",");
            InsurancePolicy[] policies = service.GetAllPolicies();
            policies = service.GetAllPolicies();
            foreach(InsurancePolicy pol in policies)
            {
                if(pol.PolicyId== int.Parse(inputSplit[0]))
                {
                    Console.WriteLine("Id already exist");
                    return;
                }
            }

            if (!int.TryParse(inputSplit[0], out int policyId) ||
                !decimal.TryParse(inputSplit[3], out decimal premium) ||
                !int.TryParse(inputSplit[4], out int term) ||
                !bool.TryParse(inputSplit[5], out bool isActive))
            {
                Console.WriteLine("Invalid input format");
                return;
            }

            InsurancePolicy policy = new InsurancePolicy(
                policyId,
                inputSplit[1],
                inputSplit[2],
                premium,
                term,
                isActive
            );
            service.AddPolicy(policy);
            Console.WriteLine("Policy Added Successfully");
        }
    }
}
