let dataAdded = true;
let policiesData = [];   
// Task 1: Fetch Insurance Policies (Fetch + Async/Await)
//  Fetch policy data from a mock API (simulate API using local data)
//  Handle API errors using try/catch

const API_URL = "https://696688d2f6de16bde44daeef.mockapi.io/api/policies/policies";

async function fetchPoliciesfromAPI() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error("API failure while fetching policies");
        }

        const data = await response.json();
        policiesData = data;   // store for all other tasks
        return data;

    } catch (error) {
        throw error.message;
    }
}


async function fetchPolicies() {
    try {
        const policies = await fetchPoliciesfromAPI();
        displayPolicies(policies);
        calculateTotalPremium();
        applyDiscount();
        approveStatus();
        approveStatusPromise();
    } catch (error) {
        console.log("Error:", error);
    }
}
fetchPolicies();

//2
// Task 2: Display Policies (Objects & Arrays)
//  Render policies dynamically on UI
//  Show: Policy Name, Type, Premium, Duration, Status
function displayPolicies(data) {
    const tableBody = document.getElementById("table_body");
    tableBody.innerHTML = "";

    if (data.length === 0) {
        tableBody.innerHTML = "<tr><td colspan='5'>No policies found</td></tr>";
        return;
    }

    data.forEach(p => {
        tableBody.innerHTML += `
            <tr>
                <td>${p.name}</td>
                <td>${p.type}</td>
                <td>${p.premium}</td>
                <td>${p.duration}</td>
                <td>${p.status}</td>
            </tr>`;
    });
}

// Task 3: Filter Policies (filter)
//  Filter policies:
// o Health
// o Life
// o Vehicle
document.getElementById("policy-type").addEventListener("change", e => {
    const type = e.target.value;
    if (type === "") displayPolicies(policiesData);
    else displayPolicies(policiesData.filter(p => p.type === type));
});

// Task 4: Calculate Total Premium (reduce)
//  Calculate total premium of Active policies
function calculateTotalPremium() {
    const el = document.getElementById("totalPre");

    try {
        const active = policiesData.filter(p => p.status === "Active");

        if (active.length === 0)
            throw "Premium calculation error: No active policies";

        const total = active.reduce((sum, p) => sum + p.premium, 0);
        el.innerHTML = total;
    } catch (err) {
        el.innerHTML = err;
    }
}


// Task 5: Premium Discount Logic (map)
//  Apply 10% discount to policies above ₹10,000
function applyDiscount() {
    const discounted = policiesData.map(p =>
        p.premium > 10000 ? { ...p, premium: p.premium * 0.9 } : p
    );

    const table = document.getElementById("table_body1");
    table.innerHTML = "";

    discounted.forEach(p => {
        table.innerHTML += `
            <tr>
                <td>${p.name}</td>
                <td>${p.type}</td>
                <td>${p.premium}</td>
                <td>${p.duration}</td>
                <td>${p.status}</td>
            </tr>`;
    });
}


// Task 6: Policy Approval Simulation (Callback + setTimeout)
//  Simulate policy approval after 2 seconds
//  Use callback pattern
function approvePolicyById(id, callback) {
    setTimeout(() => {
        const policy = policiesData.find(p => p.id === id);

        if (!policy) callback("Invalid policy ID", null);
        else if (policy.status === "Active")
            callback(null, `Policy "${policy.name}" approved`);
        else
            callback(`Policy "${policy.name}" is inactive`, null);
    }, 2000);
}

function approveStatus() {
    policiesData.forEach(p => {
        approvePolicyById(p.id, (err, res) => {
            if (err) console.log("Error:", err);
            else console.log("Success:", res);
        });
    });
    
}


// Task 7: Promise-based Policy Purchase
//  Convert callback logic to Promise
//  Handle success & failure
function approvePolicyByIdPromise(id) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const policy = policiesData.find(p => p.id === id);
            if (!policy) reject("Invalid policy ID");
            else if (policy.status === "Active")
                resolve(`Policy "${policy.name}" approved`);
            else
                reject(`Policy "${policy.name}" is inactive`);
        }, 2000);
    });
}

async function approveStatusPromise() {
    
    for (let p of policiesData) {
        
        try {
            const res = await approvePolicyByIdPromise(p.id);
            console.log("Success:", res);
        } catch (err) {
            console.log("Failure:", err);
        }
    }
}
