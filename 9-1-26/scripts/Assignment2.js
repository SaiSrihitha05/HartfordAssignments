let customers = [];
let customerId = 1;

const premiums = {
    healthInsurance: 3000,
    lifeInsurance: 5000,
    autoInsurance: 2000,
    homeInsurance: 6000
};

const insurancePlans = [
    { id: 1, name: "Life Insurance", description: "Financial protection for family", basePremium: 6000, coverageAmount: 1000000, image: "../images/lifeinsurance.jpg" },
    { id: 2, name: "Health Insurance", description: "Medical coverage", basePremium: 3000, coverageAmount: 500000, image: "../images/health.png" },
    { id: 3, name: "Vehicle Insurance", description: "Car & bike protection", basePremium: 2000, coverageAmount: 300000, image: "../images/insurance.png" },
    { id: 4, name: "Home Insurance", description: "Secure your property", basePremium: 4000, coverageAmount: 800000, image: "../images/home.png" }
];

document.addEventListener("DOMContentLoaded", () => {
    renderPlans();
    updateDashboard();
    setupEventListeners();
});

function renderPlans() {
    const plansContainer = document.getElementById("plans");
    plansContainer.innerHTML = insurancePlans.map(plan => `
        <div class="card">
            <img src="${plan.image}" alt="${plan.name}">
            <div class="p-4">
                <p class="title text-lg font-bold text-center">${plan.name}</p>
                <p class="description text-sm text-center mb-2">${plan.description}</p>
                <p class="basePremium text-center">Base: ₹${plan.basePremium}</p>
                <p class="coverageAmount text-center text-xs">Coverage: ₹${plan.coverageAmount}</p>
                <button class="enroll-btn w-full mt-3">Enroll</button>
            </div>
        </div>
    `).join('');
}

function calculatePremium(age, coverage, policyType) {
    let base = premiums[policyType] || 0;
    
    // +20% if age > 45
    if (age > 45) base *= 1.2;

    // +500 per additional 1L coverage (assuming base coverage is 1L)
    const extraCoverage = Math.floor(coverage / 100000) - 1;
    if (extraCoverage > 0) base += extraCoverage * 500;

    return Math.round(base);
}

function addData() {
    const nameInput = document.getElementById("fullname");
    const ageInput = document.getElementById("age");
    const emailInput = document.getElementById("email");
    const typeInput = document.getElementById("policyType");
    const coverageInput = document.getElementById("coverageamount");

    const customer = {
        id: customerId++,
        name: nameInput.value.trim(),
        age: parseInt(ageInput.value),
        email: emailInput.value.trim(),
        policyType: typeInput.value,
        coverage: parseInt(coverageInput.value),
        premium: calculatePremium(parseInt(ageInput.value), parseInt(coverageInput.value), typeInput.value)
    };

    customers.push(customer);
    applyFilterAndSearch(); 
    updateDashboard();
}

function renderTable(data) {
    const tbody = document.querySelector("#tablefromform tbody");
    tbody.innerHTML = data.map(c => `
        <tr>
            <td class="p-2 border">${c.id}</td>
            <td class="p-2 border font-semibold">${c.name}</td>
            <td class="p-2 border">${c.age}</td>
            <td class="p-2 border">${c.email}</td>
            <td class="p-2 border">${formatPolicyName(c.policyType)}</td>
            <td class="p-2 border">₹${c.coverage.toLocaleString()}</td>
            <td class="p-2 border font-bold text-[#75013F]">₹${c.premium.toLocaleString()}</td>
        </tr>
    `).join('');
}

function formatPolicyName(type) {
    const names = {
        healthInsurance: "Health Insurance",
        lifeInsurance: "Life Insurance",
        autoInsurance: "Auto Insurance",
        homeInsurance: "Home Insurance"
    };
    return names[type] || type;
}

function applyFilterAndSearch() {
    const searchTerm = document.getElementById("searchName").value.toLowerCase();
    const filterType = document.getElementById("filterByPolicyType").value;

    const filtered = customers.filter(c => {
        const matchesName = c.name.toLowerCase().includes(searchTerm);
        const matchesType = filterType === "" || c.policyType === filterType;
        return matchesName && matchesType;
    });

    renderTable(filtered);
}

function updateDashboard() {
    const dashboard = document.getElementById("dashboardCards");
    const totalPremium = customers.reduce((sum, c) => sum + c.premium, 0);

    dashboard.innerHTML = `
        <div class="dashboardCard flex flex-col md:flex-row gap-6 justify-center">
            <h2>Total Customers <span>${customers.length}</span></h2>
            <h2>Total Premium <span>₹${totalPremium.toLocaleString()}</span></h2>
        </div>
    `;
}

function setupEventListeners() {
    const form = document.getElementById("enquiryForm");
    const coverageSlider = document.getElementById("coverageamount");
    const coverageDisplay = document.getElementById("coverageValue");

    coverageSlider.addEventListener("input", () => {
        coverageDisplay.textContent = parseInt(coverageSlider.value).toLocaleString();
    });

    document.getElementById("searchName").addEventListener("input", applyFilterAndSearch);
    document.getElementById("filterByPolicyType").addEventListener("change", applyFilterAndSearch);

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        const fullname = document.getElementById("fullname");
        const age = document.getElementById("age");
        const email = document.getElementById("email");
        const policyType = document.getElementById("policyType");
        
        let isValid = true;
        const setError = (element, message) => {
            const errorElement = element.closest(".form-group").querySelector(".error");
            errorElement.textContent = message;
            isValid = false;
        };
        const clearError = (element) => {
            element.closest(".form-group").querySelector(".error").textContent = "";
        };

        if (fullname.value.trim() === "") setError(fullname, "Name is required");
        else clearError(fullname);

        if (age.value === "" || age.value < 18 || age.value > 100) setError(age, "Age must be between 18 and 100");
        else clearError(age);

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email.value)) setError(email, "Enter a valid email address");
        else clearError(email);

        if (policyType.value === "") setError(policyType, "Please select a policy type");
        else clearError(policyType);

        if (isValid) {
            addData();
            
            const successMsg = document.getElementById("successMessage");
            successMsg.textContent = "Successfully Submitted!";
            successMsg.style.display = "block";
            
            form.reset();
            coverageDisplay.textContent = "0";
            
            setTimeout(() => {
                successMsg.style.display = "none";
            }, 3000);
        }
    });
}
