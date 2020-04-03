import update from '../utils/update-context.js';

export default {
    get: {
        home(context) {
            update(context)
                .then(function () {
                    this.partial('../templates/home/home.hbs')
                });
        }
    }
}