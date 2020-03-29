import { handlers } from './handlers.js';

// initialize the application
var app = Sammy('#main', function () {
    // include a plugin
    this.use('Handlebars', 'hbs');
    // define a 'route'
    this.get('#/', handlers.home);
    this.get('#/home', handlers.home);
    this.get('#/about', handlers.about);
    this.get('#/login', handlers.login);
    this.post('#/login', () => false);
    this.get('#/register', handlers.register);
    this.post('#/register', () => false);
    this.get('#/logout', handlers.logout);
    this.get('#/catalog', handlers.catalog);
    this.get('#/catalog/:id', handlers.catalogById);
    this.get('#/create', handlers.createTeam);
    this.post('#/create', () => false);
    this.get('#/join/:id', handlers.joinTeam);
    this.get('#/leave/:id', handlers.leaveTeam);
    this.get('#/edit/:id', handlers.editTeam);
    this.post('#/edit/', () => false);
});

// start the application
(() => {
    app.run('#/');
})();