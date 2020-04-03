import update from '../utils/update-context.js';
import requests from '../utils/db-requests.js';
import formatData from '../utils/data-formatter.js';

export default {
    get: {
        create(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/causes/create-cause.hbs');
                });
        },
        dashboard(context) {
            requests.getAll()
                .then((res) => {

                    //return array with objects and every object have data props and id prop
                    const causes = res.docs.map(formatData);

                    context.causes = causes;

                    update(context)
                        .then(function () {
                            this.partial('../templates/causes/all-causes.hbs');
                        });
                })

        },
        details(context) {

            //get id from url/:id
            const { causeId } = context.params;

            requests.getById(causeId).then((res) => {

                //return array with objects and every object have data props and id prop
                const cause = formatData(res);

                context.cause = cause;

                //attach cause properties to context
                Object.keys(cause).forEach(key => {
                    context[key] = cause[key];
                });

                //only creator CANT donate
                context.canDonate = localStorage.userId !== cause.creator;

                update(context)
                    .then(function () {
                        this.partial('../templates/causes/cause-details.hbs');
                    });
            })
        }
    },
    post: {
        create(context) {
            // create cause with data
            requests.post({
                ...context.params, //form inputs by name attribute
                creator: localStorage.getItem('userId'),
                collecterFunds: 0,
                donors: []
            })
                .then((res) => {
                    context.redirect('#/cause/dashboard');
                });
        }
    },
    del: {
        delete(context) {
            const { causeId } = context.params;
            requests.delete(causeId).then((res) => {
                context.redirect('#/cause/dashboard')
            });
        }
    },
    put: {
        donate(context) {
            const { causeId, currentDonation } = context.params;

            //get cause data
            requests.getById(causeId).then((res) => {
                const cause = formatData(res);
                cause.collectedFunds += Number(currentDonation);

                //add donor name if he doesnt exists
                const currUser = localStorage.getItem('username');

                if (!cause.donors.includes(currUser)) {
                    cause.donors.push(currUser);
                }

                //update cause data
                requests.update(cause, causeId).then((res) => {
                    context.redirect('#/cause/dashboard');
                });

            });
        }
    }
}