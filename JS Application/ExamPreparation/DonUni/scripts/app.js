import handlers from '../handlers/index.js';

const app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    //Home
    this.get('#/', handlers.home.get.home)
    this.get('#/home', handlers.home.get.home)

    //User
    this.get('#/user/register', handlers.user.get.register);
    this.post('#/user/register', handlers.user.post.register);

    this.get('#/user/login', handlers.user.get.login);
    this.post('#/user/login', handlers.user.post.login);

    this.get('#/user/logout', handlers.user.get.logout);

    //Cause
    this.get('#/cause/create', handlers.cause.get.create);
    this.post('#/cause/create', handlers.cause.post.create);
    this.get('#/cause/dashboard', handlers.cause.get.dashboard);

    this.get('#/cause/details/:causeId', handlers.cause.get.details);

    this.post('#/cause/donate/:causeId', handlers.cause.put.donate);
    this.get('#/cause/close/:causeId', handlers.cause.del.delete);
});

(() => {
    app.run('#/home');
})();