import { requests } from './firebaseRequests.js';

(() => {
    const tbody = document.querySelector('tbody');
    const createBookForm = document.querySelector('#createBook');
    const submitButton = createBookForm.querySelector('button');
    const loadBooksButton = document.getElementById('loadBooks');

    loadBooksButton.addEventListener('click', showBooks);

    submitButton.addEventListener('click', async (e) => {
        e.preventDefault();
        await createNewBook();
        await showBooks();
    });

    async function showBooks() {
        await requests.getAllBooks().then((books) => {
            if (books !== null && books !== undefined) {
                tbody.innerHTML = '';

                Object.entries(books).forEach((book) => {
                    let bookElement = getCurrentBookElement(book);
                    tbody.appendChild(bookElement);
                });
            }
        });
    }

    function getCurrentBookElement([id, bookInfo]) {
        let bookRow = document.createElement('tr');
        bookRow.setAttribute('book-id', id);

        let titleTd = document.createElement('td');
        titleTd.textContent = bookInfo.title;

        let authorTd = document.createElement('td');
        authorTd.textContent = bookInfo.author;

        let isbnTD = document.createElement('td');
        isbnTD.textContent = bookInfo.isbn;

        let editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', editBook);

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteBook);

        let buttonsTd = document.createElement('td');
        buttonsTd.append(editButton, deleteButton);

        bookRow.append(titleTd, authorTd, isbnTD, buttonsTd);

        return bookRow;
    }

    async function createNewBook() {
        let bookInfo = getBookInfo();
        await requests.createBook(bookInfo);
    }

    async function editBook() {
        let bookId = this.parentElement.parentElement.getAttribute('book-id');
        let bookInfo = getBookInfo();

        await requests.updateBook(bookId, bookInfo)
        await showBooks();
    }

    async function deleteBook() {
        let bookRow = this.parentElement.parentElement;
        let bookId = bookRow.getAttribute('book-id');

        await requests.deleteBook(bookId);
        await showBooks();
    }

    function getBookInfo() {
        let book = {};

        Array.from(createBookForm.children)
            .filter(x => x.tagName === 'INPUT')
            .forEach(i => {
                book[i.getAttribute('id')] = i.value === '' ? 'unknown' : i.value;
                i.value = '';
            });

        return book;
    }
})();