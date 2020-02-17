function solve() {
    let formElements = document.querySelector('form').children;
    let books = document.querySelectorAll('div[class="bookShelf"]');
    let totalProfit = document.querySelectorAll('h1')[1];

    let oldBooks = books[0];
    let newBooks = books[1];

    let addButton = formElements[6];

    addButton.addEventListener('click', (e) => {
        e.preventDefault();

        let title = formElements[1].value;
        let year = formElements[3].value;
        let price = Number(formElements[5].value);

        if (title !== '' && year > 0 && price > 0) {
            let bookDiv = document.createElement('div');
            bookDiv.classList.add('book');

            let p = document.createElement('p');
            p.textContent = `${title} [${year}]`;

            let buyButton = document.createElement('button');
            buyButton.textContent = `Buy it only for ${(year >= 2000 ? price : price * 0.85).toFixed(2)} BGN`;

            buyButton.addEventListener('click', buyBook);

            let moveButton = document.createElement('button');
            moveButton.textContent = 'Move to old section';

            moveButton.addEventListener('click', (e) => {
                let currDiv = e.target.parentElement;

                currDiv.children[1].textContent = `Buy it only for ${(price * 0.85).toFixed(2)} BGN`
                currDiv.children[2].remove();

                let cloneDiv = currDiv.cloneNode(true);
                cloneDiv.children[1].addEventListener('click', buyBook);
                oldBooks.appendChild(cloneDiv);
                currDiv.remove();
            })

            bookDiv.appendChild(p);
            bookDiv.appendChild(buyButton);

            if (year >= 2000) {
                bookDiv.appendChild(moveButton);
                newBooks.appendChild(bookDiv);
            }
            else {
                oldBooks.appendChild(bookDiv);
            }
        }
    })

    function buyBook(e) {
        let currProfit = Number(totalProfit.textContent.split(' ')[3]);
        let currDiv = e.target.parentElement;

        currProfit += Number(e.target.textContent.split(' ')[4]);
        totalProfit.textContent = `Total Store Profit: ${currProfit.toFixed(2)} BGN`;

        currDiv.remove();
    };
}