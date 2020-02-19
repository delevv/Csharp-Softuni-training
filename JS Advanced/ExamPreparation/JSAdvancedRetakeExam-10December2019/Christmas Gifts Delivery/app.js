function solution() {
    let sections = document.getElementsByTagName('section');

    let addButton = sections[0].children[1].children[1];
    let listOfGifts = sections[1].children[1];
    let sentGifts = sections[2].children[1];
    let discardedfGifts = sections[3].children[1];

    addButton.addEventListener('click', (e) => {
        let input = e.target.parentElement.children[0];

        let currLi = document.createElement('li');
        currLi.classList.add('gift');
        currLi.textContent = input.value;

        let sendButton = document.createElement('button');
        sendButton.textContent = 'Send';
        sendButton.id = 'sendButton';

        let discardButton = document.createElement('button');
        discardButton.textContent = 'Discard';
        discardButton.id = 'discardButton';

        sendButton.addEventListener('click', (sentEvent) => {
            let currGiftElement = sentEvent.target.parentElement;
            currGiftElement.children[0].remove();
            currGiftElement.children[0].remove();

            sentGifts.appendChild(currGiftElement.cloneNode(true));
            currGiftElement.remove();
        });

        discardButton.addEventListener('click', (discardEvent) => {
            let currGiftElement = discardEvent.target.parentElement;
            currGiftElement.children[0].remove();
            currGiftElement.children[0].remove();

            discardedfGifts.appendChild(currGiftElement.cloneNode(true));
            currGiftElement.remove();
        });

        currLi.appendChild(sendButton);
        currLi.appendChild(discardButton);

        input.value = '';
        listOfGifts.appendChild(currLi);
        orderList(listOfGifts);
    });

    function orderList(list) {
        let listItems = Array.from(list.children);
        list.innerHTML = '';

        listItems
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => list.appendChild(li));
    }
}