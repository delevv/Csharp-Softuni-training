export default function (context) {
    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            // User is signed in.
            context.isLoggedIn = true;
            context.username = user.email;
            context.userId = user.uid;
           
            localStorage.setItem('userId', user.uid);
            localStorage.setItem('username', user.email);
        } else {
            // User is signed out.
            context.isLoggedIn = false;
            context.username = null;
            context.userId = null;
            
            localStorage.removeItem('userId');
            localStorage.removeItem('username');
        }
    });

    return context.loadPartials({
        header: '../templates/common/header.hbs',
        footer: '../templates/common/footer.hbs',
        notifications: '../templates/common/notifications.hbs'
    });
}