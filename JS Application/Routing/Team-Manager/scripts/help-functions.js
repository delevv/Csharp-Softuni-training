function getFormInputsValuesAsObject(form) {
    return Array.from(form.children).reduce((acc, currElement) => {
        if (currElement.tagName === 'DIV') {
            let currInput = currElement.children[1];
            acc[currInput.getAttribute('id')] = currInput.value;
        }
        return acc;
    }, {});
}

async function registerUser(email, password) {
    let account = await firebase.auth().createUserWithEmailAndPassword(email, password)
        .catch(err => {

        });

    let token = await firebase.auth().currentUser.getIdToken();
    sessionStorage.setItem('token', token);
    sessionStorage.setItem('username', account.user.email);
    sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
}

async function loginUser(email, password) {
    let account = await firebase.auth().signInWithEmailAndPassword(email, password)
        .catch(err => {

        });

    let token = await firebase.auth().currentUser.getIdToken();
    sessionStorage.setItem('token', token);
    sessionStorage.setItem('username', account.user.email);
    sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
}

function logoutUser() {
    sessionStorage.clear();
    firebase.auth().signOut();
}

export const helper = {
    getFormInputsValuesAsObject,
    registerUser,
    loginUser,
    logoutUser
}