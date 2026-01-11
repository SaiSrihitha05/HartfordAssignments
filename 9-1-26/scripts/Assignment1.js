document.addEventListener("DOMContentLoaded", function () {
// Get form element
  const form = document.getElementById("enquiryForm");
// Get all elements in form
  const fullname = document.getElementById("fullname");
  const email = document.getElementById("email");
  const mobilenumber = document.getElementById("mobilenumber");
  const requestType = document.getElementById("requestType");
  const policyType = document.getElementById("policyType");
  const message = document.getElementById("message");
  const experienceGroup = document.getElementById("experience");
//Regular expressions for email and mobile number
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const mobileRegex = /^\d{10}$/;

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
// Checks while user typing
  validateLive(fullname, v => v.trim() !== "", "Name is required");
  validateLive(email, v => emailRegex.test(v), "Enter a valid email address");
  validateLive(mobilenumber, v => mobileRegex.test(v), "Mobile must be exactly 10 digits");
  validateLive(message, v => v.trim().length >= 10, "Message must be at least 10 characters");
  validateSelect(requestType, "Please select request type");
  validateSelect(policyType, "Please select policy type");

  document.querySelectorAll('input[name="experienceRating"]').forEach(radio => {
    radio.addEventListener("change", () => {
      clearError(experienceGroup);
    });
  });

  form.addEventListener("submit", function (e) {
    e.preventDefault();
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
// Checks while submitting
    check(fullname.value.trim() !== "", fullname.closest(".form-group"), "Name is required");
    check(emailRegex.test(email.value), email.closest(".form-group"), "Enter a valid email address");
    check(mobileRegex.test(mobilenumber.value), mobilenumber.closest(".form-group"), "Mobile must be exactly 10 digits");
    check(requestType.value !== "", requestType.closest(".form-group"), "Please select request type");
    check(policyType.value !== "", policyType.closest(".form-group"), "Please select policy type");
    check(message.value.trim().length >= 10, message.closest(".form-group"), "Message must be at least 10 characters");
    check(document.querySelector('input[name="experienceRating"]:checked'),experienceGroup,"Please select experience rating");

    if (isValid) {
        const successMsg = document.getElementById("successMessage");
        successMsg.textContent ="Thank you! Your enquiry has been successfully submitted.";
        successMsg.style.display = "block";
        form.reset();
        document.querySelectorAll(".error").forEach(err => err.textContent = "");
    }
  });

});