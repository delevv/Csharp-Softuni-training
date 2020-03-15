function attachEvents() {
    let loadButton = document.getElementById('btnLoad');
    let createButton = document.getElementById('btnCreate');

    let personInput = document.getElementById('person');
    let phoneInput = document.getElementById('phone');
    let phoneBookList = document.getElementById('phonebook');

    createButton.addEventListener('click', createContact)
    loadButton.addEventListener('click', loadContacts);

    function createContact() {
        let contact = {
            person: personInput.value,
            phone: phoneInput.value
        }

        if (contact.person !== '' && contact.phone !== '') {
            fetch("https://phonebook-nakov.firebaseio.com/phonebook.json", {
                method: 'POST',
                body: JSON.stringify(contact)
            })
                .then(() => {
                    personInput.value = '';
                    phoneInput.value = '';
                    loadContacts();
                });
        }
    }

    function loadContacts() {
        fetch('https://phonebook-nakov.firebaseio.com/phonebook.json')
            .then(r => r.json())
            .then((data) => {
                phoneBookList.innerHTML = '';

                if (data !== null) {
                    Object.entries(data).forEach(([key, info]) => {
                        let li = document.createElement('li');
                        li.textContent = `${info.person}: ${info.phone}`;

                        let deleteButton = document.createElement("button");
                        deleteButton.textContent = "Delete";
                        deleteButton.setAttribute("targetKey", key);
                        deleteButton.addEventListener("click", deleteContact);

                        li.appendChild(deleteButton);
                        phoneBookList.appendChild(li);
                    });
                }
            });
    }

    function deleteContact() {
        let key = this.getAttribute("targetKey");

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`, {
            method: 'DELETE'
        })
            .then((data) => {
                phoneBookList.innerHTML = '';
                loadContacts();
            });
    }
}

attachEvents();