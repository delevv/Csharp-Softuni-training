import update from '../utils/update-context.js';
import notification from '../notifications/notifications.js';

export default {
    get: {
        login(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/login/login.hbs');
                });
        },
        register(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/register/register.hbs');
                });
        },
        logout(context) {
            firebase.auth().signOut().then((res) => {
                context.redirect('#/home');
            });
        }
    },
    post: {
        login(context) {
            const { username, password } = context.params;

            firebase.auth().signInWithEmailAndPassword(username, password)
                .then(async (user) => {
                    context.user = user;
                    context.username = user.email;
                    context.isLoggedIn = true;

                    await context.redirect('#/home');
                })
                .catch((err) => {
                    console.log(err)
                });
        },
        register(context) {
            const { username, password, rePassword } = context.params;

            if (password === rePassword) {
                firebase.auth().createUserWithEmailAndPassword(username, password)
                    .then((user) => {


                        context.redirect('#/home');
                    })
                    .catch((err) => {
                        console.log(err)
                    });
            }
        }
    }
}