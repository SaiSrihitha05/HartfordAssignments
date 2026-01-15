// Task 3
//ID to be modified with Id
document.getElementById("btn").onclick = function () {
//  alert("Clicked");
console.log("click");
}; 

// TASK 4: Validation Logic Error - will not work for 18
// let age = 18;
// if (age > 18) {
//  console.log("Eligible");
// } else if (age < 18) {
//  console.log("Not Eligible");
// }

let age = 18;
if (age >= 18) {
 console.log("Eligible");
} else if (age < 18) {
 console.log("Not Eligible");
}

// TASK 5: Input Value Always Empty
// function check() {
//  let email = document.getElementById("email");
//  if (email === "") {
//  alert("Email required");
//  }
// }->check value not input
function check() {
 let email = document.getElementById("email").value;
 if (email === "") {
 alert("Email required");
 }else{
    alert("Correct")
 }
}

// TASK 7: Password Match ValidaƟon
// Buggy Code:
// let pwd = "admin123";
// let confirmPwd = "admin123 ";
// if (pwd == confirmPwd) {
//  console.log("Match");
// } else { 
//     console.log("Mismatch");
//  }  -> use trim to get rid of white spaces
let pwd = "admin123";
let confirmPwd = "admin123  ";
confirmPwd=confirmPwd.trim(" ");
if (pwd.trim() == confirmPwd) {
 console.log("pass Match");
} else { 
    console.log("pass Mismatch");
 } 

// TASK 9: JS Error Stops Script
// Buggy Code:
// console.log("Start");
// alert("Hello")
// console.log("End); -> end quote is not added
console.log("Start");
// alert("Hello");
console.log("End");


// TASK 10: Checkbox ValidaƟon
// Buggy Code:
// <input type="checkbox" id="terms">
// <button onclick="submitForm()">Submit</button>
// <script>
// function submitForm() {
//  if (terms.checked == false) {
//  alert("Accept terms");
//  }
// }
// </script>
terms=document.getElementById("terms");
function submitForm() {
 if (terms.checked === true) {
    // alert("Accept terms");
    console.log("accept");
    return;
 }
 
}

// TASK 11: Assignment instead of comparison
// Buggy Code:
// function validate() {
//  let mobile = document.getElementById("mobile").value;
//  if ((mobile.length = 10)) {
//  alert("Valid");
//  } else {
//  alert("Invalid");
//  }
//  } 
function validate() {
    let mobile = document.getElementById("mobile").value;
    if (mobile.length == 10) {
    alert("Valid");
    } else {
    alert("Invalid");
    }
} 

// TASK 12: Policy Holder Name ValidaƟon
// Buggy Code:
// function validateName() {
//  let name = document.getElementById("policyName");
//  if (name == "") {
//  alert("Policy holder name required");
//  }
// }
function validateName() {
 let name = document.getElementById("policyName").value;
 if (name == "") {
 alert("Policy holder name required");
 }
}

// TASK 13: Insurance Plan Dropdown ValidaƟon
// Buggy Code:
// function checkPlan() {
//  let plan = document.getElementById("plan").value;
//  if ((plan = "Select Plan")) {
//  alert("Please choose a plan");
//  }
// }
function checkPlan() {
 let plan = document.getElementById("plan").value;
 if ((plan == "Select Plan")) {
 alert("Please choose a plan");
 }
}

// TASK 14: Policy Number Display Bug
// Buggy Code:
// let policyNumber = 123456;
// document.getElementById("policy").innerHTML = policyNo; 

let policyNumber = 123456;
document.getElementById("policy").innerHTML = policyNumber; 


// TASK 15: Claim Amount Validation - not working with null
// let claimAmount = "abc";
// if (!isNaN(claimAmount)){
//     alert("Valid claim");
// } else {
//     alert("Invalid claim");
// }

let claimAmount = 123;
claimAmount = Number(claimAmount);
if (claimAmount && !isNaN(claimAmount)){
    // alert("Valid claim");
    console.log("valid");
    
} else {
    // alert("Invalid claim");
    console.log("invalid");
    
}

// TASK 16: Policy Type Comparison Error
// Buggy Code:
// let policyType = "Health";
// if (policyType == "health") {
// console.log("Health Policy");
// } 
let policyType = "Health";
if (policyType === "health") {
console.log("Health Policy");
} 

// TASK 17: Policy List Rendering Bug
// Buggy Code:
// let policies = ["Life", "Health", "Vehicle"];
// policies.forEach(function (policy) {
//  document.getElementById("list").innerHTML += policy;
// });
let policies = ["Life", "Health", "Vehicle"];
policies.forEach(function (policy) {
 document.getElementById("list").innerHTML += `<li>${policy}</li>`;
});


// TASK 18: Premium Amount ValidaƟon
// Buggy Code:
// let premium = "5000";
// if (isNaN(premium)) {
// console.log("Invalid premium");
// } else {
//  console.log("Valid premium");
// } 
let premium = "324";
if (Number.isNaN(Number(premium)) || premium === null || premium.length === "") {
console.log(premium,"Invalid premium");
} else {
 console.log(premium,"Valid premium");
} 