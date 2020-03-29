const collectionName = 'teams';
const collectionURL = `https://remotedbexercise.firebaseio.com/${collectionName}`;

function getAllRecords(token) {
    return fetch(`${collectionURL}/.json${token ? `?auth=${token}` : ''}`)
        .then(CheckStatus)
        .then(r => r.json())
        .catch(handleError);
}

function getRecordById(token, id) {
    return fetch(`${collectionURL}/${id}.json${token ? `?auth=${token}` : ''}`)
        .then(CheckStatus)
        .then(r => r.json())
        .catch(handleError);
}

function createRecord(token, data) {
    return fetch(`${collectionURL}/.json${token ? `?auth=${token}` : ''}`, {
        method: 'POST',
        body: JSON.stringify(data)
    })
        .then(CheckStatus)
        .catch(handleError);
}

function updateRecord(token, id, data) {
    return fetch(`${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ''), {
        method: 'PUT',
        body: JSON.stringify(data)
    })
        .then(CheckStatus)
        .catch(handleError);
}

function partialUpdateRecord(token, id, data) {
    return fetch(`${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ''), {
        method: 'PATCH',
        body: JSON.stringify(data)
    })
        .then(CheckStatus)
        .catch(handleError);
}

function deleteRecord(token, id) {
    return fetch(`${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ''), {
        method: 'DELETE'
    })
        .then(CheckStatus)
        .catch(handleError);
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

export const requester = {
    getAllRecords,
    getRecordById,
    createRecord,
    updateRecord,
    deleteRecord,
    partialUpdateRecord
}