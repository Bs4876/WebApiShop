
async function login () {
    const userName = document.querySelector("#existUserName").value
    const password = document.querySelector("#existPassword").value

    const userToLogin = {
        userName,
        password
    };

    const response = await fetch("https://localhost:44392/api/Users/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        //body: JSON.stringify(loginUser)
        body: JSON.stringify(userToLogin)
    });
    if (response.status===201) {
        const currentUser = await response.json();
        console.log(currentUser);
        //alert(currentUser.userId)
        sessionStorage.setItem("currentUser", JSON.stringify(currentUser))
        window.location.href = "update.html"
        //get by id
    }
    else {
        alert("אתה עדין לא קיים במערכת נא הרשם")
    }
}

async function register() {
    const userName = document.querySelector("#userName").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    const newUserData = {
        firstName,
        lastName,
        userName,
        password 
    };
    console.log(newUserData)
    const response = await fetch("https://localhost:44392/api/Users", {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUserData)
    });
 
    const userData = await response.json();
    if (response.status == 201) {
        sessionStorage.setItem("user", JSON.stringify(userData));
        let user = sessionStorage.getItem("user");

        alert("המשתמש נרשם בהצלחה")
        return currentUser = JSON.parse(user);
    }
    else {
        alert("הכנס סיסמה חזקה יותר")
    }
}

async function checkStrengthPassword() {

    const password = document.querySelector("#password").value

    const response = await fetch(`https://localhost:44392/api/Password`, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });

    const data = await response.json();
    if (response.status == 200)
    {
        const progress = document.querySelector("progress")
        progress.value = data.strength/4
        console.log(data)
    }
}