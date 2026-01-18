API_URL="https://696688d2f6de16bde44daeef.mockapi.io/api/policies/users";
let arr=[]
let body=document.getElementById("userTabbody");

function getBalance(){
    let bal=Math.round(Math.random()*(50000-10000+1)+10000);
    return bal;
}

function getDateTime() {
  const now = new Date();
  return {
    date: now.toLocaleDateString(),
    time: now.toLocaleTimeString()
  };
}

async function fetchUsers(){
    let loader = document.getElementById("loader");
    let loaderHeading=document.getElementById("loaderheading");
    loader.style.display = "block";
    try{
        setTimeout(async ()=>{
            let res = await fetch(API_URL,{
            method:"GET"
        })
        res = await res.json();
        arr = res.map((e) => ({
            ...e,
            balance: e.balance??getBalance(),
            transactions: Array.isArray(e.transactions) ? e.transactions : []
        }));
        
        saveToStorage(); 
        getUsers(arr);
        getBalanceTotal();
        },1000)
    }catch(err){
        loader.style.display = "none";
        body.innerHTML=`<tr><td colspan="7">Failed to load users</td></tr>`;
    }finally{
        setTimeout(()=>{
            loaderHeading.style.display="none";
            loader.style.display = "none";
        },1000)
    }
}

function getUsers(arr){
    body.innerHTML = "";
    if(arr.length==0){
        body.innerHTML=`<tr><td colspan="7">No users found</td></tr>`;
        return;
    }
    arr.forEach((e)=>{
        body.innerHTML+=`
        <tr data-id="${e.id}" class="${e.balance < 5000 ? 'mark' : ''}">
        <td>${e.id}</td>
        <td class="user">${e.name}</td>
        <td class="email">${e.email}</td>
        <td class="city">${e.address.city}</td>

        <td class="balance">${e.balance}</td>
        <td>
            <button class="withdraw">Withdraw</button>
            <button class="deposit">Deposit</button>
        </td>
        <td ><img src="../images/trash.png" alt="" class="delete"></td>
        </tr>
        `;
        if((e.balance)<5000){
             
        }
    })
    
}

let username=document.getElementById("search");
let filtertag=document.getElementById("filter");

function applyFilterSearch(){
    let searchValue=username.value.toLowerCase();
    let city=filtertag.value;
    citySearchWise=[...arr] .filter((e)=>( city === "" || e.address.city === city) && e.name.toLowerCase().includes(searchValue));
    getUsers(citySearchWise);
}

async function postData(newData){
    try{
    let res=await fetch(API_URL,{
        method:"POST",
        headers:{
            "Content-Type":"application/json"
        },
        body:JSON.stringify(newData)
    })
    let data = await res.json();
    arr=[...arr,data];
    saveToStorage();
    getUsers(arr);
}catch(err){
    alert("Failed to add user");
}
}

let btn=document.getElementById("submit-btn");
btn.addEventListener("click",(e)=>{
    e.preventDefault();
    if (!validateForm()) return;
    
    let newData={
        name:document.getElementById("username").value,
        email:document.getElementById("email").value,
        address:{
            city:document.getElementById("address").value
        },
        balance:getBalance()
    }
    postData(newData);
    document.getElementById("userform").reset();
})

async function updateBalance(id, balance,transactions) {
    try{
        await fetch(`${API_URL}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ balance,transactions })
        });
    }catch(err){
        alert("Balance update failed");
    }
}

function createAccountManager(initialBalance) {
    let balance = initialBalance;
    return {
        deposit(amount) {
            balance += amount;
            return balance;
        },
        withdraw(amount) {
            if (amount > balance) return null;
            balance -= amount;
            return balance;
        },
        getBalance() {
            return balance;
        }
    };
}

async function deletePolicy(id){
    try{
        let ok = confirm("Are you sure you want to delete this account?");
        if(!ok) return;
        if(!id) return;
        let res= await fetch(`${API_URL}/${id}`,{
            method:"DELETE"
        });
        let deletedData=await res.json();
        console.log(deletedData);
        arr=arr.filter((e)=>e.id!==String(id));
        getUsers(arr);
        saveToStorage();
    }catch(err){
        alert("Delete failed");
    }
}
function validateForm() {
    let isValid = true;

    let name = document.getElementById("username").value.trim();
    let email = document.getElementById("email").value.trim();
    let city = document.getElementById("address").value.trim();

    let nameError = document.getElementById("nameError");
    let emailError = document.getElementById("emailError");
    let addressError = document.getElementById("addressError");

    nameError.textContent = "";
    emailError.textContent = "";
    addressError.textContent = "";

    if (name.length < 4 || !/^[a-zA-Z\s]+$/.test(name)) {
        nameError.textContent = "Name must be at least 4 letters (only alphabets).";
        isValid = false;
    }
    if (!/^\S+@\S+\.\S+$/.test(email)) {
        emailError.textContent = "Enter a valid email address.";
        isValid = false;
    }
    if (city.length < 3) {
        addressError.textContent = "City must be at least 3 characters.";
        isValid = false;
    }
    return isValid;
}

let search1=document.getElementById("search1");
let transactionBody=document.getElementById("transactionBody");
function getTransactions(){
       setTimeout(() => {
        transactionBody.innerHTML = "";
        let searchId = search1.value;
        let searchRow = arr.find(e => e.id === searchId);

        if (!searchRow || !Array.isArray(searchRow.transactions)) {
            transactionBody.innerHTML =
              `<tr><td colspan="4">No transactions found</td></tr>`;
            return;
        }
        searchRow.transactions.forEach(t => {
            transactionBody.innerHTML += `
            <tr>
                <td>${t.type}</td>
                <td>${t.amount}</td>
                <td>${t.date}</td>
                <td>${t.time}</td>
            </tr>`;
        });
    }, 1000);
}

search1.addEventListener("input",getTransactions);
username.addEventListener("input",applyFilterSearch);
filtertag.addEventListener("change",applyFilterSearch);


let totalBal=document.getElementById("totalBalance");
function getBalanceTotal(){
let calBalarr = arr.reduce(
    (acc, input) => acc + Number(input.balance),
    0
);
console.log(calBalarr);
totalBal.innerHTML=`${calBalarr}`;
}
document.getElementById("sortBalance").addEventListener("click", () => {
    let sorted = [...arr].sort((a, b) => b.balance - a.balance);
    getUsers(sorted);
});


document.getElementById("resetSort").addEventListener("click", () => {
    getUsers(arr);
});

function saveToStorage() {
    localStorage.setItem("bankUsers", JSON.stringify(arr));
}

function loadFromStorage(){
    try{
    let data=localStorage.getItem("bankUsers");
    if(!data){return false;}
    let parsed=JSON.parse(data);
    if(parsed.length===0){ return false;}
    arr=parsed;
    getUsers(arr);
    getBalanceTotal();
    return true;
}catch(err){
    localStorage.removeItem("bankUsers");
    return false;
}
}

async function initalizeApp(){
    let loadStatus=loadFromStorage();
    if(!loadStatus){
        document.getElementById("loader1").innerText =
        "Loading data from server...";
        await fetchUsers();
    }

}
initalizeApp();

body.addEventListener("click", async (e) => {
    // console.log(e.target);
    
    if (e.target.classList.contains("withdraw")) {
        let row = e.target.closest("tr");
        if(!row) return;
        let id = row.dataset.id;
        let user = arr.find(u => u.id === id);
        if (!user) {
            alert("User not found");
            return;
        }
        console.log(arr);
        if(user.balance<5000){
            alert("Can't withdraw due to insufficient Balance")
            return
        }
        let withdrawlAmount=Number(prompt("Enter Withdraw Amount:"));
        if(!withdrawlAmount || withdrawlAmount<=0 || withdrawlAmount>user.balance){
            alert("Invalid withdrawal");
            return;
        }
        let manager = createAccountManager(user.balance); 
        let newBalance = manager.withdraw(withdrawlAmount);
        if (newBalance === null) {
            alert("Insufficient balance");
            return;
        }
        user.balance = newBalance;
        if (user.balance < 5000) {
            user.balance -= 200;
            alert("Penalty applied because minimum balance is 5000");
        }
        let { date, time } = getDateTime();
        user.transactions = user.transactions || [];
        user.transactions.push({type: "withdraw",amount: withdrawlAmount,date,time});
        await updateBalance(id, user.balance,user.transactions);
        saveToStorage();
        getUsers(arr);
        console.log("Withdraw clicked for ID:", id);
    }

    if (e.target.classList.contains("deposit")) {
        let row = e.target.closest("tr");
        if(!row) return;
        let id =row.dataset.id;
        let depositAmount=Number(prompt("Enter Deposit Amount:"));
        if (!depositAmount || depositAmount <= 0) {
            alert("Enter valid amount");
            return;
        }
        let user = arr.find(u => u.id === id);
        if (!user) {
            alert("User not found");
            return;
        }        
        let manager = createAccountManager(user.balance); 
        user.balance = manager.deposit(depositAmount);

        let { date, time } = getDateTime();
        user.transactions = user.transactions || [];
        user.transactions.push({ type: "deposit", amount: depositAmount, date, time });

        await updateBalance(id, user.balance, user.transactions);
        saveToStorage();
        getUsers(arr);
        console.log("Deposit clicked for ID:", id);
    }

    if(e.target.classList.contains("delete")){
        let row = e.target.closest("tr");
        if (!row) return;
        let id = Number(row.dataset.id);
        await deletePolicy(id);
    }
});

