async function AddOrder() {

let order = {
  "id": 0,
  "status": "Ожидает",
  "title": document.getElementById("input-title-field").value,
  "price": document.getElementById("input-price-field").value,
  "place": document.getElementById("input-place-field").value,
  "description": document.getElementById("input-description-field").value,
  "deadline": document.getElementById("input-deadline-field").value

};

    let response = await fetch(`https://localhost:7046/api/Order/${employer.id}/2}`, {
        method: "POST",
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(order)
      });
    
    if(response.ok){
          localStorage.setItem('employer', JSON.stringify(employer));
          window.location.href = "employer.html";
    }
    else{
      alert("Error!!!");
    }
}

async function OnLoadPage() {
  employer = JSON.parse(localStorage.getItem("employer"));
  console.log(employer);

  let response = await fetch(`https://localhost:7046/api/Category/`, {
    method: "GET",
    headers: {
      "Accept": "application/json",
      "Content-Type": "application/json",
    },
  });

  let categories = await response.json() 

console.log(categories);

  let categoryHtml = ` 
<select class="my-2" id="combobox-cards" label="Категории">Категории
`;

  for (let i = 0; i < categories.length; i++) {
    categoryHtml += `
  <option class="combobox" value="${categories[i].title}">${categories[i].title}</option>
  `;
  }

  categoryHtml += `
  </select>
  `;

  let comboboxDiv = document.getElementById("category-box");
  comboboxDiv.innerHTML = categoryHtml;
}

  let employer;