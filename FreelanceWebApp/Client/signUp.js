async function GoToSignIn(){
let userClass = document.getElementById("classification").value;
let user;

if(userClass === "Я заказчик"){
  user = {
    login: document.getElementById("input-login-field").value,
    password: document.getElementById("input-password-field").value,
    name: `${document.getElementById("input-name-field").value} ${document.getElementById("input-family-field").value}`,
    email: document.getElementById("input-email-field").value,
    phone: document.getElementById("input-phone-field").value,
    bio: document.getElementById("input-bio-field").value,
    classificationId: 1
  };
}
else if(userClass === "Я специалист"){
  user = {
      login: document.getElementById("input-login-field").value,
      password: document.getElementById("input-password-field").value,
      name: `${document.getElementById("input-name-field").value} ${document.getElementById("input-family-field").value}`,
      email: document.getElementById("input-email-field").value,
      phone: document.getElementById("input-phone-field").value,
      bio: document.getElementById("input-bio-field").value,
      classificationId: 2
    };

}


  console.log(user);

  let response = await fetch("https://localhost:7046/api/User/", {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-Type": 'application/json'
    },
    body: JSON.stringify(user),
  });

    if(response.ok){
        window.location.href = "signIn.html";
    }
      else{
        alert("Заполните все поля!");
      }

}

