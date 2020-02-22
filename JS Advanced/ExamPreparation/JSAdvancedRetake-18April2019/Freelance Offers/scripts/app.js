function solve() {
    let usernameElements = document.getElementById("usernameContainer").children;
    let usernameInput = usernameElements[0];
    let loginButton = usernameElements[1];

    let createOffers = document.getElementById("create-offers");
    createOffers.style.display = 'none';

    let offerName = document.getElementById("offerName");
    let company = document.getElementById("company");
    let description = document.getElementById("description");
    let createButton = document.getElementById("create-offer-Btn");

    loginButton.addEventListener('click', login);
    createButton.addEventListener('click', create);


    function login(e) {
        e.preventDefault();

        let notification = document.getElementById("notification");
        let username = usernameInput.value;

        if (username.length >= 4 && username.length <= 10) {
            createOffers.style.display = 'block';

            usernameInput.classList.add("border-0");
            usernameInput.classList.add("bg-light");
            usernameInput.value = `Hello, ${username}!`;
            usernameInput.disabled = true;

            notification.textContent = '';

            loginButton.textContent = 'Logout';
            loginButton.removeEventListener('click', login);
            loginButton.addEventListener('click', logout);

        }
        else {
            notification.textContent = "The username length should be between 4 and 10 characters.";
            usernameInput.value = '';
        }
    }

    function logout(e) {
        e.preventDefault();
        createOffers.style.display = 'none';
        
        usernameInput.classList.remove("border-0");
        usernameInput.classList.remove("bg-light");
        usernameInput.value = '';
        usernameInput.disabled = false;

        loginButton.textContent = 'Login';
        loginButton.removeEventListener('click', logout);
        loginButton.addEventListener('click', login);
    }

    function create(e) {
        e.preventDefault();

        if (offerName.value !== '' && company.value !== '' && description.value !== '') {
            document.getElementById("offers-container").innerHTML += '<div class="col-3">' +
                '<div class="card text-white bg-dark mb-3 pb-3" style="max-width: 18rem;">' +
                `<div class="card-header">${offerName.value}</div>` +
                '<div class="card-body">' +
                `<h5 class="card-title">${company.value}</h5>` +
                `<p class="card-text">${description.value}</p>` +
                '</div>' +
                '</div>' +
                '</div>';
        }

        offerName.value = '';
        company.value = '';
        description.value = '';
    }
}

solve();