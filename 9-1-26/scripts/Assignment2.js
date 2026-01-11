let customers = [];
let customerId = 1;
let healthPremium=3000;
let lifePremium=5000;
let vehiclePremium=2000;
let homePremium=6000;
let premium;
console.log(document.getElementById("filterByPolicyType").value);
const insurancePlans = [
  {
    id: 1,
    name: "Life Insurance",
    description: "Financial protection for family",
    basePremium: 6000,
    coverageAmount: 1000000,
    image: "../images/lifeinsurance.jpg"
  },
  {
    id: 2,
    name: "Health Insurance",
    description: "Medical coverage",
    basePremium: 3000,
    coverageAmount: 500000,
    image: "../images/health.png"
  },
  {
    id: 3,
    name: "Vehicle Insurance",
    description: "Car & bike protection",
    basePremium: 2000,
    coverageAmount: 300000,
    image: "../images/insurance.png"
  },
  {
    id: 4,
    name: "Home Insurance",
    description: "Secure your property",
    basePremium: 4000,
    coverageAmount: 800000,
    image: "../images/home.png"
  }
];
let plans=document.getElementById("plans");
insurancePlans.map((i)=>{
    plans.innerHTML+=`
    <div class="card">
        <img src="${i.image}">
        <p class="title">${i.name}</p>
        <p class="description">${i.description}</p>
        <p class="basePremium">Base Premium: ${i.basePremium}</p>
        <p class="coverageAmount">Coverage Amount: ${i.coverageAmount}</p>
        <button class="enroll-btn">Enroll</button>  
    </div>
    `
})
//img,p,p,p,p,button
function addData() {
    let age= document.getElementById("age").value;
let policyType= document.getElementById("policyType").value;
    let coverage= document.getElementById("coverageamount").value;
  const customer = {
    id: customerId++,
    name: document.getElementById("fullname").value,
    age,
    email: document.getElementById("email").value,
    policyType,
    coverage,
    premium: calculatePremium(age, coverage, policyType)
  };

  customers.push(customer);
  
  renderTable(customers);
  updateDashboard();
}
function renderTable(customers1) {
  const tbody = document.querySelector("#tablefromform tbody");
  tbody.innerHTML = "";

  customers1.forEach(c => {
    tbody.innerHTML += `
      <tr>
        <td>${c.id}</td>
        <td>${c.name}</td>
        <td>${c.age}</td>
        <td>${c.email}</td>
        <td>${c.policyType === "healthInsurance" ? "Health Insurance" : 
      c.policyType === "lifeInsurance" ? "Life Insurance" : 
      c.policyType === "autoInsurance"? "Auto Insurance":"Home Insurance"}</td>

        <td>${c.coverage}</td>
        <td>${c.premium}</td>
      </tr>
    `;
  });
}
function calculatePremium(age, coverage, policyType) {
  let premium = 0;

  if (policyType === "healthInsurance") premium = healthPremium;
  else if (policyType === "lifeInsurance") premium = lifePremium;
  else if (policyType === "autoInsurance") premium = vehiclePremium;
  else premium = homePremium;

  // +20% if age > 45 (on base premium)
  if (age > 45) {
    premium += premium * 0.2;
  }

  // +500 per additional 1L coverage
  const extraCoverage = Math.floor(coverage / 100000) - 1;
  if (extraCoverage > 0) {
    premium += extraCoverage * 500;
  }
  updateDashboard();
  return Math.round(premium);
}
let filterpolicytype = document.getElementById("filterByPolicyType");
let searchByName = document.getElementById("searchName");

filterpolicytype.addEventListener("change", applyFilterAndSearch);
searchByName.addEventListener("input", applyFilterAndSearch);

function updateDashboard(){
let dashboard=document.getElementById("dashboardCards");
let customerCount=customers.length;
let totalPremium=0;

totalPremium=customers.reduce((acc,input)=>{
    return acc+input.premium;
},0)
dashboard.innerHTML=
    `
    <div class="dashboardCard">
    <h2>Total Customers: ${customerCount}</h2>
    <h2>Total Premium: ${totalPremium}</h2>
    </div>
    `;
console.log('customerCount',customerCount,totalPremium);
}
document.addEventListener("DOMContentLoaded", function () {
updateDashboard();  
  const form = document.getElementById("enquiryForm");

  // Form fields
  const fullname = document.getElementById("fullname");
  const age = document.getElementById("age");
  const email = document.getElementById("email");
  const policyType = document.getElementById("policyType");
  const coverage = document.getElementById("coverageamount");
  const coverageValue = document.getElementById("coverageValue");

  // Regex
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  /* ---------- Helper functions ---------- */

  function showError(group, msg) {
    group.querySelector(".error").textContent = msg;
  }

  function clearError(group) {
    group.querySelector(".error").textContent = "";
  }

  function validateLive(input, isValidFn, errorMsg) {
    const group = input.closest(".form-group");

    input.addEventListener("input", () => {
      if (isValidFn(input.value)) {
        clearError(group);
      } else {
        showError(group, errorMsg);
      }
    });
  }

  function validateSelect(select, errorMsg) {
    const group = select.closest(".form-group");

    select.addEventListener("change", () => {
      if (select.value !== "") {
        clearError(group);
      } else {
        showError(group, errorMsg);
      }
    });
  }

  /* ---------- Live validations ---------- */

  // Full name
  validateLive(fullname, v => v.trim() !== "", "Name is required");

  // Age (must be between 18 and 100)
  validateLive(age, v => v >= 18 && v <= 100, "Age must be between 18 and 100");

  // Email
  validateLive(email, v => emailRegex.test(v), "Enter a valid email address");

  // Policy type
  validateSelect(policyType, "Please select policy type");

  // Coverage slider value display
  coverageValue.textContent = coverage.value;

  coverage.addEventListener("input", () => {
    coverageValue.textContent = coverage.value;
    clearError(coverage.closest(".form-group"));
  });

  /* ---------- Submit validation ---------- */

  form.addEventListener("submit", function (e) {
    e.preventDefault();

    // Clear old errors
    document.querySelectorAll(".error").forEach(err => err.textContent = "");

    let isValid = true;

    function check(condition, group, msg) {
      if (!condition) {
        showError(group, msg);
        isValid = false;
      } else {
        clearError(group);
      }
    }

    // Final checks
    check(fullname.value.trim() !== "", fullname.closest(".form-group"), "Name is required");
    check(age.value >= 18 && age.value <= 100, age.closest(".form-group"), "Age must be between 18 and 100");
    check(emailRegex.test(email.value), email.closest(".form-group"), "Enter a valid email address");
    check(policyType.value !== "", policyType.closest(".form-group"), "Please select policy type");
    check(coverage.value > 0, coverage.closest(".form-group"), "Please select coverage amount");

    if (isValid) {
      const successMsg = document.getElementById("successMessage");
      successMsg.textContent = "Thank you! Your enquiry has been successfully submitted.";
      successMsg.style.display = "block";
        // console.log(Headers);
        
      form.reset();
      coverageValue.textContent = "0";
      document.querySelectorAll(".error").forEach(err => err.textContent = "");
    }
  });

});
