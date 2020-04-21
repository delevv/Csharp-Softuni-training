import update from '../utils/update-context.js';

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
            const { email, password } = context.params;

            firebase.auth().signInWithEmailAndPassword(email, password)
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
            const { email, password } = context.params;
            const rePassword = context.params['rep-pass'];

            if (password === rePassword) {
                firebase.auth().createUserWithEmailAndPassword(email, password)
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