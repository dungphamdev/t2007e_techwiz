
function login() {
    let loginModel = {
        'username': '',
        'password': ''
    }

    const formData = new FormData(document.getElementById('login-form'))
    for (var pair of formData.entries()) {
        if (pair[0] == 'username') loginModel.username = pair[1];
        if (pair[0] == 'password') loginModel.password = pair[1];
    }

    console.log(loginModel);

    // fetch('http://localhost:4000/api/persons/getPersonById', {
    //     method: 'POST', // or 'PUT'
    //     headers: {
    //         'Content-Type': 'application/json',
    //     },
    //     body: JSON.stringify(data),
    // })
    //     .then(response => response.json())
    //     .then(data => {
    //         console.log('Success:', data);
    //     })
    //     .catch((error) => {
    //         console.error('Error:', error);
    //     });

}