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

    //Main logic

    this.get('#/treck/create', handlers.treck.get.create);
    this.post('#/treck/create', handlers.treck.post.create);

    this.get('#/treck/details/:treckId', handlers.treck.get.details)
    
    this.get('#/treck/edit/:treckId', handlers.treck.get.edit)
    this.post('#/treck/edit/:treckId', handlers.treck.put.edit)
  
    this.get('#/treck/close/:treckId', handlers.treck.del.close)

    this.get('#/treck/like/:treckId', handlers.treck.put.like)

});

(() => {
    app.run('#/home');
})();