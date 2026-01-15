const API_URL = "https://696688d2f6de16bde44daeef.mockapi.io/api/policies/policies";
const table = document.getElementById("policyTable");

async function getPolicies() {
  const res = await fetch(API_URL);
  const data = await res.json();

  table.innerHTML = "";
  data.forEach(p => {
    table.innerHTML += `
        <tr data-id="${p.id}">
            <td>${p.name}</td>
            <td>${p.type}</td>
            <td>${p.premium}</td>
            <td>${p.duration}</td>
            <td class="${p.status === 'Active' ? 'Active' : 'Inactive'}">${p.status}</td>
            <td>
            <button class="edit-btn text-blue-600 mr-2 cursor-pointer border pr-2 pl-2">Edit</button>
            <button class="delete-btn text-red-600 cursor-pointer border pr-2 pl-2">Delete</button>
            </td>
        </tr>
    `;
  });
}

async function postPolicy(e) {
  e.preventDefault();

  const newPolicy = {
    name: document.getElementById("name").value,
    type: document.getElementById("type").value,
    premium: document.getElementById("premium").value,
    duration: document.getElementById("duration").value,
    status: document.getElementById("status").value
  };

  await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newPolicy)
  });

  e.target.reset();
  getPolicies();
}

async function savePolicy(id, updatedData) {
    await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedData)
    });
    getPolicies();
}

async function deletePolicy(id) {
    await fetch(`${API_URL}/${id}`, { 
        method: "DELETE" 
        });
    document.querySelector(`tr[data-id="${id}"]`).remove();
}

async function patchPolicy(id, partialData) {
  await fetch(`${API_URL}/${id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(partialData)
  });
  getPolicies();
}


table.addEventListener("click", (e) => {
    const table=e.target;
    const row = table.closest("tr");
    if (!row) return;
    const id = row.getAttribute("data-id");
    if (table.classList.contains("delete-btn")) {
        deletePolicy(id);
    }

    if (table.classList.contains("edit-btn")) {
        const cells = row.children;

        const oldData = {
        name: cells[0].innerText,
        type: cells[1].innerText,
        premium: cells[2].innerText,
        duration: cells[3].innerText,
        status: cells[4].innerText
        };

        cells[0].innerHTML = `<input value="${oldData.name}" class="custom-input">`;

        cells[1].innerHTML = `
        <select class="custom-input">
            <option ${oldData.type==="Life"?"selected":""}>Life</option>
            <option ${oldData.type==="Health"?"selected":""}>Health</option>
            <option ${oldData.type==="Vehicle"?"selected":""}>Vehicle</option>
            <option ${oldData.type==="Home"?"selected":""}>Home</option>
        </select>`;

        cells[2].innerHTML = `<input type="number" value="${oldData.premium}" class="custom-input">`;
        cells[3].innerHTML = `<input type="number" value="${oldData.duration}" class="custom-input">`;

        cells[4].innerHTML = `
        <select class="custom-input">
            <option ${oldData.status==="Active"?"selected":""}>Active</option>
            <option ${oldData.status==="Inactive"?"selected":""}>Inactive</option>
        </select>`;

        cells[5].innerHTML = `<button class="save-btn text-green-600">Save</button>`;
    }

    if (table.classList.contains("save-btn")) {
    const inputs = row.querySelectorAll("input, select");

    const updatedPolicy = {
        name: inputs[0].value,
        type: inputs[1].value,
        premium: inputs[2].value,
        duration: inputs[3].value,
        status: inputs[4].value
    };

    savePolicy(id, updatedPolicy);
    // patchPolicy(id, updatedPolicy); 
}

});

document.getElementById("policyForm").addEventListener("submit", postPolicy);

getPolicies();
