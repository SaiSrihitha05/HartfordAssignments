// Task 1- Select by ID
// Change the dashboard title text to "Customer Insurance Overview".
document.getElementById("pageTitle").textContent="Customer Insurance Overview";

// Task 2- Select by Tag Name
// Select all <li> elements and:
// Add a border
// Log the total number of customers
let listCustomers=document.getElementsByTagName("li");
for(i of listCustomers){
i.style.border='1px solid black';
}
console.log(listCustomers.length)

// Task 3- Select by Class Name
// Select all policy elements and:
// Add highlight class
// Change text color to blue

let policyEle=document.getElementsByClassName("policy");
for(i of policyEle){
i.classList.add("highlight");
i.style.color="blue";

}
// console.log(i.classList);

// Task 4- Select using CSS Selectors
// Select the first customer only
// Select all customers
// Mark the last customer as active

let firstcustomer=document.querySelector(".customer");
let customers=document.querySelectorAll(".customer");
let len=customers.length;
let lastCustomer=document.querySelectorAll(".customer")[len-1];
console.log('First Customer',firstcustomer.innerHTML);
console.log('All Customers',customers);
console.log('Last Customer',lastCustomer.innerHTML);
lastCustomer.classList.add("active")
//Alternative
let lastChild=document.querySelector(".customer:last-child");
console.log('Last Customer',lastChild.innerHTML);

// Task 5- HTML Object Collections
// Using document collections:
// Count number of forms
// Get number of images
// Change text of all links to "More Info"
let noOfForms=0;
let noOfImages=0;
noOfForms=document.querySelectorAll("form").length;
noOfImages=document.querySelectorAll("img").length;
let arr=document.getElementsByTagName("a");
let arr1=document.getElementsByTagName("li");
for(let i of arr){
    i.innerHTML="More Info";
}
console.log('No.of Forms',noOfForms)
console.log('No.of Images',noOfImages);
console.log("No of List elements",arr1.length);


// Task 6- Add a new customer dynamically and observe:
// Which selections update automatically?
// Which don't?
let li1=document.createElement("li");
li1.classList.add("customer");
li1.innerHTML="Srihitha Vehicle";
document.getElementById("customerList").appendChild(li1);

console.log(document.getElementById("customerList").children);

// When a new customer is added dynamically, styles applied earlier do not affect new elements unless reapplied. NodeLists created do not include newly added elements.


// Task 7 - Attribute-Based Selection
// Select only input fields whose type is "text" using CSS selectors and:
// Add a yellow background 
// Add placeholder text: "Enter Full Name"

let inputFields = document.querySelectorAll('input[type="text"]');
for(let i of inputFields){
    i.style.backgroundColor="yellow";   
    i.setAttribute("placeholder","Enter full name");
}

// Task 8 - Multiple Class Selection
// Select all elements that have both customer and active classes and:
// Change text color to dark green
// Add text (Priority Customer) at the end
let customerListWithBothClasses=document.querySelectorAll(".customer.active");
for(let i of customerListWithBothClasses){
    i.style.color="darkgreen";
    i.innerHTML+='(Priority Customer)';
}


// Task 9 - Descendant vs Child Selector
// Select all <li> elements inside #customerList using a descendant selector
// Select only direct child <li> using a child selector
// Log the difference in console.
let descendantSelectionCustomers = document.querySelectorAll("#customerList .customer");
console.log(descendantSelectionCustomers);

let childSelectorCustomers=document.querySelectorAll("#customerList > .customer");
console.log(childSelectorCustomers);


// Task 10 - Even / Odd Selection (CSS Pseudo Selectors)
// Using querySelectorAll():
// Highlight even customers in light gray
// Highlight odd customers in light blue
// Hint: :nth-child()
let evenChild=document.querySelectorAll(".customer:nth-child(2n+2)");
for(i of evenChild){
    i.style.backgroundColor="lightgray"
}

let oddChild=document.querySelectorAll(".customer:nth-child(odd)");
for(i of oddChild){
    i.style.backgroundColor="lightblue"
}

// Task 11 - Form Elements Collection
// Using HTML form object model:
// Access the enquiry form
// Log all input field names
// Disable the submit button
let ele= document.forms["enquiryForm"].elements;


for(j of ele){
    if(j.tagName==="INPUT"){
        console.log(j.name);
    }
    if(j.tagName==="BUTTON" && j['type']==="submit" && j.innerHTML==="Submit"){
        j.disabled=true;
    }
}

// Task 12 - NodeList vs HTMLCollection
// Select policies using:
// getElementsByClassName
// querySelectorAll
// Dynamically add a new policy
// Observe which collection updates automatically
let policies=document.getElementsByClassName("policy");
console.log(policies);

let policies1=document.querySelectorAll(".policy");
console.log(policies1);

let p1=document.createElement("p");
p1.classList.add("policy")
document.body.appendChild(p1);
p1.innerHTML="Home Insurance";
console.log(policies);
console.log(policies1);

//HTML Collection will be updated automatically


// Task 13-Text Content Filtering
// Select all customers and:
// Highlight customers whose policy includes "Life"
// Hide customers whose policy includes "Vehicle"
// Hint: textContent.includes()

let textFilter=document.querySelectorAll(".customer");
textFilter.forEach((c)=>{
    if(c.textContent.includes("Life")){
        c.style.backgroundColor="yellow";
    }
    if(c.textContent.includes("Vehicle")){
        c.hidden=true;
    }
})

// Task 14 - Closest & Parent Traversal
// When clicking any customer <li>:
// Find the nearest <ul>
// Add a border to it
// Hint: closest()

let customersList = document.querySelectorAll(".customer");

for (let i of customersList) {
  i.addEventListener("click", function () {
    let nearestUl = this.closest("ul");
    nearestUl.style.border = "3px solid black";
  });
}

for (let i of customersList) {
    i.addEventListener("click",()=>{
    let nearestUl = i.closest("ul");
    nearestUl.style.border = "3px solid black";
  })
}

// Task 15-Complex Selector Challenge Select:
// All policy <p> elements except the first one and:
// Change font style to italic
// Prefix text with " ✔ "
// Hint: :not() and :first-child
// first child cna be used if we nest the elements
let textFilter1=document.querySelectorAll(".policy:not(:first-of-type)");
console.log(textFilter1);

for(i of textFilter1){
    i.style.fontStyle="italic";
    i.innerHTML='✔'+i.innerHTML;
}


