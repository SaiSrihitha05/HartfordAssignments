document.getElementById("paymentSection").addEventListener("click", () => {
  console.log("Clicked div");
});

document.getElementById("payPremium").addEventListener("click", () => {
  console.log("Clicked button");
});


document.getElementById("paymentSection1")
  .addEventListener("click", () => {
    console.log("Clicked div1");
  }, true);

document.getElementById("payPremium1")
  .addEventListener("click", () => {
    console.log("Clicked button1");
  }, true);


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
