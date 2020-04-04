import update from '../utils/update-context.js';
import requests from '../utils/db-requests.js';
import formatData from '../utils/data-formatter.js';

export default {
    get: {
        home(context) {
            update(context)
                .then(function () {

                    if (localStorage.getItem('username')) {
                        requests.getAll()
                            .then((res) => {
                                if (res != undefined && res != null) {

                                    const trecks = res.docs.map(formatData);

                                    context.hasTrecks = !!trecks;
                                    context.trecks = trecks;
                                }
                                this.partial('../templates/home/home.hbs')
                            })
                    } else {
                        this.partial('../templates/home/home.hbs')
                    }
                });
        }
    }
}