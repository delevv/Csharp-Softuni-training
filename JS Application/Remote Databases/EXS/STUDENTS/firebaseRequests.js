const firebaseURL = 'https://remotedbexercise.firebaseio.com/'; // place your firebase link here

const requests = {
    getStudents: () => {
        return fetch(`${firebaseURL}students.json`)
            .then(CheckStatus)
            .then(r => r.json())
            .catch(handleError);
    },
    postStudent: (studentInfo) => {
        fetch(`${firebaseURL}students.json`, {
            method: 'POST',
            body: JSON.stringify(studentInfo)
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