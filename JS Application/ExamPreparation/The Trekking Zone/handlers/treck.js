import update from '../utils/update-context.js';
import requests from '../utils/db-requests.js';
import formatData from '../utils/data-formatter.js';
import notifactions from '../notifications/notifications.js'

export default {
    get: {
        create(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/trecks/treck-create.hbs');
                });
        },
        details(context) {

            //get id from url/:id
            const { treckId } = context.params;

            requests.getById(treckId).then((res) => {

                //return array with objects and every object have data props and id prop
                const treck = formatData(res);

                //attach treck properties to context
                Object.keys(treck).forEach(key => {
                    context[key] = treck[key];
                });

                //only creator CANT donate
                context.isOrganizer = localStorage.username === treck.organizer;

                update(context)
                    .then(function () {
                        this.partial('../templates/trecks/treck-details.hbs');
                    });
            })
        },
        edit(context) {
            update(context)
                .then(function () {
                    context.treckId = context.params.treckId;
                    this.partial('../templates/trecks/treck-edit.hbs');
                });
        }
    },
    post: {
        create(context) {
            // create cause with data
            requests.post({
                ...context.params, //form inputs by name attribute
                organizer: localStorage.getItem('username'),
                likes: 0,
            })
                .then((res) => {
                    context.redirect('#/treck/create');
                    document.getElementById('successBox').style.display = 'block';
                })
        }
    },
    put: {
        edit(context) {
            const { treckId, location, dateTime, description, imageURL } = context.params;

            // get treck data
            requests.getById(treckId).then((res) => {
                const treck = formatData(res);
                treck.location = location;
                treck.dateTime = dateTime;
                treck.description = description;
                treck.imageURL = imageURL;

                //update treck data
                requests.update(treck, treckId).then((res) => {
                    context.redirect('#/home');
                });
            })
        },
        like(context) {
            const { treckId } = context.params;

            // get treck data
            requests.getById(treckId).then((res) => {
                const treck = formatData(res);
                treck.likes++;

                //update treck data
                requests.update(treck, treckId).then((res) => {
                    context.redirect(`#/treck/details/${treckId}`);
                });
            })
        }
    },
    del: {
        close(context) {
            const { treckId } = context.params;
            requests.delete(treckId).then((res) => {
                context.redirect('#/home')
            });
        }
    }
}