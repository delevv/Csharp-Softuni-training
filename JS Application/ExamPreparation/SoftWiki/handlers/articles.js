import update from '../utils/update-context.js';
import requests from '../utils/db-requests.js';
import formatData from '../utils/data-formatter.js';

export default {
    get: {
        create(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/articles/create.hbs');
                });
        },
        details(context) {

            //get id from url/:id
            const { articleId } = context.params;

            requests.getById(articleId).then((res) => {

                //return array with objects and every object have data props and id prop
                const article = formatData(res);

                context.article = article;

                //attach article properties to context
                Object.keys(article).forEach(key => {
                    context[key] = article[key];
                });

                //only creator can edit or delete
                context.isCreator = localStorage.username === article.creator;

                update(context)
                    .then(function () {
                        this.partial('../templates/articles/details.hbs');
                    });
            })
        },
        edit(context) {
            update(context)
                .then(function () {
                    context.id = context.params.articleId;
                    this.partial('../templates/articles/edit.hbs');
                });
        }
    },
    post: {
        create(context) {
            const requiredCategory = ['JavaScript', 'C#', 'Java', 'Pyton'];
            // create cause with data

            if (requiredCategory.includes(context.params.category)) {
                requests.post({
                    ...context.params, //form inputs by name attribute
                    creator: localStorage.getItem('username'),
                })
                    .then((res) => {
                        context.redirect('#/home');
                    })
                    .catch((err) => console.log(err));
            } else {
                context.redirect('#/home');
            }
        }
    },
    del: {
        delete(context) {
            const { articleId } = context.params;

            requests.delete(articleId)
                .then((res) => {
                    context.redirect('#/home')
                })
                .catch((res) => console.log(res));
        }
    },
    put: {
        edit(context) {
            const { articleId } = context.params;

            requests.update({ ...context.params }, articleId)
                .then((res) => {
                    context.redirect('#/home');
                })
                .catch((res) => console.log(res));
        }
    }
}