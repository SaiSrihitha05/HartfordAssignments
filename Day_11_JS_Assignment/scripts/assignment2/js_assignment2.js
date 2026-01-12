// function divFunc(){
//     let p1=document.createElement("p");
//     document.body.appendChild(p1);
//     p1.innerHTML="Clicked div";
// }
// function buttonFunc(){
//     let p1=document.createElement("p");
//     document.body.appendChild(p1);
//     p1.innerHTML="Clicked button";
// }

// //2
// function divFunc1(){
//     let p1=document.createElement("p");
//     document.body.appendChild(p1);
//     p1.innerHTML="Clicked div1";
// }
// function buttonFunc1(){
//     let p1=document.createElement("p");
//     document.body.appendChild(p1);
//     p1.innerHTML="Clicked button1";
// }
// let div1=document.getElementById("paymentSection1");
// div1.addEventListener("click",divFunc1,true);
// let button1=document.getElementById("payPremium1");
// button1.addEventListener("click",buttonFunc1,true);

// //3
// document.querySelectorAll("#policyCard").forEach((e)=>{
// e.addEventListener("click",()=>{
//     console.log(`Navigating to ${e.querySelector("#policy").innerHTML} policy details...`);
// })
// })

// document.querySelectorAll("#deletePolicy").forEach((e1)=>{
// e1.addEventListener("click",(e)=>{
//     e.stopPropagation();
//     let card=e1.closest("#policyCard");
//     console.log(`deleted ${card.querySelector("#policy").innerHTML}`);
//     card.remove();

// })
// })

// //4
// document.querySelectorAll(".claim-row").forEach((e)=>{
//     e.addEventListener("click",()=>{
//         let claim=e.querySelector("#claimDetails").innerHTML;
//         console.log(`Claim details: ${claim}`);
//     })
// })

// document.querySelectorAll(".approve-btn").forEach((e)=>{
//     e.addEventListener("click",(e1)=>{
//         e1.stopPropagation();
//         let claim=e.closest(".claim-row");
//         console.log(`Approved ${claim.querySelector("#claimDetails").innerHTML} claim`);
        
//     })
// })

/* ===============================
   Exercise 1 – Bubbling
================================ */
document.getElementById("paymentSection").addEventListener("click", () => {
  console.log("Clicked div");
});

document.getElementById("payPremium").addEventListener("click", () => {
  console.log("Clicked button");
});


/* ===============================
   Exercise 2 – Capturing
================================ */
document.getElementById("paymentSection1")
  .addEventListener("click", () => {
    console.log("Clicked div1");
  }, true);

document.getElementById("payPremium1")
  .addEventListener("click", () => {
    console.log("Clicked button1");
  }, true);


/* ===============================
   Exercise 3 – stopPropagation
================================ */
document.querySelectorAll(".policy-card").forEach(card => {
  card.addEventListener("click", () => {
    console.log(`Navigating to ${card.querySelector(".policy-name").innerHTML} policy details...`);

  });
});

document.querySelectorAll(".delete-policy").forEach(btn => {
  btn.addEventListener("click", (e) => {
    e.stopPropagation();
    const card = btn.closest(".policy-card");
    const name = card.querySelector(".policy-name").innerText;
    console.log(`Deleted ${name}`);
    card.remove();
  });
});


/* ===============================
   Exercise 4 – Combined
================================ */
document.querySelectorAll(".claim-row").forEach(row => {
  row.addEventListener("click", () => {
    let claim=row.querySelector(".claim-details").innerHTML;
        console.log(`Claim details: ${claim}`);
  });
});

document.querySelectorAll(".approve-btn").forEach(btn => {
  btn.addEventListener("click", (e) => {
    e.stopPropagation();
    let claim=btn.closest(".claim-row");
    console.log(`Approved ${claim.querySelector(".claim-details").innerHTML} claim`);
  });
});
