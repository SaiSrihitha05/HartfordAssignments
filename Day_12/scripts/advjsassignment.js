// Task 1: Fetch Insurance Policies (Fetch + Async/Await)
//  Fetch policy data from a mock API (simulate API using local data)
//  Handle API errors using try/catch

const policiesData = [
 { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active" },
 { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" },
 { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active" },
 { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" }
];
let dataAdded=true;
function fetchPoliciesfromAPI(){
    return new Promise((resolve,reject)=>{
        setTimeout(()=>{
            if(policiesData.length>0){
                resolve(policiesData);
            }
            else{
                reject("No policies found");
            }
        },0)
    })
}

async function fetchPolicies(){
    try{
        let policies=await fetchPoliciesfromAPI();
        console.log(policies);
    }catch(error){
        console.log(error);
    }
}
fetchPolicies();


//2
// Task 2: Display Policies (Objects & Arrays)
//  Render policies dynamically on UI
//  Show: Policy Name, Type, Premium, Duration, Status
let btn=document.querySelector("#fetch").addEventListener("click",()=>{
    if(dataAdded){
        let data=document.getElementById("table_body");
        policiesData.forEach((e)=>{
        return data.innerHTML+=`
            <tr>
            <td>${e.name}</td>
            <td>${e.type}</td>
            <td>${e.premium}</td>
            <td>${e.duration}</td>
            <td>${e.status}</td>
            </tr>
        `;
        })
        dataAdded=false;
}
});


// Task 3: Filter Policies (filter)
//  Filter policies:
// o Health
// o Life
// o Vehicle


let policySelector = document.querySelector("#policy-type");

document.addEventListener("DOMContentLoaded", () => {
    loadAllPolicies();
});

async function loadAllPolicies() {
    try {
        const policies = await fetchPoliciesfromAPI();
        displayPolicies(policies);
    } catch (error) {
        document.getElementById("table_body").innerHTML = "No policies fetched";
    }
}

function handlePolicy(){
policySelector.addEventListener("change",async ()=>{
    let policyType=policySelector.value;
    console.log(policyType);
    
    try{
        let message=await fetchPolicyByType(policyType);
        console.log(message);
        displayPolicies(message);
    }catch(error){
        document.getElementById("table_body").innerHTML="no policies fetched";
    }
})
}

function fetchPolicyByType(policyType) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (policyType === "") {
                resolve(policiesData);
            } else if (policyType === "Life") {
                resolve(policiesData.filter(p => p.type === "Life"));
            } else if (policyType === "Health") {
                resolve(policiesData.filter(p => p.type === "Health"));
            } else if (policyType === "Vehicle") {
                resolve(policiesData.filter(p => p.type === "Vehicle"));
            } else {
                reject("Invalid policy type");
            }
        }, 0);
    });
}

function displayPolicies(data) {
    let tableBody = document.getElementById("table_body");
    tableBody.innerHTML = "";

    if (data.length === 0) {
        tableBody.innerHTML = "<tr><td colspan='5'>No policies found</td></tr>";
        return;
    }

    data.forEach(e => {
        tableBody.innerHTML += `
            <tr>
                <td>${e.name}</td>
                <td>${e.type}</td>
                <td>${e.premium}</td>
                <td>${e.duration}</td>
                <td>${e.status}</td>
            </tr>
        `;
    });
}
function clearFil(){
    let policySelector = document.querySelector("#policy-type");
    policySelector.value="";
    loadAllPolicies();
}
handlePolicy();

// Task 4: Calculate Total Premium (reduce)
//  Calculate total premium of Active policies

let pa=document.getElementById("totalPre");
function fetchTotalPremium() {
    return new Promise((resolve, reject) => {
        const activePolicies = policiesData.filter(p => p.status === "Active");

        if (activePolicies.length > 0) {
            resolve(activePolicies);
        } else {
            reject("No active policies found");
        }
    });
}

async function fetchPremium(){
    try{
        let message=await fetchTotalPremium();
        console.log(message);
        
        displayPremium(message);
    }catch(error){
        pa.innerHTML+=error;
    }
}
function displayPremium(data){

    

    let pre=data.filter((e)=>e.status==="Active").reduce((acc,inp)=>acc+inp.premium,0);
    pa.innerHTML+=pre;
}

fetchPremium();

// Task 5: Premium Discount Logic (map)
//  Apply 10% discount to policies above ₹10,000
let tablewithDiscount=document.getElementById("table_body1");
function fetchtablewithDiscountPremium() {
    return new Promise((resolve, reject) => {
        

        if (policiesData.length > 0) {
            resolve(policiesData);
        } else {
            reject("No active policies found");
        }
    });
}

async function fetchtable(){
    try{
        let message=await fetchtablewithDiscountPremium();
        message=applyDiscount(message);
        displaytable(message);
    }catch(error){
        pa.innerHTML+=error;
    }
}
function displaytable(data){
    data.forEach(e => {
            tablewithDiscount.innerHTML += `
            <tr>
                <td>${e.name}</td>
                <td>${e.type}</td>
                <td>${e.premium}</td>
                <td>${e.duration}</td>
                <td>${e.status}</td>
            </tr>
        `;
        });
    
}
function applyDiscount(data) {
    return data.map(policy => {
        if (policy.premium > 10000) {
            return {
                ...policy,
                premium: policy.premium * 0.9
            };
        }
        return policy;
    });
}


fetchtable();


// Task 6: Policy Approval Simulation (Callback + setTimeout)
//  Simulate policy approval after 2 seconds
//  Use callback pattern

function approvePolicyById(policyId, callback) {
    setTimeout(() => {
        const policy = policiesData.find(p => p.id === policyId);

        if (!policy) {
            callback("Invalid policy ID", null);
        } else if (policy.status === "Active") {
            callback(null, `Policy "${policy.name}" approved`);
        } else {
            callback(`Policy "${policy.name}" is inactive`, null);
        }
    }, 2000);
}

function approveStatus() {
    policiesData.forEach(policy => {
        approvePolicyById(policy.id, function (error, result) {
            if (error) {
                console.log("Error:", error);
            } else {
                console.log("Success:", result);
            }
        });
    });
}


approveStatus();

// Task 7: Promise-based Policy Purchase
//  Convert callback logic to Promise
//  Handle success & failure

function approvePolicyById1(policyId) {
    return new Promise((resolve,reject)=>{
        setTimeout(()=>{
        const policy = policiesData.find(p => p.id === policyId);

        if (!policy) {
            reject("no valid policy name")
        } else if (policy.status === "Active") {
            resolve(`Policy "${policy.name}" approved`);
        } else {
            resolve(`Policy "${policy.name}" is inactive`, null);
        }
    }, 2000);
    })
        
}


async function approveStatus1() {
    for(let i of policiesData){
    try{
            let message=await approvePolicyById1(i.id);
            console.log(message);
    }catch(error){
        console.log(error);
        
    }
}
}
approveStatus1();

// Task 8: Error Handling
//  Invalid policy ID
//  API failure
//  Premium calculation error
//Handled in above tasks using reject in promises