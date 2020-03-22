const firebaseURL = 'https://remotedbexercise.firebaseio.com/'; // place you firebase link here

const requests = {
    getPlayers: () => {
        return fetch(`${firebaseURL}players.json`)
            .then(CheckStatus)
            .then(r => r.json())
            .catch(handleError);
    },
    postPlayer: async (playerInfo) => {
        return fetch(`${firebaseURL}players.json`, {
            method: 'POST',
            body: JSON.stringify(playerInfo)
        })
            .then(CheckStatus)
            .catch(handleError);
    },
    deletePlayer: async (id) => {
        return fetch(`${firebaseURL}players/${id}.json`, {
            method: 'DELETE'
        })
            .then(CheckStatus)
            .catch(handleError);
    },
    updatePlayer: async (id, playerInfo) => {
        return fetch(`${firebaseURL}players/${id}.json`, {
            method: 'PUT',
            body: JSON.stringify(playerInfo)
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