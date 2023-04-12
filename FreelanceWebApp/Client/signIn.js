function buttonSignUp_Click() {
  window.location.href = "signUp.html";
}

async function signIn() {
  let user = {
    login: document.getElementById("input-login-field").value,
    password: document.getElementById("input-password-field").value,
    name: null,
    email: null,
    phone: null,
    bio: null,
  };

  console.log(user);

  let response = await fetch(`https://localhost:7046/api/User/${document.getElementById("input-login-field").value}/${document.getElementById("input-password-field").value}`, {
    method: "POST",
    headers: {
      Accept: "application/json",
    },
  });

  let findUser = await response.json();

console.log(findUser);

  if (findUser === null) {
    alert("Неправильные логин или пароль!");
  } else {
    if (findUser.classificationId === 1) {
      localStorage.setItem("employer", JSON.stringify(findUser));
      window.location.href = "employer.html";
    } else if (findUser.classificationId === 2) {
      localStorage.setItem("specialist", JSON.stringify(findUser));
      window.location.href = "specialist.html";
    }
  }
}
