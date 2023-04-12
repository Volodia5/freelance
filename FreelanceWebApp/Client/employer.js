function OnLoad(){
  employer = JSON.parse(localStorage.getItem("employer"));
  GetUserOrders();
}

async function GetUserOrders(){

    let response = await fetch(`https://localhost:7046/api/Employer/${employer.id}`, {
    method: "POST",
    headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
    },
  });

  let orders = await response.json();

  let tableHtml = `<table class="table mb-4">
  <thead>
  <tr>
  <th scope="col">Заголовок</th>
  <th scope="col">Статус</th>
  <th scope="col">Стоимость</th>
  <th scope="col">Место</th>
  <th scope="col">Описание</th>
  </tr>
  </thead>`;

  tableHtml += `<tbody>`;
  for (let i = 0; i < orders.length; i++) {

    if(orders[i].status === "Активный"){
      tableHtml += `
      <tr>
      <td scope="row">${orders[i].title}</td>
      <td scope="row">${orders[i].status}</td>
      <td scope="row">${orders[i].price}</td>
      <td scope="row">${orders[i].place}</td>
      <td scope="row">${orders[i].description}</td>`
     tableHtml += ` <td scope="row"><button type="submit" class="btn btn-danger" onclick="EndOrder(${orders[i].id})">Завершить</button></td></tr>`;
    }
    else if(orders[i].status === "Ожидает"){
      tableHtml += `
      <tr>
      <td scope="row">${orders[i].title}</td>
      <td scope="row">${orders[i].status}</td>
      <td scope="row">${orders[i].price}</td>
      <td scope="row">${orders[i].place}</td>
      <td scope="row">${orders[i].description}</td>`
     tableHtml += ` <td scope="row"><button type="submit" class="btn btn-success" onclick="AcceptOrder(${orders[i].id})">Принять</button></td> <td scope="row"><button type="submit" class="btn btn-outline-dark" onclick="ShowSpecialist(${orders[i].specialistId})">Специалист</button></td></tr>`;
    }
    else{
      tableHtml += `
    <tr>
    <td scope="row">${orders[i].title}</td>
    <td scope="row">${orders[i].status}</td>
    <td scope="row">${orders[i].price}</td>
    <td scope="row">${orders[i].place}</td>
    <td scope="row">${orders[i].description}</td>
    <td scope="row"></td>
    </tr>
    `;
    }
  }

 

  tableHtml += `</tbody>`;

  tableHtml += `</table>`;

  let tableDiv = document.getElementById("table-tasks-div");
  tableDiv.innerHTML = tableHtml;

  RefreshWindow();
}

function ShowSpecialist(){

}

async function AcceptOrder(orderId){

  let response = await fetch(`https://localhost:7046/api/Order/${employer.id}/${orderId}`, {
    method: "PUT",
    headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
    }
  });

  if(response.ok){
    GetUserOrders();
  }
  else{
    alert("Error!");
  }
}

async function EndOrder(orderId){
      let response = await fetch(`https://localhost:7046/api/Order/${orderId}`, {
    method: "DELETE",
    headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
    },


  });
}

function RefreshWindow(){
let profileHtml = `<button type="button" class="btn btn-outline-light me-2">${employer.name}</button>`
let profileButton = document.getElementById("profile");
profileButton.innerHTML = profileHtml; 
}

function GoToAddingOrder(){
  localStorage.setItem('employer', JSON.stringify(employer));
  window.location.href = "addingOrder.html";
}

function Exit(){
  window.location.href = "signIn.html";
}

let employer;