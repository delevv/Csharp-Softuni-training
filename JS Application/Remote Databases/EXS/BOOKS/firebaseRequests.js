const firebaseURL = 'https://remotedbexercise.firebaseio.com/'; // place your firebase link here

const requests = {
    getAllBooks: () => {
        return fetch(`${firebaseURL}books.json`)
            .then(CheckStatus)
            .then(r => r.json())
            .catch(handleError);
    },
    createBook: (data) => {
        return fetch(`${firebaseURL}books.json`, {
            method: 'POST',
            body: JSON.stringify(data)
        })
            .then(CheckStatus)
            .catch(handleError);
    },
    updateBook: (bookId, data) => {
        return fetch(`${firebaseURL}books/${bookId}.json`, {
            method: 'PUT',
            body: JSON.stringify(data)
        })
            .then(CheckStatus)
            .catch(handleError);
    },
    deleteBook: (bookId) => {
        return fetch(`${firebaseURL}books/${bookId}.json`, {
            method: 'DELETE'
        })
            .then(CheckStatus)
            .catch(handleError);
    }
}

function CheckStatus(res) {
    if (!res.ok) {
        throw new Error(`StatusCode: ${res.status}\nMessage: ${res.statusText}`);
    }
    return res;
}

function handleError(err) {
    console.log(err.message);
}

export { requests };