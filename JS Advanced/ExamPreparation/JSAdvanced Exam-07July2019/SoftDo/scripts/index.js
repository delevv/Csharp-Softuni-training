function mySolution() {
    let inputSection = document.getElementById("inputSection");

    let senderName = inputSection.getElementsByTagName('input')[0];
    let question = inputSection.getElementsByTagName('textarea')[0];
    let sendButton = inputSection.getElementsByTagName('button')[0];

    let pendingQuestions = document.querySelector('div[id="pendingQuestions"]');
    let openQuestions = document.querySelector('div[id="openQuestions"]');

    sendButton.addEventListener('click', (e) => {
        if (question.value !== '') {

            let pendingQuestionDiv = document.createElement('div');
            pendingQuestionDiv.classList.add("pendingQuestion");
            pendingQuestions.appendChild(pendingQuestionDiv);

            pendingQuestionDiv.innerHTML = '<img src="./images/user.png" width="32" height="32">' +
                `<span>${senderName.value === '' ? 'Anonymous' : senderName.value}</span>` +
                `<p>${question.value}</p>` +
                '<div class="actions">' +
                '<button class="archive">Archive</button>' +
                '<button class="open">Open</button>' +
                '</div>';

            pendingQuestionDiv.children[3].children[0].addEventListener('click', (e) => {
                e.target.parentElement.parentElement.remove();
            });

            pendingQuestionDiv.children[3].children[1].addEventListener('click', (e) => {
                let currDiv = e.target.parentElement.parentElement;
                let user = currDiv.children[1].textContent;
                let text = currDiv.children[2].textContent;
                currDiv.remove();

                let openQuestionDiv = document.createElement('div');
                openQuestionDiv.classList.add("openQuestion");
                openQuestionDiv.innerHTML = '<img src="./images/user.png" width="32" height="32">' +
                    `<span>${user}</span>` +
                    `<p>${text}</p>` +
                    '<div class="actions">' +
                    '<button class="reply">Reply</button>' +
                    '</div>' +
                    '<div class="replySection" style="display: none;">' +
                    '<input class="replyInput" type="text" placeholder="Reply to this question here...">' +
                    '<button class="replyButton">Send</button>' +
                    '<ol class="reply" type="1"></ol>' +
                    '</div>';

                let replySection = openQuestionDiv.children[4];
                let replybutton = openQuestionDiv.children[3].children[0];

                replybutton.addEventListener('click', (e) => {

                    if (replySection.style.display !== 'none') {
                        replySection.style.display = 'none';
                        replybutton.textContent = 'Reply';
                    }
                    else {
                        replySection.style.display = 'block';
                        replybutton.textContent = 'Back';
                    }
                })

                let answerButton = replySection.children[1];
                answerButton.addEventListener('click', (e) => {
                    let input = e.target.parentNode.children[0];
                    let list = e.target.parentNode.children[2];

                    if (input.value != '') {
                        let li = document.createElement('li');
                        li.textContent = input.value;
                        list.appendChild(li);
                        input.value = '';
                    }
                });
                openQuestions.appendChild(openQuestionDiv);
            });
        }
        senderName.value = '';
        question.value = '';
    })
}