const h1 = document.querySelector("h1")
const curentUser = sessionStorage.getItem("currentUser")
h1.textContent = `שלום ${JSON.parse(curentUser).firstName} בוא נצלול פנימה`
console.log(curentUser)
async function update() {
    const userId = JSON.parse(curentUser).userId;
    const UserMail = document.querySelector("#UserMail").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    
    const updateUserData = {
        userId,
        UserMail, 
        firstName,
        lastName, 
        password 
    };
    console.log(updateUserData, userId);
    const response = await fetch(`https://localhost:44392/api/Users/${userId}`,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUserData)
        });
    const userData = await response;
    if (response.status == 204) {
        sessionStorage.setItem("user", JSON.stringify(updateUserData));
        alert("עודכנו הפרטים")
    }
    else {
        alert("הכנס סיסמה חזקה יותר")
    }

}


