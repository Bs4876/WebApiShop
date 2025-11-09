const h1 = document.querySelector("h1")
const curentUser = sessionStorage.getItem("currentUser")
h1.textContent = `שלום ${JSON.parse(curentUser).firstName} בוא נצלול פנימה`
console.log(curentUser)
async function update() {
    const ind = JSON.parse(curentUser).userId;
    const userName = document.querySelector("#userName").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value

    const updateUserData = {
        userName, 
        firstName,
        lastName, 
        password 
    };
    console.log(updateUserData,ind);
    const response = await fetch(`https://localhost:44392/api/Users/${ind}`,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUserData)
        });
    const userData = await response;
    sessionStorage.setItem("user", JSON.stringify(updateUserData));
    alert("עודכנו הפרטים")

}


