const customers = [
{ id: 1, name: "Ravi", age: 32, policy: "Health", premium: 4800, active: true },
{ id: 2, name: "Anita", age: 51, policy: "Life", premium: 12000, active: true },
{ id: 3, name: "Kiran", age: 28, policy: "Vehicle", premium: 3500, active: false },
{ id: 4, name: "Meena", age: 45, policy: "Health", premium: 6000, active: true },
{ id: 5, name: "Suresh", age: 60, policy: "Life", premium: 18000, active: false }
];
console.log(customers);

// Bug 1: Loop Output Issue
// for (let i = 0 ; i <= customers.length; i++) {
// console.log(customers [i].name);
// }
// Solution - array index starts from 0 to length-1 hence use < instead of <=
console.log('Bug 1 Solution');
for (let i = 0 ; i < customers.length; i++) {
console.log(customers [i].name);
}
// Bug 2: filter() Not Working
// const activeCustomers = customers.filter((c) => {
// c.active === true;
// });
// Hint: Return value
//Solution - add return statement/remove curly braces
console.log('Bug 2 Solution');
const activeCustomers = customers.filter((c) => 
c.active === true
);
console.log(activeCustomers);
// Bug 3: Premium Increase Logic Broken
// const updatedPremiums = customers.map((c) => {
// if (c. age >= 50 )
// c.premium = c.premium * 1.1;
// }
// );


//Solution1-as it is a map we cant expect the updatedPremiums will have 
// const updatedPremiums = customers.map((c) => {
// if (c. age >= 50 )
// c.premium = c.premium * 1.1;
// return c;
// }
// );
// console.log('Bug 3 Solution');

// updatedPremiums.filter(c=>c.age>50).map((c)=>console.log(`Name: ${c.name}, Premium: ${c.premium}`));
//Solution2- use copy of object to avoid mutating original array
const updatedPremiums = customers.map((c) => {
  if (c.age >= 50) {
    return { ...c, premium: c.premium * 1.1 };
  }
  return c;
});
console.log('Bug 3 Solution');
updatedPremiums.filter(c=>c.age>=50).map((c)=>console.log(`Name: ${c.name}, Premium: ${c.premium}`));
// Bug 4: Wrong Total Premium Calculation
// const totalPremium = customers.reduce((total, c) =>  {
// total + c.premium;
// }, 0);
// Hint: reduce return
// Solution - add return statement/remove curly braces
const totalPremium = customers.reduce((total, c)  => 
total + c.premium
, 0);
console.log('Bug 4 Solution');
console.log(`Total Premium: ${totalPremium}`);

const totalPremium1 = customers.reduce((total, c)  => {
return total + c.premium
}, 0);
console.log('Bug 4 Solution -Alternative');
console.log(`Total Premium: ${totalPremium1}`);

// Bug 5: Template Literal Not Printing
// console.log("Customer ${customers[0].name} has policy ${customers[0].policy}");
// Hint: Quotes type
console.log('Bug 5 Solution');
console.log(`Customer ${customers[0].name} has policy ${customers[0].policy}`);

// Bug 6: Policy Count Incorrect
// const policyCount = customers.reduce((count, c) => {
// count.policy = (count.policy || 0) + 1;
// return count;
// }, {});
// Q Hint: Dynamic object key
console.log('Bug 6 Solution');
const policyCount = customers.reduce((count, c) => 
{
count[c.policy]=((count[c.policy])||0)+1//if exists increment else initialize to 1
return count;
},{});
console.log(policyCount);

// Bug 7: Risk Level Always Undefined
// const customersWithRisk = customers.map((c) => {
// let riskLevel;
// if (c. age < 35 ) riskLevel = "Low";
// if (c. age <= 5theta ) riskLevel = "Medium";
// else riskLevel = "High";
// return { ...c, riskLevel };
// });
// Hint: Condition chaining

// Solution - use else if for proper chaining
console.log('Bug 7 Solution');
const customersWithRisk = customers.map((c) => {
let riskLevel;
if (c. age < 35 ) riskLevel = "Low";
else if (c. age <= 50 ) riskLevel = "Medium";
else riskLevel = "High";
return { ...c, riskLevel };
});
customersWithRisk.forEach(c => console.log(`name:${c.name},age:${c.age},risklevel:${c.riskLevel}`));

// Bug 8: Active vs Inactive Count Wrong
// let active = 0,
// inactive = 0;
// for (const c in customers) {
// if (c.active) active++;
// else inactive++;
// }
// Hint: for...in vs for...of
console.log('Bug 8 Solution');
let active = 0,
inactive = 0;
for (const c of customers) {
if (c.active) active++;
else inactive++;
}
//for in iterates with index,for of iterates with object
console.log(`Active: ${active}, Inactive: ${inactive}`);

// Bug 9: Arrow Function Syntax Error
// const getLifeCustomers = () =>
// customers.filter((c) => c.policy === "Life").map((c) =>
// c.name);
// Hint: Arrow function return

const getLifeCustomers = customers.filter((c) => c.policy === "Life").map((c) =>c.name);
//remove parentheses where implicit return is expected here function can be called directly without parentheses
console.log('Bug 9 Solution');
console.log(getLifeCustomers);

console.log('Bug 9 Solution -Alternative');
//use curly braces and return statement
const getLifeCustomers1 = () =>{
return customers.filter((c) => c.policy === "Life").map((c) =>
c.name)
};
console.log(getLifeCustomers1());

// Bug 10: Sorting Mutates Original Array
// const sorted Customers = customers.sort((a, b) => b.premium
// a.premium);
// Hint: Array mutation

// Solution - create a copy of array before sorting hence original array remains unchanged
//[...array] creates a shallow copy of the array
const sortedCustomers1 = [...customers].sort((a, b) => b.premium - a.premium);
console.log('Bug 10 Solution');
console.log(sortedCustomers1);
console.log(customers);

