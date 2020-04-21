import handlers from '../handlers/index.js';

const app = Sammy('#root', function () {
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

    //create article
    this.get('#/articles/create', handlers.articles.get.create);
    this.post('#/articles/create', handlers.articles.post.create);

    //get details for article
    this.get('#/articles/details/:articleId', handlers.articles.get.details);

    //edit article
    this.get('#/articles/details/edit/:articleId', handlers.articles.get.edit);
    this.post('#/articles/details/edit/:articleId', handlers.articles.put.edit);

    //delete article
    this.get('#/articles/details/delete/:articleId', handlers.articles.del.delete);

});

(() => {
    app.run('#/home');
})();