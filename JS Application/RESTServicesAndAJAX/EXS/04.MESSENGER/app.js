function attachEvents() {
    let url = 'https://rest-messanger.firebaseio.com/messanger.json';

    let messagesArea = document.getElementById('messages');
    let sendButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');

    let nameInput = document.getElementById('author');
    let messageInput = document.getElementById('content');

    sendButton.addEventListener('click', sendMessage);
    refreshButton.addEventListener('click', refreshMessages);

    function sendMessage() {
        let name = nameInput.value;
        let message = messageInput.value;

        if (name !== '' && message !== '') {
            let messageInfo = {
                author: name,
                content: message
            }

            fetch(url, {
                method: 'POST',
                body: JSON.stringify(messageInfo)
            })
                .then(() => {
                    nameInput.value = '';
                    messageInput.value = '';
                });
        }
    }

    function refreshMessages() {
        fetch(url)
            .then(r => r.json())
            .then((data) => {
                if (data !== null) {
                    messagesArea.textContent = '';

                    Object.values(data).forEach((message) => {
                        messagesArea.textContent += `${message.author}: ${message.content}\n`;
                    });
                }
            });
    }
}

attachEvents();